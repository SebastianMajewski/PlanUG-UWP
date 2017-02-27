namespace Plan.Service
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataClasses;

    public interface IServiceConnection
    {
        Task<List<Change>> GetChanges();

        Task<List<Classes>> GetPlanFaculty();

        Task<List<Classes>> GetPlanForStudent(PlanForStudentSetting setting);

        Task<List<Classes>> GetPlanForStudies(PlanSelect so);

        Task<List<PlanSelect>> GetPlanForStudiesOptions();

        Task<List<Classes>> GetPlanSeminars();

        Task<List<Setting>> GetSettings();
    }
}