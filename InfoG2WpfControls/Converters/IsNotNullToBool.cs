using System;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    public class IsNotNullToBool : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return  (value != null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException("IsNotNullConverter can only be used OneWay.");
        }
    }
}
