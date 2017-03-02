using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanVisual.Converters
{
    using Windows.UI.Xaml.Data;

    public class IsSelectedToPropertyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && (string)value == (string)parameter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            
            if (value is bool && (bool)value == true)
            {
                return parameter;
            }
            else
            {
                return null;
            }
        }
    }
}
