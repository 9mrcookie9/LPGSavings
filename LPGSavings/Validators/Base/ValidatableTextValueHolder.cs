using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LPGSavings.Models;

namespace LPGSavings.Validators.Base
{
    public class ValidatableTextValueHolder<T> : NotifyPropertyChanged, IValidity
    {
        private List<string> _errors;
        private bool _isValid;

        public List<IValidationRule<string>> Validations { get; }

        public List<string> Errors
        {
            get => _errors;
            set
            {
                _errors = value;
                OnPropertyChanged(nameof(Errors));
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
        public ITextValueHolder<T> TextValue { get; }
        public ValidatableTextValueHolder(ITextValueHolder<T> textValueHolder)
        {
            TextValue = textValueHolder;
            _isValid = true;
            _errors = new List<string>();
            Validations = new List<IValidationRule<string>>();
            TextValue.PropertyChanged += TextPropertyChanged;
        }

        private void TextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Validate();
        }
        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = Validations.Where(v => !v.Check(TextValue.Text))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();
            return this.IsValid;
        }
    }
}
