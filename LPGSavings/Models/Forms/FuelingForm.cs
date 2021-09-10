using System;
using LPGSavings.Validators.Base;
using LPGSavings.Validators.Rules;
using Xamarin.Forms;

namespace LPGSavings.Models.Forms
{
    public class FuelingForm : BindableObject
    {
        public ValidatableTextValueHolder<float> LitersLPGValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.Zero }
        ).AddRule(IsFloatInRangeRule.Create(0, 1024));

        public ITextValueHolder<float> LitersLPG => LitersLPGValidatable.TextValue;


        public ValidatableTextValueHolder<float> PriceLPGValidatable { get; } = new ValidatableTextValueHolder<float>(
            new FloatTextHolder { Text = Models.DefaultIntroValues.LPG_PRICE.ToString() }
        ).AddRule(IsFloatInRangeRule.Create(0,1024));
         
        public ITextValueHolder<float> PriceLPG => PriceLPGValidatable.TextValue;

        public ValidatableTextValueHolder<float> LitersPBValidatable { get; } = new ValidatableTextValueHolder<float>(
             new FloatTextHolder { Text = Models.DefaultIntroValues.Zero }
         ).AddRule(IsFloatInRangeRule.Create(0, 1024));

        public ITextValueHolder<float> LitersPB => LitersPBValidatable.TextValue;


        public ValidatableTextValueHolder<float> PricePBValidatable { get; } = new ValidatableTextValueHolder<float>(
             new FloatTextHolder { Text = Models.DefaultIntroValues.PB_PRICE.ToString() }
         ).AddRule(IsFloatInRangeRule.Create(0, 1024));

        public ITextValueHolder<float> PricePB => PricePBValidatable.TextValue;

        public ValidatableTextValueHolder<uint> OdometerValidatable { get; } = new ValidatableTextValueHolder<uint>(
             new UIntTextHolder { Text = Models.DefaultIntroValues.Zero }
         ).AddRule(IsIntInRangeRule.Create(0, int.MaxValue));

        public ITextValueHolder<uint> Odometer => OdometerValidatable.TextValue;

        private DateTime _dateOfOccure = DateTime.Now;
        public DateTime DateOfOccure
        {
            get => _dateOfOccure;
            set
            {
                _dateOfOccure = value;
                OnPropertyChanged(nameof(DateOfOccure));
            }
        }
        public string LitersRequired => LitersLPG.Value == 0 && LitersPB.Value == 0 ? "Uzupełnij litry!" : null;
        public bool IsValid
        {
            get {
                if(LitersLPG.Value == 0 && LitersPB.Value == 0)
                {
                    OnPropertyChanged(nameof(LitersRequired));
                    return false;
                }
                return OdometerValidatable.IsValid && PriceLPGValidatable.IsValid
                    && OdometerValidatable.IsValid && PricePBValidatable.IsValid
                    && LitersPBValidatable.IsValid;
            }
        }
        public FuelingForm()
        {
            LitersPB.PropertyChanged += UpdateValid;
            LitersLPG.PropertyChanged += UpdateValid;
            OnPropertyChanged(nameof(IsValid));
        }

        private void UpdateValid(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(LitersRequired));
        }
    }
}
