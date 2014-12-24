using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfoG2WpfControls
{
    public class MyToggleButton : ToggleButton
    {
        static MyToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyToggleButton), new FrameworkPropertyMetadata(typeof(MyToggleButton)));
        }


        public Brush PressedBrush
        {
            get { return (Brush)GetValue(PressedBrushProperty); }
            set { SetValue(PressedBrushProperty, value); }
        }
        public static readonly DependencyProperty PressedBrushProperty =
            DependencyProperty.Register("PressedBrush", typeof(Brush), typeof(MyToggleButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFD2D2D2")));

        public Brush MouseOverBrush
        {
            get { return (Brush)GetValue(MouseOverBrushProperty); }
            set { SetValue(MouseOverBrushProperty, value); }
        }
        public static readonly DependencyProperty MouseOverBrushProperty =
            DependencyProperty.Register("MouseOverBrush", typeof(Brush), typeof(MyToggleButton), new PropertyMetadata(new BrushConverter().ConvertFrom("#FFE6E6E6")));
    }
}
