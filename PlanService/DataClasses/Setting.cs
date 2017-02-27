namespace PlanService.DataClasses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Setting
    {
        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public GetMethodParams Params { get; set; }

        [DataMember]
        public List<Specialization> Specjalizations { get; set; }

        [DataMember]
        public List<string> Lectorates { get; set; }

        [DataMember]
        public List<PlanSelect> Seminars { get; set; }

        [DataMember]
        public List<PlanSelect> Faculties { get; set; }
    }
}