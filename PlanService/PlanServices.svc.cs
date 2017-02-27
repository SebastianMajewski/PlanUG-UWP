namespace PlanService
{
    using System.Collections.Generic;
    using System.ServiceModel.Activation;

    using DataClasses;
    using Downloaders;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PlanServices : IPlanServices
    {
        public List<Change> Changes()
        {
            return LessonPlanDataDownloader.Instance.DownloadChanges().Result;
        }

        public List<Classes> Seminars()
        {
            return LessonPlanDataDownloader.Instance.DownloadPlanSeminars().Result;
        }

        public List<Classes> Faculties()
        {
            return LessonPlanDataDownloader.Instance.DownloadPlanFaculty().Result;
        }
    }
}
