using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    public class BoolToVisibility : IValueConverter
    {
        /// <summary>
        /// Converter um booleano em Visibility
        /// 
        /// Obs. Se o value não for do tipo bool retorna Visibility.Visible
        /// </summary>
        /// <param name="value">True = Visibility.Visible, False = Visibility.Collapsed</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">True = Inverter funcionamento, False ou NULL funcionamento normal</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool temp;

            if (Boolean.TryParse(parameter as string, out temp) && temp)
            {
                if (value is bool) return (((bool)value) ? Visibility.Collapsed : Visibility.Visible);
                else return Visibility.Collapsed;
            }
            
            if (value is bool) return (((bool)value) ? Visibility.Visible : Visibility.Collapsed );
            else return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility) return (((Visibility)value) == Visibility.Visible);
            else return false;
        }
    }
}
