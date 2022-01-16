using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using LPGSavings.Domain;
using LPGSavings.Services;
using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.Commands.Read
{
    public sealed class LoadMoreFuelingCommand : BaseAsyncCommand
    {
        private const int PageSize = 10;
        private int _page = 1;
        private readonly IBaseViewModel _baseViewModel;
        private readonly ObservableCollection<FuelingEntry> _entries;
        private readonly IFuelingService _fuelingService;

        public LoadMoreFuelingCommand(IBaseViewModel baseViewModel, ObservableCollection<FuelingEntry> entries, IFuelingService fuelingService)
        {
            _baseViewModel = baseViewModel;
            _entries = entries;
            _fuelingService = fuelingService;
        }

        public sealed override async Task ExecuteAsync(object parameter = null)
        {
            if (_baseViewModel.IsBusy)
            {
                return;
            }
            _baseViewModel.IsBusy = true;
            try
            {
                await Task.Delay(100);
                var laodedEntries = await _fuelingService.GetPaged(_page, PageSize).ConfigureAwait(false);
                foreach (var entry in laodedEntries)
                {
                    _entries.Add(entry);
                }
                ++_page;
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            finally
            {
                _baseViewModel.IsBusy = false;
            }
        }
    }
}
