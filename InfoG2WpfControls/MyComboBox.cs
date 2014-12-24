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



        public Brush HaveFocusColor
        {
            get { return (Brush)GetValue(HaveFocusColorProperty); }
            set { SetValue(HaveFocusColorProperty, value); }
        }
        public static readonly DependencyProperty HaveFocusColorProperty =
            DependencyProperty.Register("HaveFocusColor", typeof(Brush), typeof(MyComboBox), new PropertyMetadata(Brushes.Yellow));



        public Brush ListBackground
        {
            get { return (Brush)GetValue(ListBackgroundProperty); }
            set { SetValue(ListBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ListBackgroundProperty =
            DependencyProperty.Register("ListBackground", typeof(Brush), typeof(MyComboBox), new PropertyMetadata(Brushes.White));

        

        public Brush ButtonBrush
        {
            get { return (Brush)GetValue(ButtonBrushProperty); }
            set { SetValue(ButtonBrushProperty, value); }
        }
        public static readonly DependencyProperty ButtonBrushProperty =
            DependencyProperty.Register("ButtonBrush", typeof(Brush), typeof(MyComboBox), new PropertyMetadata(Brushes.Gainsboro));

      

        public Brush ButtonMouseOverBrush
        {
            get { return (Brush)GetValue(ButtonMouseOverBrushProperty); }
            set { SetValue(ButtonMouseOverBrushProperty, value); }
        }
        public static readonly DependencyProperty ButtonMouseOverBrushProperty =
            DependencyProperty.Register("ButtonMouseOverBrush", typeof(Brush), typeof(MyComboBox), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFE6E6E6")));

        public Brush ButtonPressedBrush
        {
            get { return (Brush)GetValue(ButtonPressedBrushProperty); }
            set { SetValue(ButtonPressedBrushProperty, value); }
        }
        public static readonly DependencyProperty ButtonPressedBrushProperty =
            DependencyProperty.Register("ButtonPressedBrush", typeof(Brush), typeof(MyComboBox), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFD2D2D2"))); 
    }
}
