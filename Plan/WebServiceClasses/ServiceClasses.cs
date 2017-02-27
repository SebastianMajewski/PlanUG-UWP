namespace Plan.WebServiceClasses
{
    using System;

    using DataClasses;
    using Enums;

    public class ServiceClasses
    {
        public string Subject { get; set; }

        public string Lecturer { get; set; }

        public Day Day { get; set; }

        public string HourTo { get; set; }

        public string HourFrom { get; set; }

        public string Room { get; set; }

        public ClassesType Type { get; set; }

        public string Comments { get; set; }

        public string DateTo { get; set; }

        public string Group { get; set; }
    }
}
