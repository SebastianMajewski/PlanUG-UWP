namespace Plan.DataClasses
{
    using System.Collections.Generic;

    public class Setting
    {
        public string Symbol { get; set; }

        public string Name { get; set; }

        public GetMethodParams Params { get; set; }

        public List<Specialization> Specjalizations { get; set; }

        public List<string> Lectorates { get; set; }

        public List<PlanSelect> Seminars { get; set; }

        public List<PlanSelect> Faculties { get; set; }
    }
}