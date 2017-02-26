namespace Plan.DataClasses
{
    using System;

    public class TimeInterval : IComparable
    {
        public TimeSpan TimeFrom { get; set; }

        public TimeSpan TimeTo { get; set; }

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
            return this.TimeFrom.ToString(@"hh\:mm") + (this.TimeTo != default(TimeSpan) ? " - " + this.TimeTo.ToString(@"hh\:mm") : string.Empty);
        }

        public int CompareTo(object obj)
        {
            var o = obj as TimeInterval;
            if (o != null)
            {
                var comp = this.TimeFrom.CompareTo(o.TimeFrom);
                if (comp == 0)
                {
                    if (this.TimeTo == default(TimeSpan) && o.TimeTo == default(TimeSpan))
                    {
                        return 0;
                    }
                    else if (this.TimeTo == default(TimeSpan))
                    {
                        return -1;
                    }
                    else if (o.TimeTo == default(TimeSpan))
                    {
                        return 1;
                    }
                    else
                    {
                        return this.TimeTo.CompareTo(o.TimeTo);
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