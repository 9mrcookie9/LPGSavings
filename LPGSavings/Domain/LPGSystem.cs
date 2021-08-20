using System;

namespace LPGSavings.Domain
{
    public class LPGSystem
    {
        public decimal Price { get; private set; }
        public float Capacity { get; private set; }
        public DateTime InstallationDate { get; private set; }

        private LPGSystem() { }
        public LPGSystem(decimal price, float capacity, DateTime installationDate)
        {
            Price = price;
            Capacity = capacity;
            InstallationDate = installationDate;
        }

    }
}
