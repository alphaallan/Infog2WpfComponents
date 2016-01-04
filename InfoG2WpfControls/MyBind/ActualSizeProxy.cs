using System.Windows;

namespace InfoG2WpfControls.MyBind
{
    public static class ActualSizeProxy
    {
        public static readonly DependencyProperty UseSizeProxyProperty = DependencyProperty.RegisterAttached("UseSizeProxy", typeof(bool), typeof(ActualSizeProxy), new FrameworkPropertyMetadata(OnUseSizeProxyChanged));
        public static readonly DependencyProperty ObservedWidthProperty = DependencyProperty.RegisterAttached("ObservedWidth", typeof(double), typeof(ActualSizeProxy));
        public static readonly DependencyProperty ObservedHeightProperty = DependencyProperty.RegisterAttached("ObservedHeight", typeof(double), typeof(ActualSizeProxy));
        
        public static bool GetUseSizeProxy(FrameworkElement frameworkElement)
        {
            return (bool)frameworkElement.GetValue(UseSizeProxyProperty);
        }

        public static void SetUseSizeProxy(FrameworkElement frameworkElement, bool observe)
        {
            frameworkElement.SetValue(UseSizeProxyProperty, observe);
        }

        public static double GetObservedWidth(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedWidthProperty);
        }

        public static void SetObservedWidth(FrameworkElement frameworkElement, double observedWidth)
        {
            frameworkElement.SetValue(ObservedWidthProperty, observedWidth);
        }

        public static double GetObservedHeight(FrameworkElement frameworkElement)
        {
            return (double)frameworkElement.GetValue(ObservedHeightProperty);
        }

        public static void SetObservedHeight(FrameworkElement frameworkElement, double observedHeight)
        {
            frameworkElement.SetValue(ObservedHeightProperty, observedHeight);
        }

        private static void OnUseSizeProxyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)dependencyObject;

            if ((bool)e.NewValue)
            {
                frameworkElement.SizeChanged += OnFrameworkElementSizeChanged;
                UpdateObservedSizesForFrameworkElement(frameworkElement);
            }
            else
            {
                frameworkElement.SizeChanged -= OnFrameworkElementSizeChanged;
            }
        }

        private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        }

        private static void UpdateObservedSizesForFrameworkElement(FrameworkElement frameworkElement)
        {
            frameworkElement.SetCurrentValue(ObservedWidthProperty, frameworkElement.ActualWidth);
            frameworkElement.SetCurrentValue(ObservedHeightProperty, frameworkElement.ActualHeight);
        }
    }
}
