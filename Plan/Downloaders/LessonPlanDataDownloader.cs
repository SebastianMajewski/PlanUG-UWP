namespace Plan.Downloaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    using DataClasses;
    using Exceptions;
    using HtmlAgilityPack;
    using Newtonsoft.Json;
    using Tools;
    using WebServiceClasses;
    using Windows.Web.Http;

    public class LessonPlanDataDownloader : ILessonPlanDataDownloader
    {
        private const string ServiceMain = @"http://planugservice.azurewebsites.net/PlanServices.svc/";
        private const string Changes = @"Changes";
        private const string Seminars = @"Seminars";
        private const string Faculty = @"Faculties";


        private const string PlanMain = @"https://inf.ug.edu.pl/plan/index.php";
        private const string PlanForStudent = @"https://inf.ug.edu.pl/plan/index.php?dialog=student";
        private const string PlanForStudies = @"https://inf.ug.edu.pl/plan/index.php?dialog=grupa";
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
                    var request = await http.GetBufferAsync(new Uri(uri));
                    return Encoding.UTF8.GetString(request.ToArray());
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
            var json = await this.MakeWebRequest(ServiceMain + Faculty);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Classes>> DownloadPlanSeminars()
        {
            var json = await this.MakeWebRequest(ServiceMain + Seminars);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Classes>> DownloadPlanFaculty()
        {
            var json = await this.MakeWebRequest(ServiceMain + Faculty);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Change>> DownloadChanges()
        {
            var json = await this.MakeWebRequest(ServiceMain + Changes);
            var list = JsonConvert.DeserializeObject<List<ServiceChange>>(json);
            return list.Select(this.ToChange).ToList();
        }

        public async Task<List<Setting>> DownloadSettings()
        {
            throw new NotImplementedException();
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
            return new List<Classes>();
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

        private Classes ToClasses(ServiceClasses classes)
        {
            return new Classes
            {
                Lecturer = classes.Lecturer,
                Type = classes.Type.ToClassesTypeObject(),
                Group = classes.Group,
                Subject = classes.Subject,
                Day = classes.Day.ToDayObject(),
                Comments = classes.Comments,
                DateTo = classes.DateTo,
                Hours = this.ToTimeInterval(classes.HourFrom, classes.HourTo),
                Room = classes.Room
            };
        }

        private TimeInterval ToTimeInterval(string from, string to)
        {
            var interval = new TimeInterval();
            if (string.IsNullOrEmpty(from))
            {
                interval.TimeFrom = null;
            }
            else
            {
                interval.TimeFrom = TimeSpan.Parse(from);
            }

            if (string.IsNullOrEmpty(to))
            {
                interval.TimeTo = null;
            }
            else
            {
                interval.TimeTo = TimeSpan.Parse(to);
            }

            return interval;
        }

        private Change ToChange(ServiceChange change)
        {
            return new Change
            {
                Lecturer = change.Lecturer,
                ClassesType = change.ClassesType.ToClassesTypeObject(),
                Group = change.Group,
                Changes = change.Changes,
                Subject = change.Subject
            };
        }
    }
}
