namespace PlanVisual.Behaviours
{
    using Microsoft.Xaml.Interactivity;
    using Windows.UI.Xaml.Controls;

    public class PivotSelectBehavior : Behavior<Pivot>
    {
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

        private void AssociatedObjectOnSelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            foreach (var obj in selectionChangedEventArgs.AddedItems)
            {
                var pivotItem = obj as PivotItem;
                if (pivotItem != null)
                {
                    var behaviors = Interaction.GetBehaviors(pivotItem);
                    foreach (var b in behaviors)
                    {
                        var behavior = b as PivotItemSelectedBehavior;
                        if (behavior?.Command != null)
                        {
                            if (behavior.Command.CanExecute(null))
                            {
                                behavior.Command.Execute(null);
                            }
                        }
                    }
                }
            }
        }
    }
}
