using System;
using LPGSavings.Validators.Base;
using LPGSavings.Validators.Rules;
using Xamarin.Forms;

namespace LPGSavings.Models.Forms
{
    public class FuelingForm : BindableObject
    {
        private decimal _litersLPG;
        public decimal LitersLPG
        {
            get => _litersLPG;
            set {
                _litersLPG = value;
                OnPropertyChanged(nameof(LitersRequired));
                OnPropertyChanged(nameof(LitersLPG));
            }
        }
        public ValidatableObject<decimal> PriceLPGValidatable { get; } = new ValidatableObject<decimal>(Models.DefaultIntroValues.LPG_PRICE)
            .AddRule(IsGreaterThanZero<decimal>.Create());
        public decimal PriceLPG
        {
            get => PriceLPGValidatable.Value;
            set
            {
                PriceLPGValidatable.Value = value;
                OnPropertyChanged(nameof(PriceLPG));
                OnPropertyChanged(nameof(IsValid));
            }
        }
        private decimal _litersPB;
        public decimal LitersPB
        {
            get => _litersPB;
            set
            {
                _litersPB = value;
                OnPropertyChanged(nameof(LitersRequired));
                OnPropertyChanged(nameof(LitersPB));
            }
        }
        private decimal _pricePB = Models.DefaultIntroValues.PB_PRICE;
        public decimal PricePB
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
