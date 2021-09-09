namespace LPGSavings.Validators.Base
{
    public interface IValidationRule<in T>
    {
        string ValidationMessage { get; }
        bool Check(T value);
    }
}
