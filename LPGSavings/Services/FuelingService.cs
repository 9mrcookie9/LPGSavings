using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPGSavings.Domain;
using LPGSavings.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LPGSavings.Services
{
    public class FuelingService : IFuelingService
    {
        public async Task AddEntry(float litersLPG, decimal priceLPG, float litersPB, decimal pricePB, uint odometer, DateTime dateTime)
        {
            using var context = new MainContext();
            var car = context.Cars.Include(a => a.FuelingHistory).First();
            car.AddFueling(litersLPG, priceLPG, litersPB, pricePB, odometer, dateTime);
            await context.SaveChangesAsync();

        }

        public IReadOnlyList<FuelingEntry> GetAll()
        {
            using var context = new MainContext();
            return context.Cars.Include(a => a.FuelingHistory).First().FuelingHistory;
        }
    }
}
