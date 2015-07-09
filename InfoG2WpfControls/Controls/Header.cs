using System.Windows;
using System.Windows.Controls;

namespace InfoG2WpfControls
{
    public class Header : ContentControl
    {
        static Header()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Header), new FrameworkPropertyMetadata(typeof(Header)));
        }



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(Header), new PropertyMetadata(""));



        public object Appendix
        {
            get { return (object)GetValue(AppendixProperty); }
            set { SetValue(AppendixProperty, value); }
        }
        public static readonly DependencyProperty AppendixProperty =
            DependencyProperty.Register("Appendix", typeof(object), typeof(Header), new PropertyMetadata(null));

        
    }
}
