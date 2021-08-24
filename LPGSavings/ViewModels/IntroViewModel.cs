using System;
using System.Windows.Input;

using LPGSavings.Commands.Intro;
using LPGSavings.Services;
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

        private decimal _averagePriceLPG = Models.DefaultIntroValues.LPG_PRICE;
        public decimal AveragePriceLPG
        {
            get => _averagePriceLPG;
            set => SetProperty(ref _averagePriceLPG, value);
        }


        private decimal _installationCost;
        public decimal InstallationCost
        {
            get => _installationCost;
            set => SetProperty(ref _installationCost, value);
        }
        
        private float _systemCapacity;
        public float SystemCapacity
        {
            get => _systemCapacity;
            set => SetProperty(ref _systemCapacity, value);
        }
        private decimal _maintenanceCosts;
        public decimal MaintenanceCosts
        {
            get => _maintenanceCosts;
            set => SetProperty(ref _maintenanceCosts, value);
        }
        public ICommand CarCreationMoveToSecondStep { get; set; }
        public ICommand CreateCarCommand { get; set; }
        public ICommand NavigateAfterCarCreationCommand { get; set; }
        public IntroViewModel()
        {
            CreateCarCommand = new CreateCarCommand(this,new CarService(),new FuelingService(),NavigateAfterCreation);
            CarCreationMoveToSecondStep = new CarCreationMoveToSecondStepCommand(this);
        }

        void NavigateAfterCreation() => NavigateAfterCarCreationCommand.Execute(null);
    }
}
