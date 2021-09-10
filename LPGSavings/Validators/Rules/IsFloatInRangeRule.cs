using System;
using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public sealed class IsFloatInRangeRule : IValidationRule<string>, IValidationMessage
    {
        private IsFloatInRangeRule(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public float MinValue { get; }
        public float MaxValue { get; }
        public static IValidationRule<string> Create(float min, float max) => new IsFloatInRangeRule(min, max);
        public string ValidationMessage { get; private set; }

        public bool Check(string value)
        {
            try
            {
                var result = float.Parse(value, System.Globalization.NumberStyles.Currency);
                if (result < MinValue || result > MaxValue)
                {
                    throw new OverflowException();
                }
            }
            catch (ArgumentNullException)
            {
                ValidationMessage = "Uzupełnij pole!";
                return false;
            }
            catch (FormatException)
            {
                ValidationMessage = "Nieprawidłowy format wartości!";
                return false;
            }
            catch (OverflowException)
            {
                ValidationMessage = $"Wprowadź wartość z zakresu {MinValue} - {MaxValue}!";
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
