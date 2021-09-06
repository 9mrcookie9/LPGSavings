using System;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels.Insert
{
    public class InsertFuelingViewModel : BaseViewModel
    {
        private uint _Odometer = 0;
        public uint Odometer
        {
            get => _Odometer;
            set => SetProperty(ref _Odometer, value);
        }

        private decimal _PriceLPG = Models.DefaultIntroValues.LPG_PRICE;
        public decimal PriceLPG
        {
            get => _PriceLPG;
            set => SetProperty(ref _PriceLPG, value);
        }

        private decimal _PricePB = Models.DefaultIntroValues.PB_PRICE;
        public decimal PricePB
        {
            get => _PricePB;
            set => SetProperty(ref _PricePB, value);
        }
        private decimal _LitersLPG = 0;
        public decimal LitersLPG
        {
            get => _LitersLPG;
            set => SetProperty(ref _LitersLPG, value);
        }
        private decimal _LitersPB = 0;
        public decimal LitersBP
        {
            get => _LitersPB;
            set => SetProperty(ref _LitersPB, value);
        }
        private DateTime _DateOfOccure = DateTime.Now;
        public DateTime DateOfOccure
        {
            get => _DateOfOccure;
            set => SetProperty(ref _DateOfOccure, value);
        }

        public InsertFuelingViewModel()
        {
        }
    }
}
