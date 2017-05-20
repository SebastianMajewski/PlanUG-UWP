namespace PlanVisual.Controls
{
    using Prism.Commands;
    using Windows.UI.Xaml;

    public sealed partial class NoSettingMessage
    {
        public static readonly DependencyProperty ConfigureCommandProperty = DependencyProperty.Register("ConfigureCommand", typeof(DelegateCommand), typeof(NoSettingMessage), null);

        public NoSettingMessage()
        {
            this.InitializeComponent();
        }

        public DelegateCommand ConfigureCommand
        {
            get
            {
                return (DelegateCommand)this.GetValue(ConfigureCommandProperty);
            }

            set
            {
                this.SetValue(ConfigureCommandProperty, value);
            }
        }
    }
}
