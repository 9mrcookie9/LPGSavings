using Xamarin.Essentials;

namespace LPGSavings.Services
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private ConfigurationHelper()
        {

        }
        public static IConfigurationHelper CreateInstance() => new ConfigurationHelper();
        private const string CarCreationHolder = "CarCreationHolder";
        public bool IsCarCreated() => Preferences.Get(CarCreationHolder, false);

        public void SetCarCreated(bool state = true) => Preferences.Set(CarCreationHolder, state);
    }
}
