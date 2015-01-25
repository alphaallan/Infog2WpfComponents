using System;
using System.Collections.Generic;
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
    public class StickyNote : Control
    {
        static StickyNote()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StickyNote), new FrameworkPropertyMetadata(typeof(StickyNote)));
        }

        #region Constructors
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="Text">Texto da Nota</param>
        /// <param name="Header">Titulo da Nota</param>
        /// <param name="Datecreated">Data e hora de criação da nota</param>
        public StickyNote(string Text, string Header, DateTime DateCreated)
        {
            this.Text = Text;
            this.Header = Header;
            this.DateCreated = DateCreated;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="Text">Texto da Nota</param>
        /// <param name="Header">Titulo da Nota</param>
        public StickyNote(string Text, string Header)
            : this(Text, Header, DateTime.Now)
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="Text">Texto da Nota</param>
        public StickyNote(string Text) 
            : this(Text, string.Empty, DateTime.Now)
        {

        }

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public StickyNote()
            : this(string.Empty, string.Empty, DateTime.Now)
        {

        }
        #endregion Constructors

        #region Behavior
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(StickyNote), new PropertyMetadata(false));


        #endregion Behavior

        #region Layout


        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)GetValue(TextWrappingProperty); }
            set { SetValue(TextWrappingProperty, value); }
        }
        public static readonly DependencyProperty TextWrappingProperty =
            DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(StickyNote), new PropertyMetadata(TextWrapping.Wrap));

        
        #endregion Layout

        #region Dados
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(StickyNote), new PropertyMetadata("Nova Nota"));
        

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(StickyNote), new PropertyMetadata(""));

        public DateTime DateCreated
        {
            get { return (DateTime)GetValue(DateCreatedProperty); }
            set { SetValue(DateCreatedProperty, value); }
        }
        public static readonly DependencyProperty DateCreatedProperty =
            DependencyProperty.Register("DateCreated", typeof(DateTime), typeof(StickyNote), new PropertyMetadata(DateTime.Now));

        #endregion Dados

        #region Overrides
        public override string ToString()
        {
            return this.DateCreated + " - " + this.Header + " \r\n" + this.Text;
        }
        #endregion Overrides
    }
}
