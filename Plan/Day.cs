namespace Plan
{
    using System.ComponentModel.DataAnnotations;

    public enum Day
    {
        [Display(Name = "Poniedziałek")]
        Monday,
        [Display(Name = "Wtorek")]
        Tuesday,
        [Display(Name = "Środa")]
        Wednesday,
        [Display(Name = "Czwartek")]
        Thursday,
        [Display(Name = "Piątek")]
        Friday,
        [Display(Name = "Sobota")]
        Saturday,
        [Display(Name = "Niedziela")]
        Sunday
    }
}
