namespace PlanVisual.Behaviours
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using Microsoft.Xaml.Interactivity;
    using Plan.PlanServiceReference;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class SelectedItemsBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<PlanSelect>), typeof(SelectedItemsBehavior), new PropertyMetadata(null, OnSelectedItemsChanged));

        public bool Sync { get; set; }

        public ObservableCollection<PlanSelect> SelectedItems
        {
            get
            {
                return (ObservableCollection<PlanSelect>)this.GetValue(SelectedItemsProperty);
            }

            set
            {
                this.SetValue(SelectedItemsProperty, value);
            }
        }

        public void SelectedItemsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (!this.Sync)
            {
                this.Sync = true;
                var listView = this.AssociatedObject;
                listView.SelectedItems.Clear();
                foreach (var var in (ObservableCollection<PlanSelect>)sender)
                {
                    listView.SelectedItems.Add(var);
                }

                this.Sync = false;
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
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (SelectedItemsBehavior)d;
            behavior.SelectedItems.CollectionChanged -= behavior.SelectedItemsOnCollectionChanged;
            behavior.SelectedItems.CollectionChanged += behavior.SelectedItemsOnCollectionChanged;
            if (!behavior.Sync)
            {
                behavior.Sync = true;
                var listView = behavior.AssociatedObject;
                listView.SelectedItems.Clear();
                foreach (var var in (ICollection)e.NewValue)
                {
                    listView.SelectedItems.Add(var);
                }

                behavior.Sync = false;
            }
        }

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (!this.Sync)
            {
                this.Sync = true;
                var newCollection = ((ListView)sender).SelectedItems;
                this.SelectedItems = new ObservableCollection<PlanSelect>(newCollection.Select(x => x as PlanSelect));
                this.Sync = false;
            }
        }
    }
}
