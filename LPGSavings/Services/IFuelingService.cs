using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Domain;

namespace LPGSavings.Services
{
    public interface IFuelingService
    {
        Task AddEntry(decimal litersLPG, decimal priceLPG, decimal litersPB, decimal pricePB, uint odometer, DateTime dateTime);
        IReadOnlyList<FuelingEntry> GetAll();
    }
}
