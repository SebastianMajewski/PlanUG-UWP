namespace PlanVisual.Views
{
    using System.Collections.Generic;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Plan.DataClasses;
    using Plan.PlanServiceReference;
    using Plan.Service;
    using Tools;
    using ViewModels;

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();
            //this.G();
        }

        private async void G()
        {
            
            var g = await new ServiceConnection().GetPlanForStudies(new PlanSelect { LinkSuffix = "?grupa=3I" });
            var grid = new PlanGrid(g).Grid;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.HorizontalAlignment = HorizontalAlignment.Center;
            this.Content = new ScrollViewer
            {
                Content = grid,
                HorizontalScrollMode = ScrollMode.Enabled,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Visible
            };
        }
    }
}
