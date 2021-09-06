using System;
using System.Collections.Generic;
using LPGSavings.ViewModels;
using Xamarin.Forms;

namespace LPGSavings.Views
{
    public partial class DashboardView : ContentView
    {
        public DashboardView()
        {
            InitializeComponent();
            BindingContext = new DashboardViewModel();
        }
    }
}
