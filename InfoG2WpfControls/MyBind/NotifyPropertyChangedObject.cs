using System;
using System.ComponentModel;

namespace InfoG2WpfControls.MyBind
{
    /// <summary>
    /// Base para objetos que tem a interface INotifyPropertyChanged
    /// </summary>
    public abstract class NotifyPropertyChangedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Seta o valor de uma propriedade fazendo a verificação de mudança do valor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value,
                                     [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// realiza a notificação de mudança de uma propriedade do objeto
        /// </summary>
        /// <param name="propertyName">Argumento opcional com o nome da propriedade, o valor padrão é o nome da propriedade de invocou o método</param>
        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public virtual void RaiseRefresh()
        {
            RaisePropertyChanged(string.Empty);
        }
    }
}
