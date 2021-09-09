using System;
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
                OnPropertyChanged(nameof(LitersLPG));
            }
        }
        private decimal _priceLPG = Models.DefaultIntroValues.LPG_PRICE;
        public decimal PriceLPG
        {
            get => _priceLPG;
            set
            {
                _priceLPG = value;
                OnPropertyChanged(nameof(PriceLPG));
            }
        }
        private decimal _litersPB;
        public decimal LitersPB
        {
            get => _litersPB;
            set
            {
                _litersPB = value;
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
        private uint _odometer;
        public uint Odometer
        {
            get => _odometer;
            set
            {
                _odometer = value;
                OnPropertyChanged(nameof(Odometer));
            }
        }
        private DateTime _dateOfOccure;
        public DateTime DateOfOccure
        {
            get => _dateOfOccure;
            set
            {
                _dateOfOccure = value;
                OnPropertyChanged(nameof(DateOfOccure));
            }
        }
    }
}
