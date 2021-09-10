using System;
using LPGSavings.Models;
using LPGSavings.Validators.Base;
using LPGSavings.Validators.Rules;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class CarInfoViewModel : BaseViewModel
    {

        private DateTime _dateOfInstallation = DateTime.Now;
        public DateTime DateOfInstallation
        {
            get => _dateOfInstallation;
            set => SetProperty(ref _dateOfInstallation, value);
        }

        public ValidatableTextValueHolder<uint> OdometerValidatable { get; } = new ValidatableTextValueHolder<uint>(
             new UIntTextHolder { Text = Models.DefaultIntroValues.Zero }
         ).AddRule(IsIntInRangeRule.Create(0, int.MaxValue));

        public ITextValueHolder<uint> Odometer => OdometerValidatable.TextValue;

        public ValidatableTextValueHolder<uint> OdometerLPGValidatable { get; } = new ValidatableTextValueHolder<uint>(
             new UIntTextHolder { Text = Models.DefaultIntroValues.Zero }
         ).AddRule(IsIntInRangeRule.Create(0, int.MaxValue));

        public ITextValueHolder<uint> OdometerLPG => OdometerLPGValidatable.TextValue;

        public ValidatableTextValueHolder<float> AveragePriceLPGValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.LPG_PRICE.ToString() }
        ).AddRule(IsFloatInRangeRule.Create(0, 1024));

        public ITextValueHolder<float> AveragePriceLPG => AveragePriceLPGValidatable.TextValue;

        public ValidatableTextValueHolder<float> InstallationCostValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.Zero }
        ).AddRule(IsFloatInRangeRule.Create(0, 100000));

        public ITextValueHolder<float> InstallationCost => InstallationCostValidatable.TextValue;


        public ValidatableTextValueHolder<float> SystemCapacityValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.Zero }
        ).AddRule(IsFloatInRangeRule.Create(1, 100000));

        public ITextValueHolder<float> SystemCapacity => SystemCapacityValidatable.TextValue;


        public ValidatableTextValueHolder<float> MaintenanceCostsValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.Zero }
        ).AddRule(IsFloatInRangeRule.Create(0, 100000));

        public ITextValueHolder<float> MaintenanceCosts => MaintenanceCostsValidatable.TextValue;

        public bool IsValid => AveragePriceLPGValidatable.IsValid && SystemCapacityValidatable.IsValid
            && InstallationCostValidatable.IsValid && MaintenanceCostsValidatable.IsValid
            && OdometerLPGValidatable.IsValid && OdometerValidatable.IsValid;
    }
}
