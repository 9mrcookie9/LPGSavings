using System;
using LPGSavings.Models;
using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public sealed class IsFloatRule : IValidationRule<string>, IValidationMessage
    {
        private IsFloatRule() { }
        public static IValidationRule<string> Create() => new IsFloatRule();
        public string ValidationMessage { get; private set; }

        public bool Check(string value)
        {
            try
            {
                var result = float.Parse(value, System.Globalization.NumberStyles.Currency);
            }
            catch (FormatException)
            {
                ValidationMessage = "Nieprawidłowy format wartości!";
                return false;
            }
            catch (OverflowException)
            {
                ValidationMessage = "Wprowadź wartość z zakresu float!";
                return false;
            }
            catch (Exception)
            {
                ValidationMessage = "Wprowadź tylko liczby!";
                return false;
            }
            return true;
        }

    }
}
