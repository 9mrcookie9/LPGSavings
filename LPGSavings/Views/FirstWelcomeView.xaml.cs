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
            BindingContext = new FirstWelcomeViewModel();
        }
    }
}