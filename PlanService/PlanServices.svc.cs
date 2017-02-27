namespace PlanService
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using DataClasses;
    using Downloaders;

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PlanServices : IPlanServices
    {
        public List<Change> Changes()
        {
            try
            {
                return LessonPlanDataDownloader.Instance.DownloadChanges().Result;
            }
            catch (Exception)
            {
                return new List<Change>();
            }
        }

        public List<Classes> Seminars()
        {
            try
            {
                return LessonPlanDataDownloader.Instance.DownloadPlanSeminars().Result;
            }
            catch (Exception)
            {
                return new List<Classes>();
            }
}

        public List<Classes> Faculties()
        {
            try
            {
                return LessonPlanDataDownloader.Instance.DownloadPlanFaculty().Result;
            }
            catch (Exception)
            {
                return new List<Classes>();
            }
        }

        public List<PlanSelect> StudiesSelects()
        {
            try
            {
                return LessonPlanDataDownloader.Instance.DownloadPlanForStudiesOptions().Result;
            }
            catch (Exception)
            {
                return new List<PlanSelect>();
            }
        }

        public List<Classes> PlanForStudies(PlanSelect select)
        {
            try
            {
                return LessonPlanDataDownloader.Instance.DownloadPlanForStudies(select).Result;
            }
            catch (Exception)
            {
                return new List<Classes>();
            }
        }
    }
}
