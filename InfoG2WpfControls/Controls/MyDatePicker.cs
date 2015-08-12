using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace InfoG2WpfControls
{
    public class MyDatePicker : DatePicker
    {
        static MyDatePicker()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyDatePicker), new FrameworkPropertyMetadata(typeof(MyDatePicker)));
            EventManager.RegisterClassHandler(typeof(MyDatePicker), MyDatePicker.PreviewLostKeyboardFocusEvent, new RoutedEventHandler(MyDatePicker_Preview_LostFocus));
            EventManager.RegisterClassHandler(typeof(MyDatePicker), MyDatePicker.GotFocusEvent, new RoutedEventHandler(MyDatePicker_GotFocus));
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

        private static void MyDatePicker_Preview_LostFocus(object sender, RoutedEventArgs e)
        {
            MyDatePicker box = (sender as MyDatePicker);
            if (box.DisplayDateEnd.HasValue && DateTime.Parse(box.Text) > box.DisplayDateEnd.Value)
            {
                box.SelectedDate = box.DisplayDateEnd.Value;
                box.Text = box.DisplayDateEnd.Value.ToShortDateString();
            }
            if (box.DisplayDateStart.HasValue && DateTime.Parse(box.Text) < box.DisplayDateStart.Value)
            {
                box.SelectedDate = box.DisplayDateStart.Value;
                box.Text = box.DisplayDateStart.Value.ToShortDateString();
            }
        }

        private static void MyDatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            MyDatePicker box = (sender as MyDatePicker);
            DateTime temp;
            if (box.SelectedDate.HasValue && DateTime.TryParse(box.Text, out temp) && temp != box.SelectedDate.Value) box.Text = box.SelectedDate.Value.ToShortDateString();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            DatePickerTextBox DateBox = (DatePickerTextBox)this.Template.FindName("PART_TextBox", this);

            if (e.Key == Key.Back)
            {
                this.Text = DateTime.Now.ToShortDateString();
                DateBox.CaretIndex = 0;
                e.Handled = true;
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9) //Ler digitos de 0 a 9
            {
                char[] buff = DateBox.Text.ToCharArray();
                char carac = e.Key.ToString()[1];

                if (DateBox.CaretIndex < 10)
                {
                    int CaretIndex = DateBox.CaretIndex;
                    if ((CaretIndex == 2) || (CaretIndex == 5)) CaretIndex++;
                    
                    buff[CaretIndex] = carac;
                    string OutText = new string(buff);
                    DateBox.Text = OutText;

                    CaretIndex++;
                    DateBox.CaretIndex = CaretIndex;
                }

                e.Handled = true;
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) //Ler digitos de 0 a 9
            {
                char[] buff = DateBox.Text.ToCharArray();
                char carac = e.Key.ToString()[6];

                if (DateBox.CaretIndex < 10)
                {
                    int CaretIndex = DateBox.CaretIndex;
                    if ((CaretIndex == 2) || (CaretIndex == 5)) CaretIndex++;

                    buff[CaretIndex] = carac;
                    string OutText = new string(buff);
                    DateBox.Text = OutText;

                    CaretIndex++;
                    DateBox.CaretIndex = CaretIndex;
                }

                e.Handled = true;
            }
            else if (((e.Key != Key.Tab) 
                   && (e.Key != Key.Enter) 
                   && (e.Key != Key.Left)
                   && (e.Key != Key.Right)) || e.Key == Key.Insert)
            {
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e); //Chamada do método da base
        }
    }
}
