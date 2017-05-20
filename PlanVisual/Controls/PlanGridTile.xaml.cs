namespace PlanVisual.Controls
{
    using Plan.DataClasses;
    using Windows.UI.Xaml;

    public sealed partial class PlanGridTile
    {
        public static readonly DependencyProperty ClassesProperty = DependencyProperty.Register("Classes", typeof(ExtendedClasses), typeof(PlanGridTile), null);

        public PlanGridTile()
        {
            this.InitializeComponent();
        }

        public ExtendedClasses Classes
        {
            get
            {
                return (ExtendedClasses)this.GetValue(ClassesProperty);
            }

            set
            {
                this.SetValue(ClassesProperty, value);
            }
        }
    }
}
