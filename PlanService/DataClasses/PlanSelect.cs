namespace PlanService.DataClasses
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PlanSelect
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LinkSuffix { get; set; }
    }
}