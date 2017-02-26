namespace PlanVisual.Behaviours
{
    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class TemplateChangeOnSelectedBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty DefaultTemplateProperty = DependencyProperty.Register("DefaultTemplate", typeof(DataTemplate), typeof(TemplateChangeOnSelectedBehavior), new PropertyMetadata(null, DefaultTemplateChanged));

        public static readonly DependencyProperty SelectedTemplateProperty = DependencyProperty.Register("SelectedTemplate", typeof(DataTemplate), typeof(TemplateChangeOnSelectedBehavior), null);

        public DataTemplate DefaulTemplate
        {
            get
            {
                return (DataTemplate)this.GetValue(DefaultTemplateProperty);
            }

            set
            {
                this.SetValue(DefaultTemplateProperty, value);
            }
        }

        public DataTemplate SelectedTemplate
        {
            get
            {
                return (DataTemplate)this.GetValue(SelectedTemplateProperty);
            }

            set
            {
                this.SetValue(SelectedTemplateProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.ItemTemplate = this.DefaulTemplate;
            this.AssociatedObject.SelectionChanged += this.AssociatedObjectOnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= this.AssociatedObjectOnSelectionChanged;
        }

        private static void DefaultTemplateChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var tcosb = dependencyObject as TemplateChangeOnSelectedBehavior;
            if (tcosb?.AssociatedObject != null)
            {
                tcosb.AssociatedObject.ItemTemplate = dependencyPropertyChangedEventArgs.NewValue as DataTemplate;
            }
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var listItem in e.AddedItems)
            {
                var listView = sender as ListView;
                var item = listView?.ContainerFromItem(listItem) as ListViewItem;
                if (item != null)
                {
                    item.ContentTemplate = this.SelectedTemplate;
                }
            }

            foreach (var listItem in e.RemovedItems)
            {
                var listView = sender as ListView;
                var item = listView?.ContainerFromItem(listItem) as ListViewItem;
                if (item != null)
                {
                    item.ContentTemplate = this.DefaulTemplate;
                }
            }
        }
    }
}
