using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfoG2WpfControls.MyBind
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Função para notificar a mudança de uma propriedade para o uso de Binding
        /// </summary>
        /// <param name="prop">Nome da propriedade que se deseja notificar a mudança</param>
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Classe de Par Chave Valor genérica, implementa notificação de mudança para binding
        /// Implementa hashCode pela chave e função Equals que compara apenas a chave para definir iqualdade
        /// </summary>
        /// <typeparam name="Tkey"> Tipo da Chave do item</typeparam>
        /// <typeparam name="Tvalue"> Tipo do valor </typeparam>
        public class KeyValuePair<Tkey, Tvalue> : INotifyPropertyChanged
        {
            public KeyValuePair(Tkey key, Tvalue val)
            {
                Key = key;
                Value = val;
            }

            public Tkey Key
            {
                get { return _Key; }
                set
                {
                    _Key = value;
                    if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("Key")); }
                }
            }

            public Tvalue Value
            {
                get { return _Value; }
                set
                {
                    _Value = value;
                    if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs("Value")); }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public override string ToString()
            {
                return this.Key.ToString() + " - " + this.Value.ToString();
            }
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                KeyValuePair<Tkey, Tvalue> objCast = obj as KeyValuePair<Tkey, Tvalue>;
                if (objCast == null) return false;
                else return Equals(objCast);
            }
            public override int GetHashCode()
            {
                return Key.GetHashCode();
            }
            public bool Equals(KeyValuePair<Tkey, Tvalue> other)
            {
                if (other == null) return false;
                return (this.Key.Equals(other.Key));
            }

            private Tkey _Key;
            private Tvalue _Value;
        }


        /// <summary>
        /// Atalho para criar uma colleção observável de KeyValuePair (ObservableCollection)
        /// </summary>
        /// <typeparam name="Tkey"> Tipo da Chave do item</typeparam>
        /// <typeparam name="Tvalue"> Tipo do valor </typeparam>
        public class KeyValueCollection<Tkey, Tvalue> : ObservableCollection<KeyValuePair<Tkey, Tvalue>>
        {
            public Tvalue this[Tkey key]
            {
                get
                {
                    try
                    {
                        return this.Where(x => x.Key.Equals(key)).First().Value;
                    }
                    catch
                    {
                        throw new ArgumentOutOfRangeException("Key Not Found");
                    }
                }
                set
                {
                    try
                    {
                        this.Where(x => x.Key.Equals(key)).First().Value = value;
                    }
                    catch
                    {
                        throw new ArgumentOutOfRangeException("Key Not Found");
                    }
                }
            }

            public KeyValuePair<Tkey, Tvalue> GetByKey(Tkey key)
            {
                try
                {
                    return this.Where(x => x.Key.Equals(key)).First();
                }
                catch
                {
                    throw new ArgumentOutOfRangeException("Key Not Found");
                }
            }

            public KeyValuePair<Tkey, Tvalue> GetByIndex(int index)
            {
                return base[index];
            }
        }

        /// <summary>
        /// Implementação concreta da interface ICommand para uso em Bindings de comandos
        /// nas camadas do padrão MVVM
        /// Retirado do Exemplo de MVVM provido pela Microsoft
        /// https://code.msdn.microsoft.com/windowsdesktop/Easy-MVVM-Examples-fb8c409f
        /// </summary>
        public class RelayCommand : ICommand
        {
            #region Fields

            readonly Action<object> _execute;
            readonly Predicate<object> _canExecute;

            #endregion // Fields

            #region Constructors

            public RelayCommand(Action<object> execute)
                : this(execute, null)
            {
            }

            public RelayCommand(Action<object> execute, Predicate<object> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }
            #endregion // Constructors

            #region ICommand Members

            public bool CanExecute(object param)
            {
                return _canExecute == null ? true : _canExecute(param);
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object param)
            {
                _execute(param);
            }

            #endregion // ICommand Members
        }

        public event EventHandler<MoveFocusEventArgs> MoveFocus;

        void RaiseMoveFocus(string focusedProperty)
        {
            var handler = this.MoveFocus;
            if (handler != null)
            {
                var args = new MoveFocusEventArgs(focusedProperty);
                handler(this, args);
            }
        }

    }
}
