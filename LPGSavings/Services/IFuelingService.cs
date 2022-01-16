using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Domain;
using LPGSavings.Models.Forms;

namespace LPGSavings.Services
{
    public interface IFuelingService
    {
        Task AddEntry(FuelingForm form);
        Task<IReadOnlyList<FuelingEntry>> GetAll();
        Task<IReadOnlyList<FuelingEntry>> GetPaged(int page, int pageSize);
    }
}
