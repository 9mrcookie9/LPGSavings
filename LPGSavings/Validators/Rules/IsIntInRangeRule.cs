using System;
using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public sealed class IsIntInRangeRule : IValidationRule<string>, IValidationMessage
    {
        private IsIntInRangeRule(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public int MinValue { get; }
        public int MaxValue { get; }
        public static IValidationRule<string> Create(int min, int max) => new IsIntInRangeRule(min, max);
        public string ValidationMessage { get; private set; }

        public bool Check(string value)
        {
            try
            {
                var result = int.Parse(value);
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
