using System;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    public class BooleanInverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool) return !((bool)value);
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool) return !((bool)value);
            else return true;
        }
    }
}
