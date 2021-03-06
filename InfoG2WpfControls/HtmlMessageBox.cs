﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace InfoG2WpfControls
{
    public sealed class HtmlMessageBox
    {
        public static Style OkButtonStyle;
        public static Style YesButtonStyle;
        public static Style NoButtonStyle;
        public static Style CancelButtonStyle; 

        public static MessageBoxResult Show(Size size, string messageBoxContent)
        {
            return new Msb(size, messageBoxContent, string.Empty, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None).ShowDialog();
        }

        public static MessageBoxResult Show(Size size, string messageBoxContent, string caption)
        {
            return new Msb(size, messageBoxContent, caption, MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.None).ShowDialog();
        }

        public static MessageBoxResult Show(Size size, string messageBoxContent, string caption, MessageBoxButton button)
        {
            return new Msb(size, messageBoxContent, caption, button, MessageBoxImage.None, MessageBoxResult.None).ShowDialog();
        }

        public static MessageBoxResult Show(Size size, string messageBoxContent, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            return new Msb(size, messageBoxContent, caption, button, icon, MessageBoxResult.None).ShowDialog();
        }

        public static MessageBoxResult Show(Size size, string messageBoxContent, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult)
        {
            return new Msb(size, messageBoxContent, caption, button, icon, defaultResult).ShowDialog();
        }

        class Msb : Window
        {
            MessageBoxResult Result;

            Grid MainGrid;
            UIElement Footer;

            WebBrowser Body;
            Image BodyIcon;

            Button OkButton;
            Button YesButton;
            Button NoButton;
            Button CancelButton;


            public Msb(Size size, string html, string caption, MessageBoxButton buttons, MessageBoxImage icon, MessageBoxResult defaultResult)
            {
                Result = MessageBoxResult.None;
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                Background = System.Windows.Media.Brushes.White;
                ResizeMode = System.Windows.ResizeMode.NoResize;
                WindowStyle = System.Windows.WindowStyle.ToolWindow;
                MinWidth = 235;
                MinHeight = 165;
                MaxWidth = (int)(SystemParameters.WorkArea.Width * 0.60);
                MaxHeight = (int)(SystemParameters.WorkArea.Height * 0.90);
                Width = size.Width;
                Height = size.Height;

                Title = caption;

                var iconImage = GetIcon(icon);

                SetupMainGrid();
                SetupIcon(icon);
                SetupFooter(buttons);
                SetupBody((html.Contains("<body")) ? html : "<body scroll=\"no\">" + html + "</body>");

                Owner = Application.Current.MainWindow;
                Topmost = true;

                if (BodyIcon != null) MainGrid.Children.Add(BodyIcon);
                MainGrid.Children.Add(Body);
                MainGrid.Children.Add(Footer);

                this.AddChild(MainGrid);

                switch (defaultResult)
                {
                    case MessageBoxResult.OK:
                        OkButton.Focus();
                        break;

                    case MessageBoxResult.Yes:
                        YesButton.Focus();
                        break;

                    case MessageBoxResult.No:
                        NoButton.Focus();
                        break;

                    case MessageBoxResult.Cancel:
                        CancelButton.Focus();
                        break;

                    default:
                        OkButton.Focus();
                        break;
                }
            }

            new public MessageBoxResult ShowDialog()
            {
                base.ShowDialog();
                return Result;
            }

            private void SetupMainGrid()
            {
                MainGrid = new Grid();

                var row0 = new RowDefinition();
                row0.Height = new GridLength(1, GridUnitType.Star);

                var row1 = new RowDefinition();
                row1.Height = GridLength.Auto;

                var col0 = new ColumnDefinition();
                col0.Width = GridLength.Auto;

                var col1 = new ColumnDefinition();
                col1.Width = new GridLength(1, GridUnitType.Star);

                MainGrid.RowDefinitions.Add(row0);
                MainGrid.RowDefinitions.Add(row1);
                MainGrid.ColumnDefinitions.Add(col0);
                MainGrid.ColumnDefinitions.Add(col1);
            }

            private void SetupBody(string content)
            {
                Body = new WebBrowser();

                Body.NavigateToString("<html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"pt-br-us\">" +
                                      "<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"></head>" 
                                      + content);
                Grid.SetColumn(Body, 1);
                ScrollViewer.SetVerticalScrollBarVisibility(Body, ScrollBarVisibility.Hidden);
                ScrollViewer.SetCanContentScroll(Body, false);
                ScrollViewer.SetHorizontalScrollBarVisibility(Body, ScrollBarVisibility.Visible);
            }

            #region Rodapé
            private void SetupFooter(MessageBoxButton button)
            {
                StackPanel FooterStack = new StackPanel();
                FooterStack.Orientation = Orientation.Horizontal;
                FooterStack.HorizontalAlignment = HorizontalAlignment.Center;

                Border FooterBorder = new Border();
                Grid.SetRow(FooterBorder, 1);
                Grid.SetColumnSpan(FooterBorder, 2);
                FooterBorder.Background = new System.Windows.Media.BrushConverter().ConvertFromString("#FFF0F0F0") as System.Windows.Media.Brush;
                FooterBorder.Child = FooterStack;

                Footer = FooterBorder;

                SetupButtons();

                switch (button)
                {
                    case MessageBoxButton.OK:
                        FooterStack.Children.Add(OkButton);
                        break;

                    case MessageBoxButton.OKCancel:
                        FooterStack.Children.Add(OkButton);
                        FooterStack.Children.Add(CancelButton);
                        break;

                    case MessageBoxButton.YesNo:
                        FooterStack.Children.Add(YesButton);
                        FooterStack.Children.Add(NoButton);
                        break;

                    case MessageBoxButton.YesNoCancel:
                        FooterStack.Children.Add(YesButton);
                        FooterStack.Children.Add(NoButton);
                        FooterStack.Children.Add(CancelButton);
                        break;
                }

            }

            private void SetupButtons()
            {
                OkButton = new MyButton();
                YesButton = new MyButton();
                NoButton = new MyButton();
                CancelButton = new MyButton();

                if (OkButtonStyle != null) OkButton.Style = OkButtonStyle;
                OkButton.Content = "OK";
                OkButton.Margin = new Thickness(5, 10, 5, 10);
                OkButton.Width = 80;
                OkButton.MinHeight = 25;
                OkButton.Click += delegate(object sender, RoutedEventArgs e) { Result = MessageBoxResult.OK; Close(); };

                if (YesButtonStyle != null) YesButton.Style = YesButtonStyle;
                YesButton.Content = "Sim";
                YesButton.Margin = new Thickness(5, 10, 5, 10);
                YesButton.Width = 80;
                YesButton.MinHeight = 25;
                YesButton.Click += delegate(object sender, RoutedEventArgs e) { Result = MessageBoxResult.Yes; Close(); };

                if (NoButtonStyle != null) NoButton.Style = NoButtonStyle;
                NoButton.Content = "Não";
                NoButton.Margin = new Thickness(5, 10, 5, 10);
                NoButton.Width = 80;
                NoButton.MinHeight = 25;
                NoButton.Click += delegate(object sender, RoutedEventArgs e) { Result = MessageBoxResult.No; Close(); };

                if (CancelButtonStyle != null) CancelButton.Style = CancelButtonStyle;
                CancelButton.Content = "Cancelar";
                CancelButton.Margin = new Thickness(5, 10, 5, 10);
                CancelButton.Width = 80;
                CancelButton.MinHeight = 25;
                CancelButton.Click += delegate(object sender, RoutedEventArgs e) { Result = MessageBoxResult.Cancel; Close(); };
            }
            #endregion

            #region Icone
            private void SetupIcon(MessageBoxImage icon)
            {
                if (icon != MessageBoxImage.None)
                {
                    BodyIcon = new Image();
                    BodyIcon.Margin = new Thickness(23, 3, 3, 3);
                    BodyIcon.VerticalAlignment = VerticalAlignment.Center;
                    BodyIcon.Source = GetIcon(icon);
                    BodyIcon.Width = 32;
                    BodyIcon.Height = 32;
                }
            }

            private System.Windows.Media.ImageSource GetIcon(MessageBoxImage icon)
            {
                switch (icon.ToString())
                {
                    case "Asterisk":
                        return ToImageSource(System.Drawing.SystemIcons.Asterisk);

                    case "Error":
                        return ToImageSource(System.Drawing.SystemIcons.Error);

                    case "Exclamation":
                        return ToImageSource(System.Drawing.SystemIcons.Exclamation);

                    case "Hand":
                        return ToImageSource(System.Drawing.SystemIcons.Hand);

                    case "Information":
                        return ToImageSource(System.Drawing.SystemIcons.Information);

                    case "None":
                        return null;

                    case "Question":
                        return ToImageSource(System.Drawing.SystemIcons.Question);

                    case "Stop":
                        return ToImageSource(System.Drawing.SystemIcons.Shield);

                    case "Warning":
                        return ToImageSource(System.Drawing.SystemIcons.Warning);
                }

                return null;
            }

            private System.Windows.Media.ImageSource ToImageSource(System.Drawing.Icon icon)
            {
                System.Drawing.Bitmap image = icon.ToBitmap();

                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                              image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
                              System.Windows.Media.Imaging.BitmapSizeOptions.FromWidthAndHeight(image.Width, image.Height));
            }
            #endregion
        }
    }

    
}
