namespace LPGSavings.Domain
{
    public class FuelingInfo
    {
        public int FuelingInfoId { get; private set; }
        public float Liters { get; private set; }
        public float Price { get; private set; }
        private FuelingInfo() { }
        public FuelingInfo(float liters, float price)
        {
            Liters = liters;
            Price = price;
        }

        public float Sum => Liters * Price;
    }
}
