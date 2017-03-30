namespace Plan.Service
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using DataClasses;

    using Plan.PlanServiceReference;

    using ExtendedChange = Plan.DataClasses.ExtendedChange;
    using ExtendedClasses = Plan.DataClasses.ExtendedClasses;

    public interface IServiceConnection
    {
        Task<List<ExtendedChange>> GetChanges();

        Task<List<ExtendedClasses>> GetPlanFaculty();

        Task<List<ExtendedClasses>> GetPlanForStudent(PlanForStudentSetting setting);

        Task<List<ExtendedClasses>> GetPlanForStudies(PlanSelect so);

        Task<List<PlanSelect>> GetPlanForStudiesOptions();

        Task<List<ExtendedClasses>> GetPlanSeminars();

        Task<List<Setting>> GetSettings();
    }
}