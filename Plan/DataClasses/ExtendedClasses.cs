namespace Plan.DataClasses
{
    using System;

    public class ExtendedClasses
    {
        public ExtendedClasses()
        {   
        }

        public ExtendedClasses(int associatedId)
        {
            this.AssociatedId = associatedId;
        }

        public int? AssociatedId { get; private set; }

        public string Subject { get; set; }

        public string Lecturer { get; set; }

        public DayObject Day { get; set; }

        public TimeInterval Hours { get; set; }

        public string Room { get; set; }

        public ClassesTypeObject Type { get; set; }

        public string Comments { get; set; }

        public string DateTo { get; set; }

        public string Group { get; set; }

        public TimeSpan? StartsAt => this.Hours.TimeFrom;

        public bool IsUserDefined { get; set; }
    }
}