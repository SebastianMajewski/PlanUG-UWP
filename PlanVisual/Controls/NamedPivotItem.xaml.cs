namespace PlanVisual.Controls
{
    using Windows.UI.Xaml;

    public partial class NamedPivotItem
    {
        public static readonly DependencyProperty ItemNameProperty = DependencyProperty.Register("ItemName", typeof(string), typeof(NamedPivotItem), null);

        public NamedPivotItem()
        {
            this.InitializeComponent();
        }

        public string ItemName
        {
            get
            {
                return (string)this.GetValue(ItemNameProperty);
            }

            set
            {
                this.SetValue(ItemNameProperty, value);
            }
        }
    }
}
