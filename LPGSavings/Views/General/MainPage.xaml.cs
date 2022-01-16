using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPGSavings.Services;
using LPGSavings.ViewModels.Base;
using LPGSavings.Views;
using Xamarin.Forms;

namespace LPGSavings.Views.General
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (ConfigurationHelper.CreateInstance().IsCarCreated())
            {
                mainGridHolder.Children.Add(new DashboardView());
            }
            else
            {
                mainGridHolder.Children.Add(new FirstWelcomeView());
            }
        }
        protected override bool OnBackButtonPressed()
        {
            if(mainGridHolder.Children.LastOrDefault()?.BindingContext is IBackButtonViewModel backButton)
            {
                return backButton.OnBackButtonPressed();
            }
            return base.OnBackButtonPressed();
        }
        public Grid MainHolder => mainGridHolder;
    }
}
