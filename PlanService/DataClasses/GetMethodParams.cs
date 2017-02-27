namespace PlanService.DataClasses
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GetMethodParams
    {
        [DataMember]
        public bool fal { get; set; }

        [DataMember]
        public bool fam { get; set; }

        [DataMember]
        public bool fak { get; set; }

        [DataMember]
        public bool se1 { get; set; }

        [DataMember]
        public bool se2 { get; set; }

        [DataMember]
        public bool sel { get; set; }

        [DataMember]
        public bool mon { get; set; }

        [DataMember]
        public bool hum { get; set; }

        [DataMember]
        public bool kur { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}