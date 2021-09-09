using System;
using LPGSavings.Validators.Base;
using LPGSavings.Validators.Rules;
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

        public ValidatableObject<float> AveragePriceLPGValidatable { get; } = new ValidatableObject<float>(
            Models.DefaultIntroValues.LPG_PRICE
        ).AddRule(IsGreaterThanZero<float>.Create());
        public float AveragePriceLPG 
        {
            get => AveragePriceLPGValidatable.Value;
            set {
                AveragePriceLPGValidatable.Value = value;
                OnPropertyChanged(nameof(AveragePriceLPG));
                OnPropertyChanged(nameof(IsValid));
            }
        }


        private float _installationCost = 0;
        public float InstallationCost
        {
            get => _installationCost;
            set => SetProperty(ref _installationCost, value);
        }

        public ValidatableObject<float> SystemCapacityValidatable { get; } = new ValidatableObject<float>(0)
            .AddRule(IsGreaterThanZero<float>.Create());
        public float SystemCapacity
        {
            get => SystemCapacityValidatable.Value;
            set {
                SystemCapacityValidatable.Value = value;
                OnPropertyChanged(nameof(SystemCapacity));
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private float _maintenanceCosts = 0;
        public float MaintenanceCosts
        {
            get => _maintenanceCosts;
            set => SetProperty(ref _maintenanceCosts, value);
        }

        public bool IsValid => AveragePriceLPGValidatable.IsValid && SystemCapacityValidatable.IsValid;
    }
}
