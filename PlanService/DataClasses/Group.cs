namespace PlanService.DataClasses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Group
    {
        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public List<string> Lectorates { get; set; }
    }
}