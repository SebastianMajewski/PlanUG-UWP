namespace PlanService
{
    using System.Collections.Generic;
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
            return this.downloader.DownloadChanges().Result;
        }

        public List<Classes> Seminars()
        {
            return this.downloader.DownloadPlanSeminars().Result;
        }

        public List<Classes> Faculties()
        {
            return this.downloader.DownloadPlanFaculty().Result;
        }

        public List<PlanSelect> StudiesSelects()
        {
            return this.downloader.DownloadPlanForStudiesOptions().Result;
        }

        public List<Classes> PlanForStudies(PlanSelect select)
        {
            return this.downloader.DownloadPlanForStudies(select).Result;
        }
    }
}
