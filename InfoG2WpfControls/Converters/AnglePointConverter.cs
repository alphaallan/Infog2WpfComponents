using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    class AnglePointXConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is System.Windows.FrameworkElement && parameter != null)
            {
                System.Windows.FrameworkElement control = value as System.Windows.FrameworkElement;
                double radius = ((control.Parent as System.Windows.FrameworkElement).Width - control.Width) / 2;
                double angle = Double.Parse(parameter.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                double temp = radius + radius * Math.Cos(angle * (Math.PI / 180));
                return temp;
            }

            return 0D;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class AnglePointYConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is System.Windows.FrameworkElement && parameter != null)
            {
                System.Windows.FrameworkElement control = value as System.Windows.FrameworkElement;
                double radius = ((control.Parent as System.Windows.FrameworkElement).Width - control.Width) / 2;
                double angle = Double.Parse(parameter.ToString(), System.Globalization.CultureInfo.InvariantCulture);

                double temp = radius - radius * Math.Sin(angle * (Math.PI / 180));
                return temp;
            }

            return 0D;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
