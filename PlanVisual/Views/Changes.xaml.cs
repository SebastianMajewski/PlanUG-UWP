namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class Changes
    {
        public Changes()
        {
            this.InitializeComponent();
            this.DataContext = new ChangesViewModel();
        }
    }
}
