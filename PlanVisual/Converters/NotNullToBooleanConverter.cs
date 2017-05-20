namespace PlanVisual.Converters
{
    using System;
    using Windows.UI.Xaml.Data;

    public class NotNullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null;
        }
            
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        } 
    }
}