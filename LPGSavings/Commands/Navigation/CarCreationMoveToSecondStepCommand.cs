﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Utilities;
using LPGSavings.ViewModels;
using LPGSavings.Views.IntroForms;
using Xamarin.Forms;

namespace LPGSavings.Commands.Intro
{
    public sealed class CarCreationMoveToSecondStepCommand : BaseAnimationCommand
    {
        private readonly ICarInfoViewModel _baseViewModel;

        public CarCreationMoveToSecondStepCommand(ICarInfoViewModel baseViewModel)
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
                var secondView = new SecondStepView(new SecondStepViewModel(_baseViewModel.Car));
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
