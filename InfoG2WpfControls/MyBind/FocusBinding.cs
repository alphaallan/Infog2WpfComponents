﻿using System;
using System.Windows;

namespace InfoG2WpfControls.MyBind
{
    public class FocusBinding : BindingDecoratorBase
    {
        public override object ProvideValue(IServiceProvider provider)
        {
            DependencyObject elem;
            DependencyProperty prop;
            if (base.TryGetTargetItems(provider, out elem, out prop))
            {
                FocusController.SetFocusableProperty(elem, prop);
            }

            return base.ProvideValue(provider);
        }
    }
}