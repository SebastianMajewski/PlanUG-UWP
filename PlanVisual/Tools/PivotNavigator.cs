namespace PlanVisual.Tools
{
    using System.Collections.Generic;

    using Windows.UI.Xaml.Controls;

    using PlanVisual.Controls;

    public class PivotNavigator
    {
        private static PivotNavigator instance;

        private PivotNavigator()
        {           
            this.Items = new List<NamedPivotItem>();
        }

        public static PivotNavigator Instance => instance ?? (instance = new PivotNavigator());

        public List<NamedPivotItem> Items { get; set; }

        public Pivot Pivot { get; set; }

        public void NavigateToItem(NamedPivotItem item)
        {
            this.Pivot.SelectedItem = item;
        }
    }
}
