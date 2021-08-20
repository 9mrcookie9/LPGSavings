using System;

namespace LPGSavings.Domain
{
    public class ServiceEntry
    {
        public ServiceEntry(ServiceType serviceType, DateTime dateOfOccure, uint odometerValue, decimal price, string description)
        {
            ServiceType = serviceType;
            DateOfOccure = dateOfOccure;
            OdometerValue = odometerValue;
            Price = price;
            Description = description;
        }

        public ServiceType ServiceType { get; private set; }
        public DateTime DateOfOccure { get; private set; }
        public uint OdometerValue { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; set; }
    }
}
