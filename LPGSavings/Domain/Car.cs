using System;
using System.Collections.Generic;

namespace LPGSavings.Domain
{
    public class Car
    {
        public int CarId { get; private set; }
        public Odometer Odometer { get; private set; }
        public LPGSystem LPG { get; private set; }
        private List<ServiceEntry> _serviceHistory;
        public IReadOnlyList<ServiceEntry> ServiceHistory => _serviceHistory;

        private List<FuelingEntry> _fuelingHistory;
        public IReadOnlyList<FuelingEntry> FuelingHistory => _fuelingHistory;

        private Car() {
            _fuelingHistory = new List<FuelingEntry>();
        }
        public Car(uint distance, uint firstDistance, uint distanceLPG, uint firstDistanceLPG, float systemPrice, float systemCapacity,DateTime installationDate) : this()
        {
            Odometer = new Odometer(distance, firstDistance, distanceLPG, firstDistanceLPG);
            LPG = new LPGSystem(systemPrice,systemCapacity, installationDate);
        }

        public void AddServiceEntry(ServiceType serviceType, DateTime dateOfOccure, uint odometerValue, float price, string description)
        {
            var serviceEntry = new ServiceEntry(serviceType,dateOfOccure,odometerValue,price,description);
            _serviceHistory = new List<ServiceEntry>(_serviceHistory) { serviceEntry };
        }

        public void AddFueling(float litersLPG, float priceLPG, float litersPB, float pricePB, uint odometer, DateTime dateTime)
        {
            var fuelingEntry = new FuelingEntry(litersLPG, priceLPG, litersPB, pricePB, odometer, dateTime);
            _fuelingHistory = new List<FuelingEntry>(_fuelingHistory) { fuelingEntry };
        }
    }
}
