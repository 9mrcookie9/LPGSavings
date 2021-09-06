using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPGSavings.Services;
using LPGSavings.Views;
using Xamarin.Forms;

namespace LPGSavings
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

        public Grid MainHolder => mainGridHolder;
    }
}
