using System;
using System.Linq;
using System.Threading.Tasks;
using LPGSavings.Domain;
using LPGSavings.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LPGSavings.Services
{
    public class CarService : ICarService
    {

        public async Task AddService(ServiceType serviceType, DateTime dateOfOccure, uint odometerValue, decimal price, string description)
        {
            using var context = new MainContext();
            var car = context.Cars.Include(a => a.ServiceHistory).First();
            car.AddServiceEntry(serviceType, dateOfOccure, odometerValue, price, description);
            await context.SaveChangesAsync();
        }

        public Car GetCar()
        {
            using var context = new MainContext();
            return context.Cars.First();
        }

        public async Task InitializeCar(uint distance, uint distanceLPG, decimal systemPrice, float systemCapacity, DateTime installationDate)
        {
            using var context = new MainContext();
            if (context.Cars.Count() > 0)
            {
                var toRemove = context.Cars.ToList();
                context.Cars.RemoveRange(toRemove);
            }
            var entity = new Car(distance, distance, distanceLPG, distanceLPG, systemPrice, systemCapacity, installationDate);
            context.Cars.Add(entity);
            await context.SaveChangesAsync();
        }
    }
}
