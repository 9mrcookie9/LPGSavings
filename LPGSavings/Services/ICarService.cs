using System;
using System.Threading.Tasks;
using LPGSavings.Domain;

namespace LPGSavings.Services
{
    public interface ICarService
    {
        Task InitializeCar(uint distance, uint distanceLPG, float systemPrice, float systemCapacity, DateTime installationDate);
        Task<Car> GetCar();
        Task AddService(ServiceType serviceType, DateTime dateOfOccure, uint odometerValue, float price, string description);
    }
}
