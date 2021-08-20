namespace LPGSavings.Domain
{
    public class FuelingInfo
    {
        public float Liters { get; private set; }
        public decimal Price { get; private set; }
        private FuelingInfo() { }
        public FuelingInfo(float liters, decimal price)
        {
            Liters = liters;
            Price = price;
        }
    }
}
