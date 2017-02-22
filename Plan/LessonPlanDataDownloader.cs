namespace Plan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading.Tasks;

    using HtmlAgilityPack;

    using Newtonsoft.Json;

    using Windows.Web.Http;

    public class LessonPlanDataDownloader : ILessonPlanDataDownloader
    {
        private const string PlanMain = @"https://inf.ug.edu.pl/plan/index.php";
        private const string PlanSeminars = @"https://inf.ug.edu.pl/plan/index.php?zajecia=Se.[im]";
        private const string PlanFaculty = @"https://inf.ug.edu.pl/plan/index.php?zajecia=Fa.[im]";
        private const string PlanForStudent = @"https://inf.ug.edu.pl/plan/index.php?dialog=student";
        private const string PlanForStudies = @"https://inf.ug.edu.pl/plan/index.php?dialog=grupa";
        private const string PlanSettings = @"https://inf.ug.edu.pl/plan/dat/groups.json";
        private const string JsonSuffix = @"&format=json";
        private static LessonPlanDataDownloader instance;

        private LessonPlanDataDownloader()
        {           
        }

        public event Action<Exception> ErrorOccured;

        public static LessonPlanDataDownloader Instance => instance ?? (instance = new LessonPlanDataDownloader());

        public async Task<string> MakeWebRequest(string uri)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync(new Uri(uri));
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                this.ErrorOccured?.Invoke(new CommunicationException("Nie udało się połączyć z serwerem."));
            }

            return null;
        }

        public async Task<List<PlanSelect>> DownloadPlanForStudiesOptions()
        {
            var html = await this.MakeWebRequest(PlanForStudies);

            if (!string.IsNullOrEmpty(html))
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var list = doc.GetElementbyId("list");
                var linkCollection = list.Descendants("a");
                var result = linkCollection.Select(link => new PlanSelect { Name = link.InnerText, LinkSuffix = link.GetAttributeValue("href", string.Empty) }).ToList();
                return result;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
        }

        public async Task<List<Classes>> DownloadPlanForStudies(PlanSelect so)
        {
            var json = await this.MakeWebRequest(PlanMain + so.LinkSuffix + JsonSuffix);
            return this.ConvertJsonToClassesObjects(json);
        }

        public async Task<List<Classes>> DownloadPlanSeminars()
        {
            var json = await this.MakeWebRequest(PlanSeminars + JsonSuffix);
            return this.ConvertJsonToClassesObjects(json);
        }

        public async Task<List<Classes>> DownloadPlanFaculty()
        {
            var json = await this.MakeWebRequest(PlanFaculty + JsonSuffix);
            return this.ConvertJsonToClassesObjects(json);
        }

        public async Task<List<Change>> DownloadChanges()
        {
            var html = await this.MakeWebRequest(PlanMain);

            if (!string.IsNullOrEmpty(html))
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                var table = doc.GetElementbyId("tab");
                var changesCollection = table.Descendants("tbody")?.First().Descendants("tr");
                return changesCollection?.Select(change => change.Descendants("td").ToList()).Select(tds => new Change { Group = tds[0].Element("nobr").InnerText, Lecturer = tds[1].Element("nobr").InnerText, Subject = tds[2].Element("nobr").InnerText, ClassesType = tds[3].Element("nobr").InnerText, Changes = tds[4].Element("nobr").InnerText }).ToList();
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
        }

        public async Task<List<Setting>> DownloadSettings()
        {
            var json = await this.MakeWebRequest(PlanSettings);
            var collection = JsonConvert.DeserializeObject<LessonPlanSettingsJson[]>(json).ToList();
            var settingsList = collection.Where(x => !x.name.Contains(" ")).Select(setting => new Setting { Symbol = setting.name, Name = setting.longname, Params = (GetMethodParams)setting.Clone(), Lectorates = new List<string>(), Specjalizations = new List<Specialization>(), Faculties = new List<PlanSelect>(), Seminars = new List<PlanSelect>() }).ToList();
            foreach (var setting in collection.Where(x => x.name.Contains(" ") && !string.IsNullOrEmpty(x.longname)))
            {
                var symbolArray = setting.name.Split(' ');
                settingsList.First(x => x.Symbol == symbolArray[0]).Specjalizations.Add(new Specialization { Name = setting.longname, Symbol = symbolArray[1], Groups = new List<Group>() });
            }

            foreach (var setting in settingsList)
            {
                if (setting.Specjalizations.Count == 0)
                {
                    setting.Specjalizations.Add(new Specialization { Groups = new List<Group>() });
                }
            }

            foreach (var setting in collection.Where(x => string.IsNullOrEmpty(x.longname)))
            {
                var symbolArray = setting.name.Split(' ');
                var set = settingsList.First(x => x.Symbol == symbolArray[0]);

                if (set.Specjalizations.Count == 1 && string.IsNullOrEmpty(set.Specjalizations[0].Symbol))
                {
                    if (symbolArray.Length >= 2)
                    {
                        var group = set.Specjalizations[0].Groups.FirstOrDefault(x => x.Number == symbolArray[1]) ?? new Group { Number = symbolArray[1], Lectorates = new List<string>() };
                        if (symbolArray.Length >= 3)
                        {
                            group.Lectorates.Add(symbolArray[2]);
                        }

                        if (set.Specjalizations[0].Groups.FirstOrDefault(x => x.Number == symbolArray[1]) == null)
                        {
                            set.Specjalizations[0].Groups.Add(group);
                        }
                    }
                }
                else
                {
                    if (symbolArray.Length >= 2)
                    {
                        var specializationIndex = set.Specjalizations.FindIndex(x => x.Symbol == symbolArray[1]);
                        if (symbolArray.Length >= 3)
                        {
                            var group = set.Specjalizations[specializationIndex].Groups.FirstOrDefault(x => x.Number == symbolArray[2]) ?? new Group { Number = symbolArray[2], Lectorates = new List<string>() };
                            if (symbolArray.Length >= 4)
                            {
                                group.Lectorates.Add(symbolArray[3]);
                            }

                            if (set.Specjalizations[specializationIndex].Groups.FirstOrDefault(x => x.Number == symbolArray[2]) == null)
                            {
                                set.Specjalizations[specializationIndex].Groups.Add(group);
                            }
                        }
                    }
                }
            }

            foreach (var setting in settingsList)
            {
                setting.Faculties = await this.DownloadFacultySettings(setting);
                setting.Seminars = await this.DownloadSeminarSettings(setting);
            }

            return settingsList;
        }

        public async Task<List<Classes>> DownloadPlanForStudent(PlanForStudentSetting setting)
        {
            var address = PlanMain + "?";
            var paramList = new List<string>();
            if (setting.Faculties != null && !string.IsNullOrEmpty(setting.FacultyPrefix))
            {
                paramList.AddRange(setting.Faculties.Select(s => setting.FacultyPrefix + "=" + s.Replace(" ", "+")));
            }

            if (!string.IsNullOrEmpty(setting.Seminar) && !string.IsNullOrEmpty(setting.SeminarPrefix))
            {
                paramList.Add(setting.SeminarPrefix + "=" + setting.Seminar);
            }

            var student = "student=" + setting.Symbol;
            if (!string.IsNullOrEmpty(setting.Speciality))
            {
                student += "+" + setting.Speciality;
            }

            if (!string.IsNullOrEmpty(setting.Group))
            {
                student += "+" + setting.Group;
            }

            if (!string.IsNullOrEmpty(setting.Lectorate))
            {
                student += "+" + setting.Lectorate;
            }

            paramList.Add(student);
            for (var i = 0; i < paramList.Count; i++)
            {
                address += paramList[i];
                if (i != paramList.Count - 1)
                {
                    address += "&";
                }
            }

            address += JsonSuffix;
            var json = await this.MakeWebRequest(address);
            return this.ConvertJsonToClassesObjects(json);
        }

        private List<Classes> ConvertJsonToClassesObjects(string json)
        {
            var collection = JsonConvert.DeserializeObject<ClassesJson[]>(json).ToList();
            var allHours = collection.Select(t => new Classes { Subject = t.przedmiot, Lecturer = t.nauczyciel, Room = t.sala, Comments = t.uwagi, DateTo = t.datado, Day = t.dzien, Type = t.typ, Group = t.grupa, HourFrom = t.godz }).ToList();
            var result = new List<Classes>();
            foreach (var c in allHours)
            {
                if (result.Any(x => x.EqualClass(c)))
                {
                    result.First(x => x.EqualClass(c)).Merge(c);
                }
                else
                {
                    result.Add(c);
                }
            }

            return result;
        }

        private async Task<List<PlanSelect>> DownloadSeminarSettings(Setting setting)
        {
            var html = await this.MakeWebRequest(PlanForStudent);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode divHtml;
            if (setting.Params.se1)
            {
                divHtml = doc.GetElementbyId("se1");
            }
            else if (setting.Params.se2)
            {
                divHtml = doc.GetElementbyId("se2");
            }
            else if (setting.Params.sel)
            {
                divHtml = doc.GetElementbyId("sel");
            }
            else
            {
                return null;
            }

            var options = divHtml.Descendants("option").Skip(1);

            options = setting.Symbol[1] == 'I' ? options.Where(x => x.GetAttributeValue("class", string.Empty) == "inf") : options.Where(x => x.GetAttributeValue("class", string.Empty) == "mat");

            return options.Select(option => new PlanSelect { LinkSuffix = option.GetAttributeValue("value", string.Empty), Name = option.InnerText }).ToList();
        }

        private async Task<List<PlanSelect>> DownloadFacultySettings(Setting setting)
        {
            var html = await this.MakeWebRequest(PlanForStudent);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode divHtml;
            if (setting.Params.fak)
            {
                divHtml = doc.GetElementbyId("fak");
            }
            else if (setting.Params.fam)
            {
                divHtml = doc.GetElementbyId("fam");
            }
            else if (setting.Params.fal)
            {
                divHtml = doc.GetElementbyId("fal");
            }
            else
            {
                return null;
            }

            var options = divHtml.Descendants("option").Skip(1);

            options = setting.Symbol[1] == 'I' ? options.Where(x => x.GetAttributeValue("class", string.Empty) == "inf") : options.Where(x => x.GetAttributeValue("class", string.Empty) == "mat");

            return options.Select(option => new PlanSelect { LinkSuffix = option.GetAttributeValue("value", string.Empty), Name = option.InnerText }).ToList();
        }
    }
}
