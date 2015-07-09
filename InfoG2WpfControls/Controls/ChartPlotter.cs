using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace InfoG2WpfControls
{
    public class ChartPlotter : Control
    {
        static ChartPlotter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChartPlotter), new FrameworkPropertyMetadata(typeof(ChartPlotter)));
        }

        #region Gráfico
        [Category("Chart")]
        public List<System.Drawing.Point> Points
        {
            get { return (List<System.Drawing.Point>)GetValue(PointsProperty); }
            set { SetValue(PointsProperty, value); }
        }
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register("Points", typeof(List<System.Drawing.Point>), typeof(ChartPlotter), new FrameworkPropertyMetadata(null, Plot));

        [Category("Chart")]
        public ImageSource Chart
        {
            get { return (ImageSource)GetValue(ChartProperty); }
            set { SetValue(ChartProperty, value); }
        }
        public static readonly DependencyProperty ChartProperty =
            DependencyProperty.Register("Chart", typeof(ImageSource), typeof(ChartPlotter), new PropertyMetadata(null));

        [Category("Chart")]
        public System.Drawing.Brush ChartBackGround
        {
            get { return (System.Drawing.Brush)GetValue(ChartBackGroundProperty); }
            set { SetValue(ChartBackGroundProperty, value); }
        }
        public static readonly DependencyProperty ChartBackGroundProperty =
            DependencyProperty.Register("ChartBackGround", typeof(System.Drawing.Brush), typeof(ChartPlotter), new PropertyMetadata(System.Drawing.Brushes.White));

        [Category("Chart")]
        public System.Drawing.Pen ChartPen
        {
            get { return (System.Drawing.Pen)GetValue(ChartPenProperty); }
            set { SetValue(ChartPenProperty, value); }
        }
        public static readonly DependencyProperty ChartPenProperty =
            DependencyProperty.Register("ChartPen", typeof(System.Drawing.Pen), typeof(ChartPlotter), new PropertyMetadata(System.Drawing.Pens.Black));

        [Category("Chart")]
        public ChartPlotMode PlotMode
        {
            get { return (ChartPlotMode)GetValue(PlotModeProperty); }
            set { SetValue(PlotModeProperty, value); }
        }
        public static readonly DependencyProperty PlotModeProperty =
            DependencyProperty.Register("PlotMode", typeof(ChartPlotMode), typeof(ChartPlotter), new PropertyMetadata(ChartPlotMode.Line));

        #region Limites
        [Category("Chart")]
        public int ChartWidth
        {
            get { return (int)GetValue(ChartWidthProperty); }
            set { SetValue(ChartWidthProperty, value); }
        }
        public static readonly DependencyProperty ChartWidthProperty =
            DependencyProperty.Register("ChartWidth", typeof(int), typeof(ChartPlotter), new PropertyMetadata(100));

        [Category("Chart")]
        public int ChartHeight
        {
            get { return (int)GetValue(ChartHeightProperty); }
            set { SetValue(ChartHeightProperty, value); }
        }
        public static readonly DependencyProperty ChartHeightProperty =
            DependencyProperty.Register("ChartHeight", typeof(int), typeof(ChartPlotter), new PropertyMetadata(100));

        [Category("Chart")]
        public System.Drawing.Point OriginPosition
        {
            get { return (System.Drawing.Point)GetValue(OriginPositionProperty); }
            set { SetValue(OriginPositionProperty, value); }
        }
        public static readonly DependencyProperty OriginPositionProperty =
            DependencyProperty.Register("OriginPosition", typeof(System.Drawing.Point), typeof(ChartPlotter), new PropertyMetadata(new System.Drawing.Point(0, 0)));


        public float DotSize
        {
            get { return (float)GetValue(DotSizeProperty); }
            set { SetValue(DotSizeProperty, value); }
        }
        public static readonly DependencyProperty DotSizeProperty =
            DependencyProperty.Register("DotSize", typeof(float), typeof(ChartPlotter), new PropertyMetadata(2.0F));

        #endregion Limites

        #endregion Gráfico

        #region Régua

        #region Visual
        [Category("Ruler")]
        public bool DrawRuler
        {
            get { return (bool)GetValue(DrawRulerProperty); }
            set { SetValue(DrawRulerProperty, value); }
        }
        public static readonly DependencyProperty DrawRulerProperty =
            DependencyProperty.Register("DrawRuler", typeof(bool), typeof(ChartPlotter), new PropertyMetadata(true));

        [Category("Ruler")]
        public System.Drawing.Pen RulerPen
        {
            get { return (System.Drawing.Pen)GetValue(RulerPenProperty); }
            set { SetValue(RulerPenProperty, value); }
        }
        public static readonly DependencyProperty RulerPenProperty =
            DependencyProperty.Register("RulerPen", typeof(System.Drawing.Pen), typeof(ChartPlotter), new PropertyMetadata(System.Drawing.Pens.Gray));
        #endregion Visual

        #region Limites
        [Category("Ruler")]
        public int RulerStepY
        {
            get { return (int)GetValue(RulerStepYProperty); }
            set { SetValue(RulerStepYProperty, value); }
        }
        public static readonly DependencyProperty RulerStepYProperty =
            DependencyProperty.Register("RulerStepY", typeof(int), typeof(ChartPlotter), new PropertyMetadata(5));

        [Category("Ruler")]
        public int RulerStepX
        {
            get { return (int)GetValue(RulerStepXProperty); }
            set { SetValue(RulerStepXProperty, value); }
        }
        public static readonly DependencyProperty RulerStepXProperty =
            DependencyProperty.Register("RulerStepX", typeof(int), typeof(ChartPlotter), new PropertyMetadata(5));

        [Category("Ruler")]
        public int RulerTracesSize
        {
            get { return (int)GetValue(RulerTracesSizeProperty); }
            set { SetValue(RulerTracesSizeProperty, value); }
        }
        public static readonly DependencyProperty RulerTracesSizeProperty =
            DependencyProperty.Register("RulerTracesSize", typeof(int), typeof(ChartPlotter), new PropertyMetadata(5));
        #endregion Limites

        [Category("Ruler")]
        public List<string> ValuesY
        {
            get { return (List<string>)GetValue(ValuesYProperty); }
            set { SetValue(ValuesYProperty, value); }
        }
        public static readonly DependencyProperty ValuesYProperty =
            DependencyProperty.Register("ValuesY", typeof(List<string>), typeof(ChartPlotter), new PropertyMetadata(null));

        [Category("Ruler")]
        public List<string> ValuesX
        {
            get { return (List<string>)GetValue(ValuesXProperty); }
            set { SetValue(ValuesXProperty, value); }
        }
        public static readonly DependencyProperty ValuesXProperty =
            DependencyProperty.Register("ValuesX", typeof(List<string>), typeof(ChartPlotter), new PropertyMetadata(null));

        #endregion Régua

        #region Grid
        [Category("Grid")]
        public bool DrawGrid
        {
            get { return (bool)GetValue(DrawGridProperty); }
            set { SetValue(DrawGridProperty, value); }
        }
        public static readonly DependencyProperty DrawGridProperty =
            DependencyProperty.Register("DrawGrid", typeof(bool), typeof(ChartPlotter), new PropertyMetadata(true));

        [Category("Grid")]
        public System.Drawing.Pen GridPen
        {
            get { return (System.Drawing.Pen)GetValue(GridPenProperty); }
            set { SetValue(GridPenProperty, value); }
        }
        public static readonly DependencyProperty GridPenProperty =
            DependencyProperty.Register("GridPen", typeof(System.Drawing.Pen), typeof(ChartPlotter), new PropertyMetadata(System.Drawing.Pens.AliceBlue));

        [Category("Grid")]        
        public int GridStep
        {
            get { return (int)GetValue(GridStepProperty); }
            set { SetValue(GridStepProperty, value); }
        }
        public static readonly DependencyProperty GridStepProperty =
            DependencyProperty.Register("GridStep", typeof(int), typeof(ChartPlotter), new PropertyMetadata(10));
        #endregion Grid

        #region Funções
        private static void Plot(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ChartPlotter)
            {
                ChartPlotter _this = d as ChartPlotter;
                System.Drawing.Bitmap map;
                System.Drawing.Graphics gra;

                map = new System.Drawing.Bitmap(_this.ChartWidth, _this.ChartHeight);
                gra = System.Drawing.Graphics.FromImage(map);
                gra.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                gra.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                gra.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

                gra.FillRectangle(_this.ChartBackGround, 0, 0, _this.ChartWidth, _this.ChartHeight);

                if (_this.DrawGrid)
                {
                    for (int c = _this.GridStep; c < _this.ChartHeight; c += _this.GridStep) gra.DrawLine(_this.GridPen, 0, c, _this.ChartWidth, c);
                    for (int c = _this.GridStep; c < _this.ChartWidth; c += _this.GridStep) gra.DrawLine(_this.GridPen, c, 0, c, _this.ChartHeight);
                }

                if (_this.DrawRuler)
                {
                    gra.DrawLine(_this.RulerPen, _this.OriginPosition.X, _this.ChartHeight - _this.OriginPosition.Y, _this.OriginPosition.X, 0);
                    gra.DrawLine(_this.RulerPen, _this.OriginPosition.X, _this.ChartHeight - _this.OriginPosition.Y, 0, _this.ChartHeight - _this.OriginPosition.Y);
                    gra.DrawLine(_this.RulerPen, _this.OriginPosition.X, _this.ChartHeight - _this.OriginPosition.Y, _this.OriginPosition.X, _this.ChartHeight);
                    gra.DrawLine(_this.RulerPen, _this.OriginPosition.X, _this.ChartHeight - _this.OriginPosition.Y, _this.ChartWidth, _this.ChartHeight - _this.OriginPosition.Y);

                    for (int x = _this.OriginPosition.X + _this.RulerStepX; x < _this.ChartWidth; x += _this.RulerStepX)
                        gra.DrawLine(_this.RulerPen,
                                     x, _this.ChartHeight - _this.OriginPosition.Y - _this.RulerTracesSize, 
                                     x, _this.ChartHeight - _this.OriginPosition.Y + _this.RulerTracesSize);

                    for (int x = _this.OriginPosition.X - _this.RulerStepX; x > 0; x -= _this.RulerStepX)
                        gra.DrawLine(_this.RulerPen, 
                                     x, _this.ChartHeight - _this.OriginPosition.Y - _this.RulerTracesSize, 
                                     x, _this.ChartHeight - _this.OriginPosition.Y + _this.RulerTracesSize);

                    for (int y = _this.OriginPosition.Y + _this.RulerStepY; y < _this.ChartWidth; y += _this.RulerStepY)
                        gra.DrawLine(_this.RulerPen,
                                     _this.OriginPosition.X - _this.RulerTracesSize, y,
                                     _this.OriginPosition.X + _this.RulerTracesSize, y);

                    for (int y = _this.OriginPosition.Y - _this.RulerStepY; y > 0; y -= _this.RulerStepY)
                        gra.DrawLine(_this.RulerPen,
                                     _this.OriginPosition.X - _this.RulerTracesSize, y,
                                     _this.OriginPosition.X + _this.RulerTracesSize, y);
                    
                }

                if (_this.Points != null && _this.Points.Count > 0)
                {
                    int offsetX = _this.OriginPosition.X, 
                        offsetY = _this.ChartHeight - _this.OriginPosition.Y;

                    System.Drawing.Pen pen = _this.ChartPen;
                    List<System.Drawing.Point> points = _this.Points;
                    float dotSize = _this.DotSize;

                    switch (_this.PlotMode)
                    {
                        case ChartPlotMode.Dots:
                            for (int c = 0; c < _this.Points.Count; c++)
                                gra.FillEllipse(pen.Brush, offsetX + points[c].X - dotSize / 2, offsetY - points[c].Y - dotSize / 2, dotSize, dotSize);

                            break;

                        case ChartPlotMode.Line:
                            for (int c = 1; c < _this.Points.Count; c++)
                                gra.DrawLine(pen, offsetX + points[c - 1].X,
                                                  offsetY - points[c - 1].Y,
                                                  offsetX + points[c].X,
                                                  offsetY - points[c].Y);
                            break;

                        case ChartPlotMode.LineAndDots:
                            for (int c = 1; c < _this.Points.Count; c++)
                            {
                                gra.FillEllipse(pen.Brush, offsetX + points[c].X - dotSize / 2, offsetY - points[c].Y - dotSize / 2, dotSize, dotSize);
                                gra.DrawLine(pen, offsetX + points[c - 1].X,
                                                  offsetY - points[c - 1].Y,
                                                  offsetX + points[c].X,
                                                  offsetY - points[c].Y);
                            }
                            break;

                        case ChartPlotMode.Point:
                            for (int c = 0; c < _this.Points.Count; c++)
                                gra.FillRectangle(pen.Brush, offsetX + points[c].X, offsetY - points[c].Y, 1, 1);
                            break;
                    }
                    
                        
                }

                _this.Chart = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          map.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,
                          System.Windows.Media.Imaging.BitmapSizeOptions.FromWidthAndHeight(_this.ChartWidth, _this.ChartHeight));
            }
        }
        #endregion Funções
    }

    public enum ChartPlotMode
    {
        Line,
        Dots,
        Point,
        LineAndDots
    }
}
