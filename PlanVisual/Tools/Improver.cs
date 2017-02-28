namespace PlanVisual.Tools
{
    using System;
    using System.Linq;
    using Plan.DataClasses;

    public static class Improver
    {
        public static void ChangesSplit(ExtendedChange change)
        {
            if (change.Changes.Trim().EndsWith(";"))
            {
                change.Changes = change.Changes.Trim().Remove(change.Changes.Length - 1);
            }

            change.Changes = string.Join(Environment.NewLine, change.Changes.Split(';').Select(x => "- " + x.Trim()));
        }

        public static void LecturerSplit(ExtendedClasses classes)
        {
            if (classes.Lecturer.Trim().EndsWith("+"))
            {
                classes.Lecturer = classes.Lecturer.Trim().Remove(classes.Lecturer.Length - 1);
            }

            classes.Lecturer = string.Join(Environment.NewLine, classes.Lecturer.Split('+'));
        }

        public static void LecturerSplit(ExtendedChange change)
        {
            if (change.Lecturer.Trim().EndsWith("+"))
            {
                change.Lecturer = change.Lecturer.Trim().Remove(change.Lecturer.Length - 1);
            }

            change.Lecturer = string.Join(Environment.NewLine, change.Lecturer.Split('+'));
        }
    }
}
