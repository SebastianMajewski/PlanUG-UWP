namespace PlanBackground
{
    using System;
    using System.Linq;

    using Windows.ApplicationModel.Background;

    public static class BackgroundTask
    {
        private const string TaskName = "PlanUG Notification Updater";
        private const string EntryPoint = "PlanBackground.PlanUGTask";
        private static BackgroundTaskRegistration registration;


        public static async void RunTask()
        {
            var trigger = new TimeTrigger(15, false);
            var requestStatus = await BackgroundExecutionManager.RequestAccessAsync();
            if (requestStatus != BackgroundAccessStatus.AlwaysAllowed)
            {
                var builder = new BackgroundTaskBuilder { Name = TaskName };
                builder.SetTrigger(trigger);
                builder.TaskEntryPoint = EntryPoint;
                registration = builder.Register();
            }
        }

        public static void Unregister()
        {
            if (IsRegistered())
            {
                registration.Unregister(true);
            }
        }

        public static void UnregisterAll()
        {
            foreach (var source in BackgroundTaskRegistration.AllTasks.Where(x => x.Value.Name == TaskName))
            {
                source.Value.Unregister(true);
            }
        }

        public static bool IsRegistered()
        {
            var tasks = BackgroundTaskRegistration.AllTasks;
            return tasks.Any(x => x.Value.Name == TaskName);
        }
    }
}
