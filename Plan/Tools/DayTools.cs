namespace Plan.Tools
{
    using DataClasses;
    using Enums;
    using PlanServiceReference;

    public static class DayTools
    {
        public static DayObject ToDayObject(this Day day)
        {
            var namedDay = (NamedDay)day;
            return new DayObject { Day = namedDay, Name = namedDay.ToDisplayString() };
        }
    }
}
