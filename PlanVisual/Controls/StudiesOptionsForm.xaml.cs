namespace PlanVisual.Controls
{
    using System.Collections.ObjectModel;
    using Plan.PlanServiceReference;
    using Prism.Commands;
    using Windows.UI.Xaml;

    public sealed partial class StudiesOptionsForm
    {
        public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemSource", typeof(ObservableCollection<PlanSelect>), typeof(StudiesOptionsForm), null);
        public static readonly DependencyProperty ApplyCommandProperty = DependencyProperty.Register("ApplyCommand", typeof(DelegateCommand<PlanSelect>), typeof(StudiesOptionsForm), null);

        public StudiesOptionsForm()
        {
            this.InitializeComponent();
        }

        public ObservableCollection<PlanSelect> ItemSource
        {
            get
            {
                return (ObservableCollection<PlanSelect>)this.GetValue(ItemSourceProperty);
            }

            set
            {
                this.SetValue(ItemSourceProperty, value);
            }
        }

        public DelegateCommand<PlanSelect> ApplyCommand
        {
            get
            {
                return (DelegateCommand<PlanSelect>)this.GetValue(ApplyCommandProperty);
            }

            set
            {
                this.SetValue(ApplyCommandProperty, value);
            }
        }
    }
}
