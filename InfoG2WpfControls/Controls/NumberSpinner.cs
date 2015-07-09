using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace InfoG2WpfControls
{
    public class NumberSpinner : Control
    {
        static NumberSpinner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberSpinner), new FrameworkPropertyMetadata(typeof(NumberSpinner)));
        }

        public NumberSpinner()
        {
            UpDownManager = new UpDownLink(ManageUpDown);

            var temp = new KeyBinding();
            temp.Key = Key.Up;
            temp.Command = UpDownManager;
            temp.CommandParameter = "UP";
            this.InputBindings.Add(temp);
            
            temp = new KeyBinding();
            temp.Key = Key.Down;
            temp.Command = UpDownManager;
            temp.CommandParameter = "DOWN";
            this.InputBindings.Add(temp);
        }

        #region Brushes
        /// <summary>
        /// Cor dos botões
        /// </summary>
        public Brush ButtonColor
        {
            get { return (Brush)GetValue(ButtonColorProperty); }
            set { SetValue(ButtonColorProperty, value); }
        }
        public static readonly DependencyProperty ButtonColorProperty =
            DependencyProperty.Register("ButtonColor", typeof(Brush), typeof(NumberSpinner), new PropertyMetadata(new BrushConverter().ConvertFromString("#D0D0D0")));

        /// <summary>
        /// Cor dos botões com o mouse sobre eles
        /// </summary>
        public Brush ButtonMouseOverColor
        {
            get { return (Brush)GetValue(ButtonMouseOverColorProperty); }
            set { SetValue(ButtonMouseOverColorProperty, value); }
        }
        public static readonly DependencyProperty ButtonMouseOverColorProperty =
            DependencyProperty.Register("ButtonMouseOverColor", typeof(Brush), typeof(NumberSpinner), new PropertyMetadata(new BrushConverter().ConvertFromString("#FF8A8A8A")));

        /// <summary>
        /// Cor dos botões quando pressionados
        /// </summary>
        public Brush ButtonPressedColor
        {
            get { return (Brush)GetValue(ButtonPressedColorProperty); }
            set { SetValue(ButtonPressedColorProperty, value); }
        }
        public static readonly DependencyProperty ButtonPressedColorProperty =
            DependencyProperty.Register("ButtonPressedColor", typeof(Brush), typeof(NumberSpinner), new PropertyMetadata(new BrushConverter().ConvertFromString("#FF767676")));

        /// <summary>
        /// Cor do controle quanto com o foco
        /// </summary>
        public Brush HaveFocusColor
        {
            get { return (Brush)GetValue(HaveFocusColorProperty); }
            set { SetValue(HaveFocusColorProperty, value); }
        }
        public static readonly DependencyProperty HaveFocusColorProperty =
            DependencyProperty.Register("HaveFocusColor", typeof(Brush), typeof(NumberSpinner), new PropertyMetadata(Brushes.LightYellow));
        #endregion Brushes

        #region Propriedades de Comportamento
        /// <summary>
        /// Ativa o dimencionamento automático da fonte
        /// </summary>
        public bool AutoSizeFont
        {
            get { return (bool)GetValue(AutoSizeFontProperty); }
            set { SetValue(AutoSizeFontProperty, value); }
        }
        public static readonly DependencyProperty AutoSizeFontProperty =
            DependencyProperty.Register("AutoSizeFont", typeof(bool), typeof(NumberSpinner), new PropertyMetadata(false));

        /// <summary>
        /// Impede a edição da caixa de texto
        /// </summary>
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(NumberSpinner), new PropertyMetadata(false));
        #endregion Propriedades de Comportamento

        #region Controle do Valor
        /// <summary>
        /// Colocar o controle no modo de ponto flutuante
        /// </summary>
        public bool FloatMode
        {
            get { return (bool)GetValue(FloatModeProperty); }
            set { SetValue(FloatModeProperty, value); }
        }
        public static readonly DependencyProperty FloatModeProperty =
            DependencyProperty.Register("FloatMode", typeof(bool), typeof(NumberSpinner), new PropertyMetadata(false));


        /// <summary>
        /// Colocar o controle no modo circular
        /// </summary>
        public bool Circular
        {
            get { return (bool)GetValue(CircularProperty); }
            set { SetValue(CircularProperty, value); }
        }
        public static readonly DependencyProperty CircularProperty =
            DependencyProperty.Register("Circular", typeof(bool), typeof(NumberSpinner), new PropertyMetadata(false));

        

        /// <summary>
        /// Passo de acrécimo do controle
        /// </summary>
        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(NumberSpinner), new PropertyMetadata(0.0));

        /// <summary>
        /// Valor minimo permitido pelo controle controle
        /// </summary>
        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(NumberSpinner), new PropertyMetadata(0.0));

        /// <summary>
        /// Valor máximo permitido pelo controle
        /// </summary>
        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(NumberSpinner), new PropertyMetadata(double.MaxValue));

        /// <summary>
        /// Valor atual do controle
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(NumberSpinner), new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        /// <summary>
        /// Commandoo executado para gerenciar mudar o valor pelo setas ou botões do controle
        /// </summary>
        public UpDownLink UpDownManager
        {
            get { return (UpDownLink)GetValue(UpDownManagerProperty); }
            set { SetValue(UpDownManagerProperty, value); }
        }
        public static readonly DependencyProperty UpDownManagerProperty =
            DependencyProperty.Register("UpDownManager", typeof(UpDownLink), typeof(NumberSpinner), new PropertyMetadata(null));
        #endregion Controle do Valor

        /// <summary>
        /// Raio das bordas da caixa de texto
        /// </summary>
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(double), typeof(NumberSpinner), new PropertyMetadata(2.0));

        /// <summary>
        /// Função de controle do valor
        /// </summary>
        private void ManageUpDown(string parameter)
        {
            double temp = Value;

            if (parameter == "UP") temp += (Step < 1 && !FloatMode) ? 1 : Step;
            else if (parameter == "DOWN") temp -= (Step < 1 && !FloatMode) ? 1 : Step;

            if (temp > MaxValue) temp = (Circular) ? MinValue : MaxValue;
            if (temp < MinValue) temp = (Circular) ? MaxValue : MinValue;

            Value = temp;
        }

        /// <summary>
        /// Classe auxiliar para possibilitar a ligação de um comando pelo template
        /// </summary>
        public class UpDownLink : ICommand
        {
            readonly Action<string> Handler;

            public UpDownLink(Action<string> handler)
            {
                Handler = handler;
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Handler(parameter as string);
            }
        }
    }
}
