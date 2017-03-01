namespace Plan.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Threading.Tasks;
    using DataClasses;
    using PlanServiceReference;
    using Tools;

    public class ServiceConnection : IServiceConnection
    {
        private const string Uri = @"http://planugservice.azurewebsites.net/PlanServices.svc/soap";
        private readonly PlanServicesClient client;

        public ServiceConnection()
        {
            var binding = new BasicHttpBinding { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue };
            var endPoint = new EndpointAddress(new Uri(Uri));
            this.client = new PlanServicesClient(binding, endPoint);
        }

        public async Task<List<PlanSelect>> GetPlanForStudiesOptions()
        {
            return (await this.client.StudiesSelectsAsync()).ToList();
        }

        public async Task<List<ExtendedClasses>> GetPlanForStudies(PlanSelect so)
        {
            var classes = await this.client.PlanForStudiesAsync(so);
            return classes.Select(this.ToExtendedClasses).ToList();
        }

        public async Task<List<ExtendedClasses>> GetPlanSeminars()
        {
            var classes = await this.client.SeminarsAsync();
            return classes.Select(this.ToExtendedClasses).ToList();
        }

        public async Task<List<ExtendedClasses>> GetPlanFaculty()
        {
            var classes = await this.client.FacultiesAsync();
            return classes.Select(this.ToExtendedClasses).ToList();
        }

        public async Task<List<ExtendedChange>> GetChanges()
        {
            var classes = await this.client.ChangesAsync();
            return classes.Select(this.ToExtendedChange).ToList();
        }

        // public async Task<List<Setting>> GetSettings()
        // {
        //     throw new NotImplementedException();
        // }

        // public async Task<List<Classes>> GetPlanForStudent(PlanForStudentSetting setting)
        // {
        //     throw new NotImplementedException();
        // }
        private ExtendedClasses ToExtendedClasses(Classes classes)
        {
            return new ExtendedClasses
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
                interval.TimeTo = TimeSpan.Parse(to) + TimeSpan.FromHours(1);
            }

            return interval;
        }

        private ExtendedChange ToExtendedChange(Change change)
        {
            return new ExtendedChange
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
