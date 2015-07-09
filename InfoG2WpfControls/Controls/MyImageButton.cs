using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfoG2WpfControls
{
    public class MyImageButton : Button
    {
        static MyImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyImageButton), new FrameworkPropertyMetadata(typeof(MyImageButton)));
        }

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
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MyImageButton), new PropertyMetadata(null));
        #endregion Icon
    }
}
