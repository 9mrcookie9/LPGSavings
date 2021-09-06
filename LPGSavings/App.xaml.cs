using System;
using LPGSavings.Views.General;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LPGSavings
{
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;
        public MainPage CurrentPage { get; private set; }
        public App()
        {
            InitializeComponent();

            MainPage = CurrentPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}
