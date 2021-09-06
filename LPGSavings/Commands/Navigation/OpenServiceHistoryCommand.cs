using System;
using System.Threading.Tasks;
using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;
using LPGSavings.Views.Read;

namespace LPGSavings.Commands.Intro
{
    public sealed class OpenServiceHistoryCommand : BaseAnimationCommand
    {
        private readonly IBaseViewModel _baseViewModel;

        public OpenServiceHistoryCommand(IBaseViewModel baseViewModel)
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
                var secondView = new ListServiceView();
                var pageHolder = App.Current.CurrentPage.MainHolder;
                await AnimateTransition(secondView, pageHolder);
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
