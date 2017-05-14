namespace PlanVisual.Views
{
    using PlanVisual.ViewModels;

    public sealed partial class ForStudent
    {
        public ForStudent()
        {
            this.InitializeComponent();
            this.DataContext = new ForStudentViewModel();
        }
    }
}
