namespace Plan.Tools
{
    using System;
    using DataClasses;
    using Enums;

    using Plan.ServiceReference;

    public static class ClassesTools
    {
        public static ClassesTypeObject ToClassesTypeObject(this ClassesType type)
        {
            var namedtype = (NamedClassesType)type;
            return new ClassesTypeObject { Type = namedtype, Name = namedtype.ToDisplayString() };
        }
    }
}
