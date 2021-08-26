using System;
using System.Collections.Generic;
using LPGSavings.ViewModels;
using Xamarin.Forms;

namespace LPGSavings.Views.IntroForms
{
    public partial class SecondStepView : ContentView
    {
        public SecondStepView(SecondStepViewModel vm)
        {
            InitializeComponent();
            this.BindingContext = vm;
        }
    }
}
