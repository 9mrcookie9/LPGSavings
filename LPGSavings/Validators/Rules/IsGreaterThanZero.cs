using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public class IsGreaterThanZero<T> : IValidationRule<T>, IValidationMessage
    {
        public static IValidationRule<T> Create() => new IsGreaterThanZero<T>();

        public string ValidationMessage => LPGSavings.Resx.Validators.IsGreaterThanZero.IsGreaterThanZeroResource.Message;
        public bool Check(T value)
        {
            if (value is int iValue)
            {
                return iValue > 0;
            }
            else if(value is uint uiValue)
            {
                return uiValue > 0;
            }
            else if (value is double dValue)
            {
                return dValue > 0;
            }
            else if (value is float fValue)
            {
                return fValue > 0;
            }
            else if (value is decimal dcValue)
            {
                return dcValue > 0;
            }
            return false;
        }
    }
}
