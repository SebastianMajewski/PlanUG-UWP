namespace PlanVisual.Behaviours
{
    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class CombinedSelectionChangedBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty LinkedListViewProperty = DependencyProperty.Register("LinkedListView", typeof(ListView), typeof(CombinedSelectionChangedBehavior), new PropertyMetadata(null, PropertyChangedCallback));

        private bool sync;

        public ListView LinkedListView
        {
            get
            {
                return (ListView)this.GetValue(LinkedListViewProperty);
            }

            set
            {
                this.SetValue(LinkedListViewProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += this.AssociatedObjectOnSelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= this.AssociatedObjectOnSelectionChanged;
            if (this.LinkedListView != null)
            {
                this.LinkedListView.SelectionChanged -= this.LinkedListViewOnSelectionChanged;
            }
        }

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var cscb = dependencyObject as CombinedSelectionChangedBehavior;
            if (cscb == null)
            {
                return;
            }

            var newlistView = e.NewValue as ListView;
            if (newlistView != null)
            {
                newlistView.SelectionChanged += cscb.LinkedListViewOnSelectionChanged;
            }
        }

        private void LinkedListViewOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (!this.sync)
            {
                this.sync = true;
                this.AssociatedObject.SelectedItem = null;
                this.sync = false;
            }
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (!this.sync)
            {
                this.sync = true;
                this.LinkedListView.SelectedItem = null;
                this.sync = false;
            }           
        }
    }
}
