namespace Plan.Tools
{
    using System;
    using DataClasses;
    using Enums;

    public static class ClassesTools
    {
        public static ClassesType NormalizeClassesType(this string type)
        {
            var nday = type.ToLower().RemoveDiacritics();
            switch (nday)
            {
                case "cwiczenia":
                case "cw":
                    return ClassesType.Practices;
                case "laboratoria":
                case "laboratorium":
                case "lab":
                    return ClassesType.Laboratories;
                case "wyklad":
                case "wyk":
                    return ClassesType.Lectures;
                case "seminarium":
                case "sem":
                    return ClassesType.Seminars;
                case "fakultet":
                case "fak":
                    return ClassesType.Faculties;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static ClassesTypeObject ToClassesTypeObject(this ClassesType type)
        {
            return new ClassesTypeObject { Type = type, Name = type.ToDisplayString() };
        }
    }
}
