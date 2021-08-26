using System.Windows.Input;

using LPGSavings.Commands.Intro;
using LPGSavings.Services;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class SecondStepViewModel : BaseViewModel, ICarInfoViewModel
    {
        public CarInfoViewModel Car { get; }
        public ICommand NavigateAfterCarCreationCommand { get; set; }
        public ICommand CreateCarCommand { get; set; }
        public SecondStepViewModel(CarInfoViewModel car)
        {
            Car = car;
            NavigateAfterCarCreationCommand = new NavigateAfterCarCreationCommand(this);
            CreateCarCommand = new CreateCarCommand(this,new CarService(),new FuelingService(),NavigateAfterCreation);
        }
        void NavigateAfterCreation() => NavigateAfterCarCreationCommand.Execute(null);
    }
}
