using System;
using System.Collections.Generic;
using LPGSavings.ViewModels.General;
using Xamarin.Forms;

namespace LPGSavings.Views.General
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
