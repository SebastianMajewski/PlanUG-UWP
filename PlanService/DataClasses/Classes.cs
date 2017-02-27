namespace PlanService.DataClasses
{
    using System;
    using System.Runtime.Serialization;

    using global::PlanService.Enums;

    [DataContract]
    public class Classes
    {
        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Lecturer { get; set; }

        [DataMember]
        public Day Day { get; set; }

        [DataMember]
        public string HourFrom
        {
            get
            {
                return this.Hours?.TimeFrom?.ToString(@"c");
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.Hours.TimeFrom = null;
                }
                else
                {
                    this.Hours.TimeFrom = TimeSpan.Parse(value);
                }
            }
        }

        [DataMember]
        public string HourTo
        {
            get
            {
                return this.Hours?.TimeTo?.ToString(@"c");
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.Hours.TimeTo = null;
                }
                else
                {
                    this.Hours.TimeTo = TimeSpan.Parse(value);
                }
            }
        }

        public TimeInterval Hours { get; set; }

        [DataMember]
        public string Room { get; set; }

        [DataMember]
        public ClassesType Type { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public string DateTo { get; set; }

        [DataMember]
        public string Group { get; set; }

        public bool EqualClass(Classes c)
        {
            if (this.Subject == c.Subject && this.Group == c.Group && this.Type.Equals(c.Type) && this.Comments == c.Comments
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
                if (c.Hours.TimeTo == null)
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