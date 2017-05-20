namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class ForStudy
    {
        public ForStudy()
        {
            this.InitializeComponent();
            this.DataContext = new StudyViewModel();
        }
    }
}
