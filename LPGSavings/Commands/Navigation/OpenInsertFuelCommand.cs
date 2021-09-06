using System;
using System.Threading.Tasks;

using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;
using LPGSavings.Views.Insert;

namespace LPGSavings.Commands.Intro
{
    public sealed class OpenInsertFuelCommand : BaseAsyncCommand
    {
        private readonly IBaseViewModel _baseViewModel;

        public OpenInsertFuelCommand(IBaseViewModel baseViewModel)
        {
            _baseViewModel = baseViewModel;
        }

        public override async Task ExecuteAsync(object parameter = null)
        {
            if (_baseViewModel.IsBusy)
            {
                return;
            }
            _baseViewModel.IsBusy = true;
            try
            {
                var page = new InsertFuelingPage();
                await App.Current.CurrentPage.Navigation.PushModalAsync(page);
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
