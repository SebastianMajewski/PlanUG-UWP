namespace PlanService.JsonClasses
{
    using System.Runtime.Serialization;

    using DataClasses;

    public class LessonPlanSettingsJson
    {
        public string name { get; set; }

        public string longname { get; set; }

        public bool fal { get; set; }

        public bool fam { get; set; }

        public bool fak { get; set; }

        public bool se1 { get; set; }

        public bool se2 { get; set; }

        public bool sel { get; set; }

        public bool mon { get; set; }

        public bool hum { get; set; }

        public bool kur { get; set; }

        public GetMethodParams Clone()
        {
            return new GetMethodParams
            {
                fal = this.fal,
                fak = this.fak,
                fam = this.fam,
                hum = this.hum,
                kur = this.kur,
                mon = this.mon,
                se1 = this.se1,
                se2 = this.se2,
                sel = this.sel
            };
        }
    }
}