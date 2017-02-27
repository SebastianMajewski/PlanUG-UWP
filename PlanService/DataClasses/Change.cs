namespace PlanService.DataClasses
{
    using System.Runtime.Serialization;
    using Enums;

    [DataContract]
    public class Change
    {
        [DataMember]
        public string Group { get; set; }

        [DataMember]
        public string Lecturer { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public ClassesType ClassesType { get; set; }

        [DataMember]
        public string Changes { get; set; }
    }
}