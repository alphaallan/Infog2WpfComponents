using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// <summary>
    /// Interaction logic for MyTextBoxLabel.xaml
    /// </summary>
    public partial class MyTextBoxLabel : UserControl
    {
        public MyTextBoxLabel()
        {
            InitializeComponent();
            DataContext = this;
        }

        //Ativa o redimencionamento da fonte de acordo com a altura do controle
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(MyTextBoxLabel), new PropertyMetadata(false));



        //Brushes usados na textbox
        #region Brushes
        //Cor do fundo da caixa quando ela não detém o foco do cursor
        public Brush NoFocusColor
        {
            get { return (Brush)GetValue(NoFocusColorProperty); }
            set { SetValue(NoFocusColorProperty, value); }
        }
        public static readonly DependencyProperty NoFocusColorProperty =
            DependencyProperty.Register("NoFocusColorColor", typeof(Brush), typeof(MyTextBoxLabel), new PropertyMetadata(Brushes.White));

        //Cor do fundo da caixa quando ela detém o foco do cursor
        public Brush HaveFocusColor
        {
            get { return (Brush)GetValue(HaveFocusColorProperty); }
            set { SetValue(HaveFocusColorProperty, value); }
        }
        public static readonly DependencyProperty HaveFocusColorProperty =
            DependencyProperty.Register("HaveFocusColor", typeof(Brush), typeof(MyTextBoxLabel), new PropertyMetadata(Brushes.LightYellow));
        #endregion Brushes



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyTextBoxLabel), new PropertyMetadata(""));


        #region Label
        [Category("Label")]
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(MyTextBoxLabel), new PropertyMetadata(""));

        [Category("Label")]
        public FontStyle LabelFontStyle
        {
            get { return (FontStyle)GetValue(LabelFontStyleProperty); }
            set { SetValue(LabelFontStyleProperty, value); }
        }
        public static readonly DependencyProperty LabelFontStyleProperty =
            DependencyProperty.Register("LabelFontStyle", typeof(FontStyle), typeof(MyTextBoxLabel), new PropertyMetadata(FontStyles.Normal));

        [Category("Label")]
        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }
        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(double), typeof(MyTextBoxLabel), new PropertyMetadata(12.0));

        //Alinhamento do titulo
        [Category("Label")]
        public HorizontalAlignment LabelAlignment
        {
            get { return (HorizontalAlignment)GetValue(LabelAlignmentProperty); }
            set { SetValue(LabelAlignmentProperty, value); }
        }
        public static readonly DependencyProperty LabelAlignmentProperty =
            DependencyProperty.Register("LabelAlignment", typeof(HorizontalAlignment), typeof(MyTextBoxLabel), new PropertyMetadata(HorizontalAlignment.Left));

        #endregion Label

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MyTextBoxLabel), new PropertyMetadata(2.0));

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
            DependencyProperty.Register("Watermark", typeof(string), typeof(MyTextBoxLabel), new PropertyMetadata(""));



        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MyTextBoxLabel), new PropertyMetadata(false));

        
        
        #endregion Marca d'água
    }
}
