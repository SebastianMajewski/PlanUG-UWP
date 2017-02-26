namespace Plan.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ClassesType
    {
        [Display(Name = "Laboratorium")]
        Laboratories,
        [Display(Name = "Ćwiczenia")]
        Practices,
        [Display(Name = "Wykład")]
        Lectures,
        [Display(Name = "Seminarium")]
        Seminars,
        [Display(Name = "Fakultet")]
        Faculties,
    }
}
