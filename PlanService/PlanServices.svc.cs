namespace PlanService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Activation;

    using DataClasses;

    using Downloaders;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PlanServices : IPlanServices
    {
        private readonly LessonPlanDataDownloader downloader = new LessonPlanDataDownloader();

        public List<Change> Changes()
        {
            try
            {
                return this.downloader.DownloadChanges().Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault() ?? new Exception();
            } 
        }

        public List<Classes> Seminars()
        {
            try
            {
                return this.downloader.DownloadPlanSeminars().Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault() ?? new Exception();
            }
        }

        public List<Classes> Faculties()
        {
            try
            {
                return this.downloader.DownloadPlanFaculty().Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault() ?? new Exception();
            } 
        }

        public List<PlanSelect> StudiesSelects()
        {
            try
            {
                return this.downloader.DownloadPlanForStudiesOptions().Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault() ?? new Exception();
            } 
        }

        public List<Classes> PlanForStudies(PlanSelect select)
        {
            try
            {
                return this.downloader.DownloadPlanForStudies(select).Result;
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault() ?? new Exception();
            } 
        }
    }
}
