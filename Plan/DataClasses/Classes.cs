namespace Plan.DataClasses
{
    using System;

    public class Classes
    {
        public string Subject { get; set; }

        public string Lecturer { get; set; }

        public DayObject Day { get; set; }

        public TimeInterval Hours { get; set; }

        public string Room { get; set; }

        public string Type { get; set; }

        public string Comments { get; set; }
        
        public string DateTo { get; set; }

        public string Group { get; set; }

        public bool EqualClass(Classes c)
        {
            if (this.Subject == c.Subject && this.Group == c.Group && this.Type == c.Type && this.Comments == c.Comments
                && this.DateTo == c.DateTo && this.Day.Equals(c.Day) && this.Lecturer == c.Lecturer && this.Room == c.Room)
            {
                return true;
            }

            return false;
        }

        public void Merge(Classes c)
        {
            if (this.EqualClass(c))
            {
                if (c.Hours.TimeTo == default(TimeSpan))
                {
                    var lower = this.Hours.TimeFrom < c.Hours.TimeFrom ? this.Hours.TimeFrom : c.Hours.TimeFrom;
                    var greater = this.Hours.TimeFrom > c.Hours.TimeFrom ? this.Hours.TimeFrom : c.Hours.TimeFrom;
                    this.Hours.TimeFrom = lower;
                    this.Hours.TimeTo = greater;
                }
                else
                {
                    this.Hours.TimeFrom = this.Hours.TimeFrom < c.Hours.TimeFrom ? this.Hours.TimeFrom : c.Hours.TimeFrom;
                    this.Hours.TimeTo = this.Hours.TimeTo > c.Hours.TimeTo ? this.Hours.TimeTo : c.Hours.TimeTo;
                }
            }
        }
    }
}