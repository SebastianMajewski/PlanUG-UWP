namespace PlanVisual.Tools
{
    using System;
    using System.Linq;

    using Plan;

    public static class Improver
    {
        public static void ChangesSplit(Change change)
        {
            if (change.Changes.Trim().EndsWith(";"))
            {
                change.Changes = change.Changes.Trim().Remove(change.Changes.Length - 1);
            }

            change.Changes = string.Join(Environment.NewLine, change.Changes.Split(';').Select(x => "- " + x.Trim()));
        }
    }
}
