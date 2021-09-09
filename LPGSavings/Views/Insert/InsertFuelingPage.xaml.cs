using System;
using System.Collections.Generic;
using LPGSavings.ViewModels.Insert;
using Xamarin.Forms;

namespace LPGSavings.Views.Insert
{
    public partial class InsertFuelingPage : ContentPage
    {
        public InsertFuelingPage()
        {
            InitializeComponent();
            BindingContext = new InsertFuelingViewModel();
        }
    }
}
