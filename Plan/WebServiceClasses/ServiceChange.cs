namespace Plan.WebServiceClasses
{
    using Plan.Enums;

    public class ServiceChange
    {
        public string Group { get; set; }

        public string Lecturer { get; set; }

        public string Subject { get; set; }

        public ClassesType ClassesType { get; set; }

        public string Changes { get; set; }
    }
}