namespace PlanService.DataClasses
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class TimeInterval : IComparable
    {
        [DataMember]
        public TimeSpan? TimeFrom { get; set; }

        [DataMember]
        public TimeSpan? TimeTo { get; set; }

        public override bool Equals(object obj)
        {
            var time = obj as TimeInterval;
            if (time != null && this.TimeFrom == time.TimeFrom && this.TimeTo == time.TimeTo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.TimeFrom.GetHashCode() * 397) ^ this.TimeTo.GetHashCode();
            }
        }

        public override string ToString()
        {
            var timeFrom = this.TimeFrom;
            if (timeFrom != null)
            {
                return timeFrom.Value.ToString(@"hh\:mm") + (this.TimeTo.HasValue ? " - " + this.TimeTo.Value.ToString(@"hh\:mm") : string.Empty);
            }

            return string.Empty;
        }

        public int CompareTo(object obj)
        {
            var o = obj as TimeInterval;
            if (o != null && this.TimeFrom != null && o.TimeFrom != null)
            {
                var comp = this.TimeFrom.Value.CompareTo(o.TimeFrom);
                if (comp == 0)
                {
                    if (this.TimeTo == null && o.TimeTo == null)
                    {
                        return 0;
                    }
                    else if (this.TimeTo == null)
                    {
                        return -1;
                    }
                    else if (o.TimeTo == null)
                    {
                        return 1;
                    }
                    else
                    {
                        return this.TimeTo.Value.CompareTo(o.TimeTo);
                    }
                }
                else
                {
                    return comp;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}