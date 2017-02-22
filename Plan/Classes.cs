namespace Plan
{
    public class Classes
    {
        public string Subject { get; set; }

        public string Lecturer { get; set; }

        public string Day { get; set; }

        public string HourFrom { get; set; }

        public string HourTo { get; set; }

        public string Room { get; set; }

        public string Type { get; set; }

        public string Comments { get; set; }
        
        public string DateTo { get; set; }

        public string Group { get; set; }

        public bool EqualClass(Classes c)
        {
            if (this.Subject == c.Subject && this.Group == c.Group && this.Type == c.Type && this.Comments == c.Comments
                && this.DateTo == c.DateTo && this.Day == c.Day && this.Lecturer == c.Lecturer && this.Room == c.Room)
            {
                return true;
            }

            return false;
        }

        public void Merge(Classes c)
        {
            if (this.EqualClass(c))
            {
                if (string.IsNullOrEmpty(c.HourTo))
                {
                    var tempHour = this.HourFrom;
                    this.HourFrom = this.LowerHour(tempHour, c.HourFrom);
                    this.HourTo = this.GreaterHour(tempHour, c.HourFrom);
                }
                else
                {
                    this.HourFrom = this.LowerHour(this.HourFrom, c.HourFrom);
                    this.HourTo = this.GreaterHour(this.HourTo, c.HourTo);
                }
            }
        }

        private string LowerHour(string hour1, string hour2)
        {
            if (string.IsNullOrEmpty(hour1))
            {
                return hour2;
            }

            if (string.IsNullOrEmpty(hour2))
            {
                return hour1;
            }

            var hour1A = hour1.Replace(" ", string.Empty).Replace("O", "0").Replace("o", "0").Split(':');
            var hour2A = hour2.Replace(" ", string.Empty).Replace("O", "0").Replace("o", "0").Split(':');

            var hour1I = int.Parse(hour1A[0]);
            var hour2I = int.Parse(hour2A[0]);
            var minute1I = int.Parse(hour1A[1]);
            var minute2I = int.Parse(hour2A[1]);

            if (hour1I < hour2I)
            {
                return hour1;
            }
            else if (hour1I > hour2I)
            {
                return hour2;
            }
            else
            {
                if (minute1I < minute2I)
                {
                    return hour1;
                }
                else if (minute1I > minute2I)
                {
                    return hour2;
                }
                else
                {
                    return hour1;
                }
            }
        }

        private string GreaterHour(string hour1, string hour2)
        {
            if (string.IsNullOrEmpty(hour1))
            {
                return hour2;
            }

            if (string.IsNullOrEmpty(hour2))
            {
                return hour1;
            }

            var hour1A = hour1.Replace(" ", string.Empty).Replace("O", "0").Replace("o", "0").Split(':');
            var hour2A = hour2.Replace(" ", string.Empty).Replace("O", "0").Replace("o", "0").Split(':');

            var hour1I = int.Parse(hour1A[0]);
            var hour2I = int.Parse(hour2A[0]);
            var minute1I = int.Parse(hour1A[1]);
            var minute2I = int.Parse(hour2A[1]);

            if (hour1I > hour2I)
            {
                return hour1;
            }
            else if (hour1I < hour2I)
            {
                return hour2;
            }
            else
            {
                if (minute1I > minute2I)
                {
                    return hour1;
                }
                else if (minute1I < minute2I)
                {
                    return hour2;
                }
                else
                {
                    return hour1;
                }
            }
        }
    }
}