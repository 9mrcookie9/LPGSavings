using System;
using System.Threading.Tasks;
using LPGSavings.Models.Forms;
using LPGSavings.Services;
using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;
using LPGSavings.ViewModels.Insert;

namespace LPGSavings.Commands.Insert
{
    public sealed class CreateFuelingCommand : BaseAsyncCommand
    {
        private readonly IBaseViewModel _baseViewModel;
        private readonly IFuelingService _fuelingService;
        public CreateFuelingCommand(IBaseViewModel insertFuelingViewModel, IFuelingService fuelingService)
        {
            _baseViewModel = insertFuelingViewModel;
            _fuelingService = fuelingService;
        }

        public sealed override async Task ExecuteAsync(object parameter = null)
        {
            if (!_baseViewModel.IsBusy && parameter is FuelingForm form)
            {
                _baseViewModel.IsBusy = true;
                try
                {
                    await _fuelingService.AddEntry(form);
                }
                catch (Exception ex)
                {
                    this._logger.LogException(ex);
                }
                finally
                {
                    _baseViewModel.IsBusy = false;
                }
            }
        }
    }
}
