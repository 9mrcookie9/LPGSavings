using System;
using LPGSavings.Validators.Base;

namespace LPGSavings.Validators.Rules
{
    public class IsNotNullRule<T> : IValidationRule<T>, IValidationMessage
    {
        public static IValidationRule<T> Create() => new IsNotNullRule<T>();
        public string ValidationMessage => LPGSavings.Resx.Validators.IsNotNullRule.IsNotNullRuleResource.Message;

        public bool Check(T value)
        {
            return value is not null && value is string str && !string.IsNullOrWhiteSpace(str);
        }
    }
}
