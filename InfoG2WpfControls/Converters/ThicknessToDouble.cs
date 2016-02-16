using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    class ThicknessToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value != null) ? ((System.Windows.Thickness)value).Top : 0D;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value != null) ? new System.Windows.Thickness((double)value) : new System.Windows.Thickness();
        }
    }
}
