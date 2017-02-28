namespace PlanService.Tools
{
    using System;
    using Enums;
    using Plan.Tools;

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
                case "w":
                    return ClassesType.Lectures;
                case "seminarium":
                case "sem":
                    return ClassesType.Seminars;
                case "fakultet":
                case "fak":
                    return ClassesType.Faculties;
                case "praktyki":
                case "prak":
                    return ClassesType.Internships;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
