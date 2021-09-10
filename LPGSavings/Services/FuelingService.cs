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
            car.AddFueling(form.LitersLPG.Value, form.PriceLPG.Value, form.LitersPB.Value, form.PricePB.Value, form.Odometer.Value, form.DateOfOccure);
            await context.SaveChangesAsync().ConfigureAwait(false);

        }

        public async Task<IReadOnlyList<FuelingEntry>> GetAll()
        {
            using var context = new MainContext();
            return await context.Cars.Include(a => a.FuelingHistory).AsNoTracking().SelectMany(a => a.FuelingHistory).ToListAsync().ConfigureAwait(false);
        }
    }
}
