using LPGSavings.Services;
using LPGSavings.Utilities;
using LPGSavings.ViewModels;

using System;
using System.Threading.Tasks;

namespace LPGSavings.Commands.Intro
{
    public sealed class CreateCarCommand : BaseAsyncCommand
    {
        private readonly ICarInfoViewModel _viewModel;
        private readonly ICarService _carService;
        private readonly IFuelingService _fuelingService;
        private readonly Action _completed;
        public CreateCarCommand(ICarInfoViewModel viewModel, ICarService carService, IFuelingService fuelingService, Action completed)
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
                await Task.Delay(50);
                await _carService.InitializeCar(
                    _viewModel.Car.Odometer,
                    _viewModel.Car.OdometerLPG,
                    _viewModel.Car.InstallationCost,
                    _viewModel.Car.SystemCapacity,
                    _viewModel.Car.DateOfInstallation);
                if (_viewModel.Car.OdometerLPG > 0)
                {
                    //TODO: Required information about average consumption
                    //await _fuelingService.AddEntry(new Models.Forms.FuelingForm {
                    //    Odometer = _viewModel.Car.OdometerLPG,
                    //    PriceLPG = _viewModel.Car.AveragePriceLPG,
                    //     _viewModel.Car.Odometer, DateTime.Now
                    //});
                }
                ConfigurationHelper.CreateInstance().SetCarCreated(true);
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
