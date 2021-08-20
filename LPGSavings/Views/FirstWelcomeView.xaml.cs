using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPGSavings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LPGSavings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstWelcomeView : ContentView
    {
        public FirstWelcomeView()
        {
            InitializeComponent();
            this.BindingContext = new FirstWelcomeViewModel();
        }
    }
}