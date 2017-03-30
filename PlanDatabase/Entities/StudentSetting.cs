namespace PlanDatabase.Entities
{
    using System.Collections.Generic;

    using SQLite.Net.Attributes;

    public class StudentSetting
    {
        [PrimaryKey]
        private int Id { get; } = 0;

        public string Symbol { get; set; }

        public string Group { get; set; }

        public string Lectorate { get; set; }

        public string Seminar { get; set; }

        public string Speciality { get; set; }

        public virtual List<string> Faculties { get; set; }

        public string SeminarPrefix { get; set; }

        public string FacultyPrefix { get; set; }
    }
}
