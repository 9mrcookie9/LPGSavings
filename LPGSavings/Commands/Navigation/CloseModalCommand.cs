using System;
using System.Threading.Tasks;

using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.Commands.Intro
{
    public sealed class CloseModalCommand : BaseAsyncCommand
    {
        private readonly IBaseViewModel _baseViewModel;

        public CloseModalCommand(IBaseViewModel baseViewModel)
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
                await App.Current.CurrentPage.Navigation.PopModalAsync();
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
