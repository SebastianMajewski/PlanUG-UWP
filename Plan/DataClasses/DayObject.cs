namespace Plan.DataClasses
{
    using System;
    using Plan.Enums;

    public class DayObject : IComparable
    {
        public string Name { get; set; }

        public NamedDay Day { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            var o = obj as DayObject;
            if (o != null)
            {
                return this.Day.CompareTo(o.Day);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override bool Equals(object obj)
        {
            var o = obj as DayObject;
            if (o != null && o.Day == this.Day)
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
                return ((this.Name?.GetHashCode() ?? 0) * 397) ^ (int)this.Day;
            }
        }
    }
}