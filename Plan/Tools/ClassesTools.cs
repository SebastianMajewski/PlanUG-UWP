namespace Plan.Tools
{
    using System;
    using DataClasses;
    using Enums;

    public static class ClassesTools
    {
        public static ClassesTypeObject ToClassesTypeObject(this ClassesType type)
        {
            return new ClassesTypeObject { Type = type, Name = type.ToDisplayString() };
        }
    }
}
