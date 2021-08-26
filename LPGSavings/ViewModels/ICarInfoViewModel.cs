using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public interface ICarInfoViewModel : IBaseViewModel
    {
        CarInfoViewModel Car { get; }
    }
}
