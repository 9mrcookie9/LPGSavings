namespace LPGSavings.Domain
{
    public class FuelingInfo
    {
        public int FuelingInfoId { get; private set; }
        public decimal Liters { get; private set; }
        public decimal Price { get; private set; }
        private FuelingInfo() { }
        public FuelingInfo(decimal liters, decimal price)
        {
            Liters = liters;
            Price = price;
        }
    }
}
