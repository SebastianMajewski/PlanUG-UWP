namespace PlanService.DataClasses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PlanForStudentSetting
    {
        [DataMember]
        public string Symbol { get; set; }

        [DataMember]
        public string Group { get; set; }

        [DataMember]
        public string Lectorate { get; set; }

        [DataMember]
        public string Seminar { get; set; }

        [DataMember]
        public string Speciality { get; set; }

        [DataMember]
        public List<string> Faculties { get; set; }

        [DataMember]
        public string SeminarPrefix { get; set; }

        [DataMember]
        public string FacultyPrefix { get; set; }
    }
}