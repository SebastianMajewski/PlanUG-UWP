namespace Plan.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum NamedClassesType
    {
        [Display(Name = "Laboratorium")]
        Laboratories = 0,
        [Display(Name = "Ćwiczenia")]
        Practices = 1,
        [Display(Name = "Wykład")]
        Lectures = 2,
        [Display(Name = "Seminarium")]
        Seminars = 3,
        [Display(Name = "Fakultet")]
        Faculties = 4,
        [Display(Name = "Praktyki")]
        Internships = 5,
    }
}
