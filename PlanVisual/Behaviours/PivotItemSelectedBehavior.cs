namespace PlanVisual.Behaviours
{
    using System.Windows.Input;
    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class PivotItemSelectedBehavior : Behavior<PivotItem>
    {
        public static readonly DependencyProperty SelectedCommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(PivotItemSelectedBehavior), null);

        public ICommand Command
        {
            get
            {
                return (ICommand)this.GetValue(SelectedCommandProperty);
            }

            set
            {
                this.SetValue(SelectedCommandProperty, value);
            }
        }
    }
}
