using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPGSavings.Domain;
using LPGSavings.Domain.Contexts;
using LPGSavings.Models.Forms;
using Microsoft.EntityFrameworkCore;

namespace LPGSavings.Services
{
    public class FuelingService : IFuelingService
    {
        public async Task AddEntry(FuelingForm form)
        {
            using var context = new MainContext();
            var car = context.Cars.Include(a => a.FuelingHistory).First();
            car.AddFueling(form.LitersLPG, form.PriceLPG, form.LitersPB, form.PricePB, form.Odometer, form.DateOfOccure);
            await context.SaveChangesAsync();

        }

        public IReadOnlyList<FuelingEntry> GetAll()
        {
            using var context = new MainContext();
            return context.Cars.Include(a => a.FuelingHistory).First().FuelingHistory;
        }
    }
}
