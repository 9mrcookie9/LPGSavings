namespace LPGSavings.Validators.Base
{
    public static class ValidatableObjectExtension
    {
        public static ValidatableObject<T> AddRule<T>(this ValidatableObject<T> validatableObject, IValidationRule<T> rule)
        {
            validatableObject.Validations.Add(rule);
            validatableObject.Validate();
            return validatableObject;
        }
    }
}
