namespace PlanVisual.Behaviours
{
    using Controls;
    using Microsoft.Xaml.Interactivity;
    using Tools;
    using Windows.UI.Xaml.Controls;

    public class NavigatedPivotBehavior : Behavior<Pivot>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            PivotNavigator.Instance.Pivot = this.AssociatedObject;
            
            var associatedObjectItems = this.AssociatedObject.Items;
            if (associatedObjectItems == null)
            {
                return;
            }

            associatedObjectItems.VectorChanged += (sender, e) =>
            {
                PivotNavigator.Instance.Items.Clear();
                foreach (var item in associatedObjectItems)
                {
                    var namedItem = item as NamedPivotItem;
                    if (namedItem != null)
                    {
                        PivotNavigator.Instance.Items.Add(namedItem);
                    }
                }
            };
        }
    }
}
