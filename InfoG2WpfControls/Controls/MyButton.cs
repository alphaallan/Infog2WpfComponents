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
    public class MyButton : Button
    {
        static MyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyButton), new FrameworkPropertyMetadata(typeof(MyButton)));
        }

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(MyButton), new PropertyMetadata(2.0));

        public bool Borderless
        {
            get { return (bool)GetValue(BorderlessProperty); }
            set { SetValue(BorderlessProperty, value); }
        }
        public static readonly DependencyProperty BorderlessProperty =
            DependencyProperty.Register("Borderless", typeof(bool), typeof(MyButton), new PropertyMetadata(false));


        /// <summary>
        /// Texto com quebra automática 
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyButton), new PropertyMetadata(string.Empty));

        

        #region Brushes

        public Brush PressedBrush
        {
            get { return (Brush)GetValue(PressedBrushProperty); }
            set { SetValue(PressedBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBrushProperty =
            DependencyProperty.Register("PressedBrush", typeof(Brush), typeof(MyButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFC6C6C6")));

        public Brush PressedBorderBrush
        {
            get { return (Brush)GetValue(PressedBorderBrushProperty); }
            set { SetValue(PressedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.Register("PressedBorderBrush", typeof(Brush), typeof(MyButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFC1C1C1")));

        public Brush MouseOverBrush
        {
            get { return (Brush)GetValue(MouseOverBrushProperty); }
            set { SetValue(MouseOverBrushProperty, value); }
        }
        public static readonly DependencyProperty MouseOverBrushProperty =
            DependencyProperty.Register("MouseOverBrush", typeof(Brush), typeof(MyButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFDADADA")));

        public Brush FocusedBorderBrush
        {
            get { return (Brush)GetValue(FocusedBorderBrushProperty); }
            set { SetValue(FocusedBorderBrushProperty, value); }
        }
        public static readonly DependencyProperty FocusedBorderBrushProperty =
            DependencyProperty.Register("FocusedBorderBrush", typeof(Brush), typeof(MyButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFDADADA")));

        #endregion Brushes

        //Propriedades do icone
        #region Icon
        //Caminho do icone
        [Category("Icon")]
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MyButton), new PropertyMetadata(null));

        [Category("Icon")]
        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(double), typeof(MyButton), new PropertyMetadata(-1.0));

        
        #endregion Icon
    }
}
