using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LPGSavings.Commands;
using LPGSavings.Commands.Intro;
using LPGSavings.Commands.Read;
using LPGSavings.Domain;
using LPGSavings.Services;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels.Read
{
    public class ListFuelingViewModel : BaseViewModel,IBackButtonViewModel
    {
        public ObservableCollection<FuelingEntry> Entries { get; } = new ObservableCollection<FuelingEntry>();

        public int Limit { get; private set; } = -1;

        public IBaseAsyncCommand LoadMoreFuelingCommand { get; }

        public ICommand OpenDashboardCommand { get; }
        public ListFuelingViewModel()
        {
            LoadMoreFuelingCommand = new LoadMoreFuelingCommand(this,Entries,new FuelingService());
            OpenDashboardCommand = new OpenDashboardCommand(this);
        }

        public async Task Init()
        {
            await LoadMoreFuelingCommand.ExecuteAsync();
            Limit = 5;
            OnPropertyChanged(nameof(Limit));
        }

        public bool OnBackButtonPressed()
        {
            OpenDashboardCommand.Execute(null);
            return true;
        }
    }
}
