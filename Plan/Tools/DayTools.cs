namespace Plan.Tools
{
    using DataClasses;
    using Enums;

    public static class DayTools
    {
        public static DayObject ToDayObject(this Day day)
        {
            return new DayObject { Day = day, Name = day.ToDisplayString() };
        }
    }
}
