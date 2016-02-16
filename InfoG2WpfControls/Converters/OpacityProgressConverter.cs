using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace InfoG2WpfControls
{
    class OpacityProgressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double progress = (double)values[0];
            ProgressBar progressBar = values[1] as ProgressBar;

            string[] parameters = parameter.ToString().Split('/');
            int stages = Int32.Parse(parameters[0]);
            int stage = Int32.Parse(parameters[1]);

            double stageFactor = 1.0 / stages;
            double progressPercentage = ((progress - progressBar.Minimum) / (progressBar.Maximum - progressBar.Minimum));

            double stageOpacity = (progressPercentage - (stageFactor * (stage))) / stageFactor;

            return (stageOpacity < 0D) ? 0D : ((stageOpacity > 1) ? 1D : stageOpacity);

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
