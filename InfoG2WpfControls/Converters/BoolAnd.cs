using System;
using System.Linq;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    public class BoolAnd : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (values.All(v => (v is bool && (bool)v)));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
