using System;
using System.Threading.Tasks;
using LPGSavings.Domain;

namespace LPGSavings.Services
{
    public interface ICarService
    {
        Task InitializeCar(uint distance, uint firstDistance, uint distanceLPG, uint firstDistanceLPG, decimal systemPrice, float systemCapacity, DateTime installationDate);
        Car GetCar();
        Task AddService(ServiceType serviceType, DateTime dateOfOccure, uint odometerValue, decimal price, string description);
    }
}
