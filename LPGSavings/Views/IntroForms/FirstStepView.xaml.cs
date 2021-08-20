using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPGSavings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LPGSavings.Views.IntroForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstStepView : ContentView
    {
        public FirstStepView()
        {
            InitializeComponent();
            BindingContext = new IntroViewModel();
        }
    }
}