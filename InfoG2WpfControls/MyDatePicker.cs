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
    public class MyDatePicker : DatePicker
    {
        static MyDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyDatePicker), new FrameworkPropertyMetadata(typeof(MyDatePicker)));
        }

        //Ativa o redimencionamento da fonte de acordo com a altura do controle
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(MyDatePicker), new PropertyMetadata(false));

        //Propriedades de Layout
        #region Layout
        //Raio das bordas
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MyDatePicker), new PropertyMetadata(2.0));

        //Brushes usados no datapicker
        #region Brushes
        //Cor do fundo da caixa quando ela não detém o foco do cursor
        public Brush NoFocusColor
        {
            get { return (Brush)GetValue(NoFocusColorProperty); }
            set { SetValue(NoFocusColorProperty, value); }
        }
        public static readonly DependencyProperty NoFocusColorProperty =
            DependencyProperty.Register("NoFocusColorColor", typeof(Brush), typeof(MyDatePicker), new PropertyMetadata(Brushes.White));

        //Cor do fundo da caixa quando ela detém o foco do cursor
        public Brush HaveFocusColor
        {
            get { return (Brush)GetValue(HaveFocusColorProperty); }
            set { SetValue(HaveFocusColorProperty, value); }
        }
        public static readonly DependencyProperty HaveFocusColorProperty =
            DependencyProperty.Register("HaveFocusColor", typeof(Brush), typeof(MyDatePicker), new PropertyMetadata(Brushes.LightYellow));
        #endregion Brushes
        #endregion Layout
    }
}
