using System;
using LPGSavings.Validators.Base;
using LPGSavings.Validators.Rules;
using Xamarin.Forms;

namespace LPGSavings.Models.Forms
{
    public class FuelingForm : BindableObject
    {
        private float _litersLPG = 0.0f;
        public float LitersLPG
        {
            get => _litersLPG;
            set {
                _litersLPG = value;
                OnPropertyChanged(nameof(LitersRequired));
                OnPropertyChanged(nameof(LitersLPG));
            }
        }
        public ValidatableObject<float> PriceLPGValidatable { get; } = new ValidatableObject<float>(Models.DefaultIntroValues.LPG_PRICE)
            .AddRule(IsGreaterThanZero<float>.Create());
        public float PriceLPG
        {
            get => PriceLPGValidatable.Value;
            set
            {
                PriceLPGValidatable.Value = value;
                OnPropertyChanged(nameof(PriceLPG));
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private float _litersPB;
        public float LitersPB
        {
            get => _litersPB;
            set
            {
                _litersPB = value;
                OnPropertyChanged(nameof(LitersRequired));
                OnPropertyChanged(nameof(LitersPB));
            }
        }
        private float _pricePB = Models.DefaultIntroValues.PB_PRICE;
        public float PricePB
        {
            get => _pricePB;
            set
            {
                _pricePB = value;
                OnPropertyChanged(nameof(PricePB));
            }
        } 
        public ValidatableObject<uint> OdometerValidatable { get; } = new ValidatableObject<uint>()
            .AddRule(IsGreaterThanZero<uint>.Create());
        public uint Odometer
        {
            get => OdometerValidatable.Value;
            set
            {
                OdometerValidatable.Value = value;
                OnPropertyChanged(nameof(Odometer));
                OnPropertyChanged(nameof(IsValid));
            }
        }
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
        public string LitersRequired => LitersLPG == 0 && LitersPB == 0 ? "Uzupełnij litry!" : null;
        public bool IsValid
        {
            get {
                if(LitersLPG == 0 && LitersPB == 0)
                {
                    OnPropertyChanged(nameof(LitersRequired));
                    return false;
                }
                return OdometerValidatable.IsValid && PriceLPGValidatable.IsValid;
            }
        }
    }
}
