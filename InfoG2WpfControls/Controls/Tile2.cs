﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfoG2WpfControls
{
    public class Tile2 : Button
    {
        static Tile2()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Tile2), new FrameworkPropertyMetadata(typeof(Tile2)));
        }

        //Propriedaes do titulo
        #region Label
        //Label colocada na tile
        [Category("Label")]
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(Tile2), new PropertyMetadata("Label"));

        //Template de aparencia do titulo
        [Category("Label")]
        public DataTemplate LabelTemplate
        {
            get { return (DataTemplate)GetValue(LabelTemplateProperty); }
            set { SetValue(LabelTemplateProperty, value); }
        }
        public static readonly DependencyProperty LabelTemplateProperty =
            DependencyProperty.Register("LabelTemplate", typeof(DataTemplate), typeof(Tile2), new UIPropertyMetadata(null));

        //Alinhamento horizontal do titulo
        [Category("Label")]
        public HorizontalAlignment LabelAlignment
        {
            get { return (HorizontalAlignment)GetValue(LabelAlignmentProperty); }
            set { SetValue(LabelAlignmentProperty, value); }
        }
        public static readonly DependencyProperty LabelAlignmentProperty =
            DependencyProperty.Register("LabelAlignment", typeof(HorizontalAlignment), typeof(Tile2), new PropertyMetadata(HorizontalAlignment.Left));
        #endregion Label

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
            DependencyProperty.Register("Icon", typeof(ImageSource), typeof(Tile2), new PropertyMetadata(null));
        #endregion Icon
    }
}
