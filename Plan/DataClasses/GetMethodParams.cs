namespace Plan.DataClasses
{
    public class GetMethodParams
    {
        public bool fal { get; set; }

        public bool fam { get; set; }

        public bool fak { get; set; }

        public bool se1 { get; set; }

        public bool se2 { get; set; }

        public bool sel { get; set; }

        public bool mon { get; set; }

        public bool hum { get; set; }

        public bool kur { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}