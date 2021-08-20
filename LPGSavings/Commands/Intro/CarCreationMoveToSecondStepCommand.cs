﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Utilities;
using LPGSavings.ViewModels.Base;
using LPGSavings.Views.IntroForms;
using Xamarin.Forms;

namespace LPGSavings.Commands.Intro
{
    public sealed class CarCreationMoveToSecondStepCommand : BaseAsyncCommand
    {
        private const uint FadeDuration = 500;
        private readonly IBaseViewModel _baseViewModel;

        public CarCreationMoveToSecondStepCommand(IBaseViewModel baseViewModel)
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
                var secondView = new SecondStepView() { BindingContext = _baseViewModel };
                var pageHolder = App.Current.CurrentPage.MainHolder;
                var fadeTasks = new List<Task>();
                foreach (var children in pageHolder.Children)
                {
                    fadeTasks.Add(children.FadeTo(0, FadeDuration));
                    var hideOldViewAnimation = new Animation(v => children.TranslationX = v, 0, -children.Width, easing: Easing.CubicInOut);
                    hideOldViewAnimation.Commit(children, nameof(hideOldViewAnimation), length: FadeDuration);
                }
                pageHolder.Children.Add(secondView);
                secondView.Opacity = 1;
                var displayNewViewAnimation = new Animation(v => secondView.TranslationX = v, secondView.Width, 0, easing: Easing.CubicInOut);
                displayNewViewAnimation.Commit(secondView, nameof(displayNewViewAnimation),length: FadeDuration);
                await Task.WhenAll(fadeTasks);
                while(pageHolder.Children.Count > 1)
                {
                    pageHolder.Children.RemoveAt(0);
                    await Task.Delay(5);
                }
            }
            catch (Exception ex)
            {
                this._logger.LogException(ex);
            }
            finally
            {
                _baseViewModel.IsBusy = true;
            }
        }
    }
}
