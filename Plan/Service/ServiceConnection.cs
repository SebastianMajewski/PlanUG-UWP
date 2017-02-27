namespace Plan.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataClasses;
    using Newtonsoft.Json;
    using RestClient;
    using Tools;
    using WebServiceClasses;

    public class ServiceConnection : IServiceConnection
    {
        private const string ServiceMain = @"http://planugservice.azurewebsites.net/PlanServices.svc/";
        private const string Changes = @"Changes";
        private const string Seminars = @"Seminars";
        private const string Faculty = @"Faculties";
        private const string ForStudies = @"PlanForStudies";
        private const string StudiesSelects = @"StudiesSelects";

        private readonly IRestClient client;

        public ServiceConnection(IRestClient client)
        {
            this.client = client;
        }

        public async Task<List<PlanSelect>> GetPlanForStudiesOptions()
        {
            var json = await this.client.GetRequest(ServiceMain + StudiesSelects);
            return JsonConvert.DeserializeObject<List<PlanSelect>>(json);
        }

        public async Task<List<Classes>> GetPlanForStudies(PlanSelect so)
        {         
            var json = await this.client.PostRequest(ServiceMain + ForStudies, so);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Classes>> GetPlanSeminars()
        {
            var json = await this.client.GetRequest(ServiceMain + Seminars);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Classes>> GetPlanFaculty()
        {
            var json = await this.client.GetRequest(ServiceMain + Faculty);
            var list = JsonConvert.DeserializeObject<List<ServiceClasses>>(json);
            return list.Select(this.ToClasses).ToList();
        }

        public async Task<List<Change>> GetChanges()
        {
            var json = await this.client.GetRequest(ServiceMain + Changes);
            var list = JsonConvert.DeserializeObject<List<ServiceChange>>(json);
            return list.Select(this.ToChange).ToList();
        }

        public async Task<List<Setting>> GetSettings()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Classes>> GetPlanForStudent(PlanForStudentSetting setting)
        {
            throw new NotImplementedException();
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
