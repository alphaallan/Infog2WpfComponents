using System;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    public class EnumNotEquals : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Enum)
            {
                if (parameter is string)
                {
                    try
                    {
                        return !(value.Equals(Enum.Parse(value.GetType(), (string)parameter)));
                    }

                    catch (ArgumentException exception)
                    {
                        System.Diagnostics.Debug.WriteLine(
                            string.Format("EnumBinding = {0},  EnumValue = {1},  ArgumentException {2}",
                                            value, parameter, exception));
                        throw;
                    }
                }
                else if (parameter is Array && (parameter as Array).Length > 0 && (parameter as Array).GetValue(0) is string)
                {
                    foreach (string s in (parameter as Array))
                    {
                        try
                        {
                            if (value.Equals(Enum.Parse(value.GetType(), s))) return false;
                        }

                        catch (ArgumentException exception)
                        {
                            System.Diagnostics.Debug.WriteLine(
                                string.Format("EnumBinding = {0},  EnumValue = {1},  ArgumentException {2}",
                                                value, parameter, exception));
                            throw;
                        }
                    }

                    return true;
                }

                return false;
            }
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
