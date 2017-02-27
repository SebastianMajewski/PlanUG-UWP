namespace PlanService
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using DataClasses;

    [ServiceContract]
    public interface IPlanServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "Changes")]
        List<Change> Changes();

        [OperationContract]
        [WebGet(UriTemplate = "Seminars")]
        List<Classes> Seminars();

        [OperationContract]
        [WebGet(UriTemplate = "Faculties")]
        List<Classes> Faculties();
    }
}
