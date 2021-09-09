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
        private readonly FuelingForm _fuelingForm;
        private readonly Action _saved;
        public CreateFuelingCommand(IBaseViewModel insertFuelingViewModel, IFuelingService fuelingService, FuelingForm fuelingForm, Action saved)
        {
            _baseViewModel = insertFuelingViewModel;
            _fuelingService = fuelingService;
            _fuelingForm = fuelingForm;
            _fuelingForm.PropertyChanged += RaiseSelfCanExecuteChanged;
            _saved = saved;
        }

        private void RaiseSelfCanExecuteChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) => RaiseCanExecuteChanged();

        public sealed override bool CanExecute(object parameter) => _fuelingForm.IsValid;

        public sealed override async Task ExecuteAsync(object parameter = null)
        {
            if (!_baseViewModel.IsBusy )
            {
                _baseViewModel.IsBusy = true;
                await Task.Delay(100); //Give animation time to start.
                try
                {
                    await _fuelingService.AddEntry(_fuelingForm);
                    _baseViewModel.IsBusy = false;
                    _saved?.Invoke();
                }
                catch (Exception ex)
                {
                    _baseViewModel.IsBusy = false;
                    this._logger.LogException(ex);
                }
            }
        }
    }
}
