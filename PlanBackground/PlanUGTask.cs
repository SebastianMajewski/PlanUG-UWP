namespace PlanBackground
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Plan.DataClasses;
    using PlanDatabase;
    using Windows.ApplicationModel.Background;

    public sealed class PlanUGTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferral;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            try
            {
                this.deferral = taskInstance?.GetDeferral();
                var repository = new PlanRepository();
                var tc = new TileController();
                var classes = await repository.GetAllUserClasses();
                var nearest = this.FindNearest(classes);
                if (nearest != null)
                {
                    tc.UpdateClasses(new SimpleClasses { Subject = nearest.Subject, Room = nearest.Room, Start = nearest.StartsAt ?? new TimeSpan() });
                }
                else
                {
                    tc.UpdateNormal();
                }

                this.deferral?.Complete();
            }
            catch
            {
                // ignored
            }
        }

        private ExtendedClasses FindNearest(List<ExtendedClasses> classes)
        {
            var today = (from extendedClasses in classes let actualTime = DateTime.UtcNow let dayOfWeek = ((int)actualTime.DayOfWeek + 5) % 6 where (int)extendedClasses.Day.Day == dayOfWeek select extendedClasses).Where(x => x.StartsAt >= DateTime.UtcNow.TimeOfDay).ToList();
            if (today != null && today.Count > 0)
            {
                return today.First(x => x.StartsAt == today.Select(y => y.StartsAt).Min());
            }

            var tommorow = (from extendedClasses in classes let actualTime = DateTime.UtcNow let dayOfWeek = ((int)actualTime.DayOfWeek + 6) % 6 where (int)extendedClasses.Day.Day == dayOfWeek select extendedClasses).ToList();
            if (tommorow != null && tommorow.Count > 0)
            {
                return tommorow.First(x => x.StartsAt == tommorow.Select(y => y.StartsAt).Min());
            }

            return null;
        }
    }
}
