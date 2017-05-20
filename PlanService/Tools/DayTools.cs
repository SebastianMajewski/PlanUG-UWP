namespace PlanService.Tools
{
    using System;
    using Enums;

    public static class DayTools
    {
        public static Day NormalizeDay(this string day)
        {
            var nday = day.ToLower().RemoveDiacritics();
            switch (nday)
            {
                case "poniedzialek":
                case "pon":
                    return Day.Monday;
                case "wtorek":
                case "wto":
                case "wt":
                    return Day.Tuesday;
                case "sroda":
                case "sro":
                    return Day.Wednesday;
                case "czwartek":
                case "czw":
                    return Day.Thursday;
                case "piatek":
                case "pia":
                case "pt":
                    return Day.Friday;
                case "sobota":
                case "sob":
                    return Day.Saturday;
                case "niedziela":
                case "nie":
                    return Day.Sunday;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
