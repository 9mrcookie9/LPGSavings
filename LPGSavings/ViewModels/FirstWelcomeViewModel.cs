using System.Windows.Input;
using LPGSavings.Commands.Intro;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class FirstWelcomeViewModel : BaseViewModel
    {
        public ICommand OpenCarCreationFirstStepCommand { get; }
        public FirstWelcomeViewModel()
        {
            OpenCarCreationFirstStepCommand = new OpenCarCreationFirstStepCommand(this);
        }
    }
}
