using System;

namespace LPGSavings.Domain
{
    public class LPGSystem
    {
        public int LPGSystemId { get; private set; }
        public decimal Price { get; private set; }
        public decimal Capacity { get; private set; }
        public DateTime InstallationDate { get; private set; }

        private LPGSystem() { } 
        public LPGSystem(decimal price, decimal capacity, DateTime installationDate)
        {
            Price = price;
            Capacity = capacity;
            InstallationDate = installationDate;
        }

    }
}
