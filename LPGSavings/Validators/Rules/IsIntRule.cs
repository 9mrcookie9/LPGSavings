using System;
using LPGSavings.Models;
using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public class IsIntRule : IValidationRule<string>, IValidationMessage
    {
        public string ValidationMessage { get; private set; }

        public bool Check(string value)
        {
            try
            {
                var result = int.Parse(value);
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
