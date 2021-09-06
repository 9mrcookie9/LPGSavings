using LPGSavings.ViewModels.General;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LPGSavings.Views.General
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstWelcomeView : ContentView
    {
        public FirstWelcomeView()
        {
            InitializeComponent();
            BindingContext = new FirstWelcomeViewModel();
        }
    }
}