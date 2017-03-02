namespace PlanVisual.Helpers
{
    using Windows.UI.Xaml;

    public class BindingProxy : FrameworkElement
    {
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), null);

        public object Data
        {
            get
            {
                return this.GetValue(DataProperty);
            }

            set
            {
                this.SetValue(DataProperty, value);
            }
        }
    }
}
