namespace PlanVisual.Views
{
    using ViewModels;

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();
        }
    }
}
