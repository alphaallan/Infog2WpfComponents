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
        #endregion Icon
    }
}
