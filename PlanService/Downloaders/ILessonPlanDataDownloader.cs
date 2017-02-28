namespace PlanService.Downloaders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataClasses;

    public interface ILessonPlanDataDownloader
    {
        Task<List<Change>> DownloadChanges();

        Task<List<Classes>> DownloadPlanFaculty();

        Task<List<Classes>> DownloadPlanForStudent(PlanForStudentSetting setting);

        Task<List<Classes>> DownloadPlanForStudies(PlanSelect so);

        Task<List<PlanSelect>> DownloadPlanForStudiesOptions();

        Task<List<Classes>> DownloadPlanSeminars();

        Task<List<Setting>> DownloadSettings();
    }
}