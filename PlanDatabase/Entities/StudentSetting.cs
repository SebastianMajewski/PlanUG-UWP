namespace PlanDatabase.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    using SQLite.Net.Attributes;

    public class StudentSetting
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

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
                return this.FacultiesString?.Split('#').ToList();
            }

            set
            {
                this.FacultiesString = string.Join("#", value);
            }
        }

        public string SeminarPrefix { get; set; }

        public string FacultyPrefix { get; set; }

        public string FacultiesString { get; set; }
    }
}
