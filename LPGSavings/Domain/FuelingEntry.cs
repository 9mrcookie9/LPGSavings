using System;

namespace LPGSavings.Domain
{
    public class FuelingEntry
    {
        public FuelingInfo LPGInfo { get; private set; }
        public FuelingInfo PBInfo { get; private set; }
        public uint ActualOdometerDistance { get; private set; }
        public DateTime DateOfOccure { get; private set; }

        private FuelingEntry() { }
        public FuelingEntry(float litersLPG, decimal priceLPG, float litersPB, decimal pricePB,uint odometer, DateTime dateTime)
        {
            if (litersLPG > 0 || priceLPG > 0)
            {
                LPGInfo = new FuelingInfo(litersLPG,priceLPG);
            }
            if (litersPB > 0 || pricePB > 0)
            {
                PBInfo = new FuelingInfo(litersPB, pricePB);
            }
            ActualOdometerDistance = odometer;
            DateOfOccure = dateTime;
        }
    }
}
