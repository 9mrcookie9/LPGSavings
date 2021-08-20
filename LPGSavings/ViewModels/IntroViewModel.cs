using System;
using System.Windows.Input;
using LPGSavings.Commands.Intro;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class IntroViewModel : BaseViewModel
    {
        private uint _odometer;
        public uint Odometer
        {
            get => _odometer;
            set => SetProperty(ref _odometer, value);
        }

        private uint _odometerLPG;
        public uint OdometerLPG
        {
            get => _odometerLPG;
            set => SetProperty(ref _odometerLPG, value);
        }

        private DateTime _dateOfInstallation;
        public DateTime DateOfInstallation
        {
            get => _dateOfInstallation;
            set => SetProperty(ref _dateOfInstallation, value);
        }

        public ICommand CarCreationMoveToSecondStep { get; set; }
        public ICommand CreateCarCommand { get; set; }
        public ICommand NavigateAfterCarCreationCommand { get; set; }
        public IntroViewModel()
        {
            CarCreationMoveToSecondStep = new CarCreationMoveToSecondStepCommand(this);
        }
    }
}
