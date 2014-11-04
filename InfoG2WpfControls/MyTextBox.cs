using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;
using System.Globalization;


namespace InfoG2WpfControls
{
    public class MyTextBox : TextBox
    {
        static MyTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata(typeof(MyTextBox)));
        }


        #region Propriedades de dependência

        //Ativa o redimencionamento da fonte de acordo com a altura do controle
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutosizeFont.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(MyTextBox), new PropertyMetadata(false));



        //Brushes usados na textbox
        #region Brushes
        //Cor do fundo da caixa quando ela não detém o foco do cursor
        public Brush NoFocusColor
        {
            get { return (Brush)GetValue(NoFocusColorProperty); }
            set { SetValue(NoFocusColorProperty, value); }
        }
        public static readonly DependencyProperty NoFocusColorProperty =
            DependencyProperty.Register("NoFocusColorColor", typeof(Brush), typeof(MyTextBox), new PropertyMetadata(Brushes.White));

        //Cor do fundo da caixa quando ela detém o foco do cursor
        public Brush HaveFocusColor
        {
            get { return (Brush)GetValue(HaveFocusColorProperty); }
            set { SetValue(HaveFocusColorProperty, value); }
        }
        public static readonly DependencyProperty HaveFocusColorProperty =
            DependencyProperty.Register("HaveFocusColor", typeof(Brush), typeof(MyTextBox), new PropertyMetadata(Brushes.LightYellow));
        #endregion Brushes



        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MyTextBox), new PropertyMetadata(2.0));

        

        //Marca d'água que aparece quando a caixa de texto está vazia e sem o foco do cursor
        #region Marca d'água
        //String da mascara
        [Category("Watermark")]
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(MyTextBox), new PropertyMetadata(""));

        //Template da aparencia da marca d'água
        [Category("Watermark")]
        public DataTemplate WatermarkTemplate
        {
            get { return (DataTemplate)GetValue(WatermarkTemplateProperty); }
            set { SetValue(WatermarkTemplateProperty, value); }
        }
        public static readonly DependencyProperty WatermarkTemplateProperty =
            DependencyProperty.Register("WatermarkTemplate", typeof(DataTemplate), typeof(MyTextBox), new UIPropertyMetadata(null));
        #endregion Marca d'água

        #endregion
    }

    class HeightToFontSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var height = (double)value;
            return .65 * height;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
