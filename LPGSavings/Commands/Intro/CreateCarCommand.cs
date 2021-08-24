using LPGSavings.Services;
using LPGSavings.Utilities;
using LPGSavings.ViewModels;

using System;
using System.Threading.Tasks;

namespace LPGSavings.Commands.Intro
{
    public sealed class CreateCarCommand : BaseAsyncCommand
    {
        private readonly IntroViewModel _viewModel;
        private readonly ICarService _carService;
        private readonly IFuelingService _fuelingService;
        private readonly Action _completed;
        public CreateCarCommand(IntroViewModel viewModel, ICarService carService, IFuelingService fuelingService, Action completed)
        {
            _viewModel = viewModel;
            _carService = carService;
            _fuelingService = fuelingService;
            _completed = completed;
        }

        public override async Task ExecuteAsync(object parameter = null)
        {
            if (_viewModel.IsBusy)
            {
                return;
            }
            _viewModel.IsBusy = true;
            try
            {
                await _carService.InitializeCar(
                    _viewModel.Odometer,
                    _viewModel.OdometerLPG,
                    _viewModel.InstallationCost,
                    _viewModel.SystemCapacity,
                    _viewModel.DateOfInstallation);
                if (_viewModel.OdometerLPG > 0)
                {
                    await _fuelingService.AddEntry(_viewModel.OdometerLPG, _viewModel.AveragePriceLPG, 0, 0, _viewModel.Odometer, DateTime.Now);
                }
                _viewModel.IsBusy = false;
                _completed?.Invoke();
            }
            catch (Exception ex)
            {
                _viewModel.IsBusy = false;
                _logger.LogException(ex);
            }
        }
    }
}
