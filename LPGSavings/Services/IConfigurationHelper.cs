namespace LPGSavings.Services
{
    public interface IConfigurationHelper
    {
        bool IsCarCreated();
        void SetCarCreated(bool state = true);
    }
}
