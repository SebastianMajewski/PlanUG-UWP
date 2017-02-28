namespace Plan.DataClasses
{
    using System;

    using Enums;

    public class ClassesTypeObject : IComparable
    {
        public string Name { get; set; }

        public NamedClassesType Type { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            var o = obj as ClassesTypeObject;
            if (o != null)
            {
                return this.Type.CompareTo(o.Type);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override bool Equals(object obj)
        {
            var o = obj as ClassesTypeObject;
            if (o != null && o.Type == this.Type)
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
                return ((this.Name?.GetHashCode() ?? 0) * 397) ^ (int)this.Type;
            }
        }
    }
}
