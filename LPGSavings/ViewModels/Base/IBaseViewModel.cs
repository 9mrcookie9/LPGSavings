using System.ComponentModel;

namespace LPGSavings.ViewModels.Base
{
    public interface IBaseViewModel
    {
        bool IsBusy { get; set; }
        bool IsNotBusy { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
