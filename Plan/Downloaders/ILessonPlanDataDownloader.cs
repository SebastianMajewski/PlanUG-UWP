namespace Plan.Downloaders
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataClasses;

    public interface ILessonPlanDataDownloader
    {
        event Action<Exception> ErrorOccured;

        Task<List<Change>> DownloadChanges();

        Task<List<Classes>> DownloadPlanFaculty();

        Task<List<Classes>> DownloadPlanForStudent(PlanForStudentSetting setting);

        Task<List<Classes>> DownloadPlanForStudies(PlanSelect so);

        Task<List<PlanSelect>> DownloadPlanForStudiesOptions();

        Task<List<Classes>> DownloadPlanSeminars();

        Task<List<Setting>> DownloadSettings();

        Task<string> MakeWebRequest(string uri);
    }
}