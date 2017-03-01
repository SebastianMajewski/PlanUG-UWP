namespace PlanVisual.Controls
{
    using Windows.UI.Xaml;

    public sealed partial class PlanGridHeader
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(PlanGridHeader), null);

        public PlanGridHeader()
        {
            this.InitializeComponent();
        }

        public string Text
        {
            get
            {
                return (string)this.GetValue(TextProperty);
            }

            set
            {
                this.SetValue(TextProperty, value);
            }
        }
    }
}
