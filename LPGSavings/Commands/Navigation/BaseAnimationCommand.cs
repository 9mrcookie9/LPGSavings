using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.Views.Base;
using LPGSavings.Views.IntroForms;

using Xamarin.Forms;

namespace LPGSavings.Commands.Intro
{
    public abstract class BaseAnimationCommand : BaseAsyncCommand
    {
        protected const uint FadeDuration = 1500;

        protected async Task AnimateTransition(ContentView secondView, Grid pageHolder)
        {
            var fadeTasks = new List<Task>();
            foreach (var children in pageHolder.Children)
            {
                fadeTasks.Add(children.FadeTo(0, FadeDuration));
                var hideOldViewAnimation = new Animation(v => children.TranslationX = v, 0, -children.Width, easing: Easing.CubicInOut);
                hideOldViewAnimation.Commit(children, nameof(hideOldViewAnimation), length: FadeDuration);
            }
            secondView.Opacity = 1;
            secondView.TranslationX = -secondView.Width;
            pageHolder.Children.Insert(0, secondView);
            fadeTasks.Add(secondView.FadeTo(1, FadeDuration));
            var displayNewViewAnimation = new Animation(v => secondView.TranslationX = v, secondView.Width, 0, easing: Easing.CubicInOut);
            displayNewViewAnimation.Commit(secondView, nameof(displayNewViewAnimation), length: FadeDuration);
            await Task.WhenAll(fadeTasks);
            while (pageHolder.Children.Count > 1)
            {
                pageHolder.Children.RemoveAt(pageHolder.Children.Count - 1);
                await Task.Delay(5);
            }
            if(secondView is IAnimationCompleted completed)
            {
                await completed.AnimationCompleted();
            }
        }
    }
}
