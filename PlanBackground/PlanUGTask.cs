namespace PlanBackground
{
    using System;
    using System.Linq;
    using PlanDatabase;
    using Windows.ApplicationModel.Background;

    public sealed class PlanUGTask : IBackgroundTask
    {
        private BackgroundTaskDeferral deferral;

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            this.deferral = taskInstance.GetDeferral();
            var repository = new PlanRepository();
            var tc = new TileController();
            var classes = await repository.GetAllUserClasses();
            var today = (from extendedClasses in classes let actualTime = DateTime.UtcNow let dayOfWeek = ((int)actualTime.DayOfWeek + 5) % 6 where (int)extendedClasses.Day.Day == dayOfWeek select extendedClasses).ToList();
            if (today != null && today.Count() != 0)
            {
                var min = today.First();
                foreach (var c in today)
                {
                    if (c.StartsAt - DateTime.UtcNow.TimeOfDay < min.StartsAt - DateTime.UtcNow.TimeOfDay)
                    {
                        min = c;
                    }
                }

                tc.UpdateClasses(new SimpleClasses { Subject = min.Subject, Room = min.Room, Start = min.StartsAt.Value });
            }
            else
            {
                tc.UpdateNormal();
            }
            this.deferral.Complete();
        }
    }
}
