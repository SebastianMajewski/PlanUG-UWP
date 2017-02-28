namespace Plan.Tools
{

    using DataClasses;
    using Enums;
    using PlanServiceReference;

    public static class ClassesTools
    {
        public static ClassesTypeObject ToClassesTypeObject(this ClassesType type)
        {
            var namedtype = (NamedClassesType)type;
            return new ClassesTypeObject { Type = namedtype, Name = namedtype.ToDisplayString() };
        }
    }
}
