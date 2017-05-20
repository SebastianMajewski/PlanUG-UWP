namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class Settings
    {
        public Settings()
        {
            this.InitializeComponent();
            this.DataContext = new SettingsViewModel();
        }
    }
}
