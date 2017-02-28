namespace PlanService.Exceptions
{
    using System;
    using System.Runtime.Serialization;
    using Enums;

    using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;

    [DataContract]
    public class ServiceFault
    {
        public ServiceFault(ErrorType type)
        {
            this.Type = type;
        }

        public ServiceFault(ErrorType type, Exception e)
        {
            this.Message = e.Message;
            this.InvarianString = e.ToInvariantString();
            this.Type = type;
        }

        [DataMember]
        public ErrorType Type { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string InvarianString { get; set; }
    }
}