namespace PlanVisual.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Markup;

    [ContentProperty(Name = "UnderContent")]
    public sealed partial class BusyIndicator
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(BusyIndicator), null);
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(BusyIndicator), null);
        public static readonly DependencyProperty UnderContentProperty = DependencyProperty.Register("UnderContent", typeof(UIElement), typeof(BusyIndicator), null);

        public BusyIndicator()
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

        public bool IsActive
        {
            get
            {
                return (bool)this.GetValue(IsActiveProperty);
            }

            set
            {
                this.SetValue(IsActiveProperty, value);
            }
        }

        public UIElement UnderContent
        {
            get
            {
                return (UIElement)this.GetValue(UnderContentProperty);
            }

            set
            {
                this.SetValue(UnderContentProperty, value);
            }
        }
    }
}
