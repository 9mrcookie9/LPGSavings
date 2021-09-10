using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.CommunityToolkit.Helpers;

namespace LPGSavings.Models
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {


        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="validateValue">Validates value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected virtual bool SetProperty<T>(
            ref T backingStore, T value,
            Action? onChanged = null,
            Func<T, T, bool>? validateValue = null,
            [CallerMemberName] string propertyName = "")
        {
            //if value didn't change
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            //if value changed but didn't validate
            if (validateValue != null && !validateValue(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        /// 
        private readonly DelegateWeakEventManager _propertyChangedEventManager = new DelegateWeakEventManager();

        public event PropertyChangedEventHandler? PropertyChanged
        {
            add => _propertyChangedEventManager.AddEventHandler(value);
            remove => _propertyChangedEventManager.RemoveEventHandler(value);
        }
        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            _propertyChangedEventManager.RaiseEvent(this, new PropertyChangedEventArgs(propertyName), nameof(PropertyChanged));
        }
    }
}
