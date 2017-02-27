namespace PlanService.DataClasses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Specialization
    {
        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Group> Groups { get; set; }
    }
}