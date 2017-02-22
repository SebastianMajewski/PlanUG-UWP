namespace Plan
{
    using System.Collections.Generic;

    public class PlanForStudentSetting
    {
        public string Symbol { get; set; }

        public string Group { get; set; }

        public string Lectorate { get; set; }

        public string Seminar { get; set; }

        public string Speciality { get; set; }

        public List<string> Faculties { get; set; }

        public string SeminarPrefix { get; set; }

        public string FacultyPrefix { get; set; }
    }
}