namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class Seminars
    {
        public Seminars()
        {
            this.InitializeComponent();
            this.DataContext = new SeminarViewModel();
        }
    }
}
