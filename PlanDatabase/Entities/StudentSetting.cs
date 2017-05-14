namespace PlanDatabase.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using SQLite.Net.Attributes;

    public class StudentSetting
    {
        [Column("Faculties")]
        private string faculties { get; set; }

        [PrimaryKey]
        private int Id { get; } = 0;

        public string Symbol { get; set; }

        public string Group { get; set; }

        public string Lectorate { get; set; }

        public string Seminar { get; set; }

        public string Speciality { get; set; }

        [Ignore]
        public List<string> Faculties
        {
            get
            {
                return this.faculties.Split('#').ToList();
            }

            set
            {
                this.faculties = string.Join("#", value);
            }
        }

        public string SeminarPrefix { get; set; }

        public string FacultyPrefix { get; set; }
    }
}
