namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class Faculties
    {
        public Faculties()
        {
            this.InitializeComponent();
            this.DataContext = new FacultyViewModel();
        }
    }
}
