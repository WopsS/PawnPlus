using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PawnPlus.WPF
{
    /// <summary>
    /// Define the base class of ViewModel.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;

        /// <summary>
        /// The title of the view.
        /// </summary>
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }

        /// <summary>
        /// Change the property value and call <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="storage"/> and the <paramref name="value"/>.</typeparam>
        /// <param name="storage">Reference to the current value.</param>
        /// <param name="value">New value to be set.</param>
        /// <param name="propertyName">The name of the property to raise the PropertyChanged event for.</param>
        /// <returns>True if value was changed, false otherwise.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value) == true)
            {
                return false;
            }

            storage = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }
    }
}