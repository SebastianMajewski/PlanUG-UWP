namespace PlanVisual.Views
{
    using PlanVisual.ViewModels;

    public sealed partial class ForStudy
    {
        public ForStudy()
        {
            this.InitializeComponent();
            this.DataContext = new StudyViewModel();
        }
    }
}
