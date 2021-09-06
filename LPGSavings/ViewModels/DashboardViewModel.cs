using System.Windows.Input;
using LPGSavings.Commands.Intro;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels
{
    public sealed class DashboardViewModel : BaseViewModel
    {
        public ICommand OpenInsertFuelCommand { get; }
        public ICommand OpenInsertServiceCommand { get; }
        public ICommand OpenFuelingHistoryCommand { get; }
        public ICommand OpenServiceHistoryCommand { get; }
        public DashboardViewModel()
        {
            OpenInsertFuelCommand = new OpenInsertFuelCommand(this);
            OpenInsertServiceCommand = new OpenInsertServiceCommand(this);
            OpenFuelingHistoryCommand = new OpenFuelingHistoryCommand(this);
            OpenServiceHistoryCommand = new OpenServiceHistoryCommand(this);
        }
    }
}
