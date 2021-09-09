using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LPGSavings.Validators.Base
{
    public class ValidatableObject<T> : INotifyPropertyChanged, IValidity
    {
        private List<string> _errors;
        private T _value;
        private bool _isValid;

        public List<IValidationRule<T>> Validations { get; }

        public List<string> Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                OnPropertyChanged(nameof(Errors));
            }
        }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                Validate();
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged(nameof(IsValid));
                OnPropertyChanged(nameof(IsInvalid));
            }
        }

        public bool IsInvalid => !IsValid;

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            Validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
        /// <param name="backingStore">Backing store.</param>
        /// <param name="value">Value.</param>
        /// <param name="validateValue">Validates value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <param name="onChanged">On changed.</param>
        /// <typeparam name="PropType">The 1st type parameter.</typeparam>
        protected virtual bool SetProperty<PropType>(
            ref PropType backingStore, PropType value,
            Action? onChanged = null,
            Func<PropType, PropType, bool>? validateValue = null,
            [CallerMemberName] string propertyName = "")
        {
            //if value didn't change
            if (EqualityComparer<PropType>.Default.Equals(backingStore, value))
            {
                return false;
            }
            //if value changed but didn't validate
            if (!(validateValue?.Invoke(backingStore, value)) ?? true)
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
