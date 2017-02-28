namespace PlanService.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using PlanService.Enums;

    [DataContract]
    public class ServiceFault
    {
        public ServiceFault(ErrorType type)
        {
            this.Type = type;
        }

        public ServiceFault(ErrorType type, Exception e)
        {
            this.Exception = e;
            this.Type = type;
        }

        [DataMember]
        public ErrorType Type { get; private set; }

        [DataMember]
        public Exception Exception { get; private set; }
    }
}