using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PlanVisual.Controls
{
    using Plan.DataClasses;

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
