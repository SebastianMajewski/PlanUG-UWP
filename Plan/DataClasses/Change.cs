﻿namespace Plan.DataClasses
{
    public class Change
    {
        public string Group { get; set; }

        public string Lecturer { get; set; }

        public string Subject { get; set; }

        public ClassesTypeObject ClassesType { get; set; }

        public string Changes { get; set; }
    }
}