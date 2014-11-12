using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoG2WpfControls
{
    public class MyComboBox : ComboBox
    {
        static MyComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyComboBox), new FrameworkPropertyMetadata(typeof(MyComboBox)));
        }

        //Ativa o redimencionamento da fonte de acordo com a altura do controle
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(MyComboBox), new PropertyMetadata(false));
    }
}
