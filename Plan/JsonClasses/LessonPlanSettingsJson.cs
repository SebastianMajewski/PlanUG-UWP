namespace Plan.JsonClasses
{
    using DataClasses;

    internal class LessonPlanSettingsJson : GetMethodParams
    {
        public string name { get; set; }

        public string longname { get; set; }
    }
}