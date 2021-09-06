using System;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class CarInfoViewModel : BaseViewModel
    {
        private uint _odometer = 0;
        public uint Odometer
        {
            get => _odometer;
            set => SetProperty(ref _odometer, value);
        }

        private uint _odometerLPG = 0;
        public uint OdometerLPG
        {
            get => _odometerLPG;
            set => SetProperty(ref _odometerLPG, value);
        }

        private DateTime _dateOfInstallation = DateTime.Now;
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


        private decimal _installationCost = 0;
        public decimal InstallationCost
        {
            get => _installationCost;
            set => SetProperty(ref _installationCost, value);
        }

        private decimal _systemCapacity = 0;
        public decimal SystemCapacity
        {
            get => _systemCapacity;
            set => SetProperty(ref _systemCapacity, value);
        }
        private decimal _maintenanceCosts = 0;
        public decimal MaintenanceCosts
        {
            get => _maintenanceCosts;
            set => SetProperty(ref _maintenanceCosts, value);
        }
    }
}
