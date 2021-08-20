using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Domain;

namespace LPGSavings.Services
{
    public interface IFuelingService
    {
        Task AddEntry(float litersLPG, decimal priceLPG, float litersPB, decimal pricePB, uint odometer, DateTime dateTime);
        IReadOnlyList<FuelingEntry> GetAll();
    }
}
