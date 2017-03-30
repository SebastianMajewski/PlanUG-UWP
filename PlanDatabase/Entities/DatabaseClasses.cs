namespace PlanDatabase.Entities
{
    using System;
    using Plan.PlanServiceReference;
    using SQLite.Net.Attributes;

    public class DatabaseClasses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Subject { get; set; }

        public string Lecturer { get; set; }

        public Day Day { get; set; }

        public TimeSpan? TimeFrom { get; set; }

        public TimeSpan? TimeTo { get; set; }

        public string Room { get; set; }

        public ClassesType Type { get; set; }

        public string Comments { get; set; }

        public string DateTo { get; set; }

        public string Group { get; set; }
    }
}
