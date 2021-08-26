using System.Windows.Input;

using LPGSavings.Commands.Intro;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class FirstStepViewModel : BaseViewModel, ICarInfoViewModel
    {
        public ICommand CarCreationMoveToSecondStep { get; }
        public CarInfoViewModel Car { get; } = new CarInfoViewModel();

        public FirstStepViewModel()
        {
            CarCreationMoveToSecondStep = new CarCreationMoveToSecondStepCommand(this);

        }
    }
}
