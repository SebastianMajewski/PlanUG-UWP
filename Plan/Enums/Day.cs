namespace Plan.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum Day
    {
        [Display(Name = "Poniedziałek")]
        Monday = 0,
        [Display(Name = "Wtorek")]
        Tuesday = 1,
        [Display(Name = "Środa")]
        Wednesday = 2,
        [Display(Name = "Czwartek")]
        Thursday = 3,
        [Display(Name = "Piątek")]
        Friday = 4,
        [Display(Name = "Sobota")]
        Saturday = 5,
        [Display(Name = "Niedziela")]
        Sunday = 6
    }
}
