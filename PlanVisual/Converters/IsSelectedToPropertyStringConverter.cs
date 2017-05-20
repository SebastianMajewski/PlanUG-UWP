namespace PlanVisual.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class IsSelectedToPropertyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var s = value as string;
            return s != null && s == (string)parameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        { 
            if (value is bool && (bool)value)
            {
                return parameter;
            }

            return null;
        }
    }
}
