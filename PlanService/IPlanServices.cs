namespace PlanService
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using DataClasses;

    using PlanService.Exceptions;

    [ServiceContract]
    public interface IPlanServices
    {
        [OperationContract]
        [WebGet(UriTemplate = "Changes")]
        [FaultContract(typeof(ServiceFault))]
        List<Change> Changes();

        [OperationContract]
        [WebGet(UriTemplate = "Seminars")]
        [FaultContract(typeof(ServiceFault))]
        List<Classes> Seminars();

        [OperationContract]
        [WebGet(UriTemplate = "Faculties")]
        [FaultContract(typeof(ServiceFault))]
        List<Classes> Faculties();

        [OperationContract]
        [WebGet(UriTemplate = "StudiesSelects")]
        [FaultContract(typeof(ServiceFault))]
        List<PlanSelect> StudiesSelects();

        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "PlanForStudies")]
        List<Classes> PlanForStudies(PlanSelect select);
    }
}
