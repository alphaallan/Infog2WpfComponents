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


        #region Propriedades de Comportamento
        //Ativa o redimencionamento da fonte de acordo com a altura do controle
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(MyTextBox), new PropertyMetadata(false));

        //Mascara
        #region Mask
        public MyTextBoxTextType Mask
        {
            get { return (MyTextBoxTextType)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(MyTextBoxTextType), typeof(MyTextBox), new FrameworkPropertyMetadata(MyTextBoxTextType.Any,MaskChangedCallback));
        #endregion Mask
        #endregion Propriedades de Comportamento


        //Propriedades de Layout
        #region Layout 
        //Raio das bordas
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MyTextBox), new PropertyMetadata(2.0));
        
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


        public string Prefix
        {
            get { return (string)GetValue(PrefixProperty); }
            set { SetValue(PrefixProperty, value); }
        }
        public static readonly DependencyProperty PrefixProperty =
            DependencyProperty.Register("Prefix", typeof(string), typeof(MyTextBox), new PropertyMetadata(""));

        
        #endregion Layout

        #endregion

        #region Funções
        private static void MaskChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is MyTextBox)
            {
                (e.OldValue as MyTextBox).PreviewTextInput -= MyTextBox_PreviewTextInput;
                DataObject.RemovePastingHandler((e.OldValue as MyTextBox), (DataObjectPastingEventHandler)MyTextBoxPastingEventHandler);
            }

            MyTextBox _this = (d as MyTextBox);
            if (_this == null) return;

            if ((MyTextBoxTextType)e.NewValue != MyTextBoxTextType.Any)
            {
                _this.PreviewTextInput += MyTextBox_PreviewTextInput;
                DataObject.AddPastingHandler(_this, (DataObjectPastingEventHandler)MyTextBoxPastingEventHandler);
            }

            ValidateTextBox(_this);
        }

        private static void MyTextBoxPastingEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            MyTextBox _this = (sender as MyTextBox);
            string clipboard = e.DataObject.GetData(typeof(string)) as string;
            clipboard = ValidateValue(_this.Mask, clipboard);
            if (!string.IsNullOrEmpty(clipboard))
            {
                _this.Text = clipboard;
            }
            e.CancelCommand();
            e.Handled = true;
        }

        private static void MyTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            MyTextBox _this = (sender as MyTextBox);
            bool isValid = IsSymbolValid(_this.Mask, e.Text);
            e.Handled = !isValid;
            if (isValid)
            {
                int caret = _this.CaretIndex;
                string text = _this.Text;
                bool textInserted = false;
                int selectionLength = 0;

                if (_this.SelectionLength > 0)
                {
                    text = text.Substring(0, _this.SelectionStart) +
                            text.Substring(_this.SelectionStart + _this.SelectionLength);
                    caret = _this.SelectionStart;
                }

                if (e.Text == NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                {
                    while (true)
                    {
                        int ind = text.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                        if (ind == -1)
                            break;

                        text = text.Substring(0, ind) + text.Substring(ind + 1);
                        if (caret > ind)
                            caret--;
                    }

                    if (caret == 0)
                    {
                        text = "0" + text;
                        caret++;
                    }
                    else
                    {
                        if (caret == 1 && string.Empty + text[0] == NumberFormatInfo.CurrentInfo.NegativeSign)
                        {
                            text = NumberFormatInfo.CurrentInfo.NegativeSign + "0" + text.Substring(1);
                            caret++;
                        }
                    }

                    if (caret == text.Length)
                    {
                        text = text + NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0";
                        selectionLength = 1;
                        textInserted = true;
                        caret++;
                    }
                }
                else if (e.Text == NumberFormatInfo.CurrentInfo.NegativeSign)
                {
                    textInserted = true;
                    if (_this.Text.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                    {
                        text = text.Replace(NumberFormatInfo.CurrentInfo.NegativeSign, string.Empty);
                        if (caret != 0)
                            caret--;
                    }
                    else
                    {
                        text = NumberFormatInfo.CurrentInfo.NegativeSign + _this.Text;
                        caret++;
                    }
                }

                if (!textInserted)
                {
                    text = text.Substring(0, caret) + e.Text +
                        ((caret < _this.Text.Length) ? text.Substring(caret) : string.Empty);

                    caret++;
                }

                try
                {
                    double val = Convert.ToDouble(text);
                    if (val == 0)
                    {
                        if (!text.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
                            text = "0";
                    }
                    else
                    {
                        text = val.ToString();
                        if ((val % 1 == 0) && !(text.EndsWith(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0")) && (_this.Mask == MyTextBoxTextType.Decimal))
                        {
                            text += NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + "0";
                        }
                        if (_this.Mask == MyTextBoxTextType.Money) text = String.Format("{0:.00}", val);
                    }
                }
                catch
                {
                    text = "0";
                }

                while (text.Length > 1 && text[0] == '0' && string.Empty + text[1] != NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                {
                    text = text.Substring(1);
                    if (caret > 0)
                        caret--;
                }

                while (text.Length > 2 && string.Empty + text[0] == NumberFormatInfo.CurrentInfo.NegativeSign && text[1] == '0' && string.Empty + text[2] != NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
                {
                    text = NumberFormatInfo.CurrentInfo.NegativeSign + text.Substring(2);
                    if (caret > 1)
                        caret--;
                }

                if (caret > text.Length)
                    caret = text.Length;

                _this.Text = text;
                _this.CaretIndex = caret;
                _this.SelectionStart = caret;
                _this.SelectionLength = selectionLength;
                e.Handled = true;
            }
        }

        #region Validadores
        private static bool IsSymbolValid(MyTextBoxTextType mask, string str)
        {
            switch (mask)
            {
                case MyTextBoxTextType.Any:
                    return true;

                case MyTextBoxTextType.Integer:
                    if (str == NumberFormatInfo.CurrentInfo.NegativeSign)
                        return true;
                    break;

                case MyTextBoxTextType.Money:
                case MyTextBoxTextType.Decimal:
                    if (str == NumberFormatInfo.CurrentInfo.NumberDecimalSeparator ||
                        str == NumberFormatInfo.CurrentInfo.NegativeSign)
                        return true;
                    break;
            }

            if (mask.Equals(MyTextBoxTextType.Integer) || mask.Equals(MyTextBoxTextType.Decimal) || mask.Equals(MyTextBoxTextType.Money))
            {
                foreach (char ch in str)
                {
                    if (!Char.IsDigit(ch))
                        return false;
                }

                return true;
            }

            return false;
        }

        private static string ValidateValue(MyTextBoxTextType mask, string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            value = value.Trim();

            switch (mask)
            {
                case MyTextBoxTextType.Integer:
                    {
                        int val;
                        if (int.TryParse(value, out val)) return val.ToString();
                        return string.Empty;
                    }

                case MyTextBoxTextType.Decimal:
                    {
                        double val;
                        if (double.TryParse(value, out val)) return val.ToString();
                        return string.Empty;
                    }
                case MyTextBoxTextType.Money:
                    {
                        double val;
                        if (double.TryParse(value, out val)) return String.Format("{0:.00}", val);
                        return string.Empty;
                    }
            }

            return value;
        }

        private static void ValidateTextBox(MyTextBox _this)
        {
            if (_this.Mask != MyTextBoxTextType.Any)
            {
                _this.Text = ValidateValue(_this.Mask, _this.Text);
            }
        }
        #endregion Validadores
        #endregion Funções

    }

    public enum MyTextBoxTextType
    {
        Any,
        Integer,
        Decimal,
        Money
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
