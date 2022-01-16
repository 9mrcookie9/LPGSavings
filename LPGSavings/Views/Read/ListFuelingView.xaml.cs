using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPGSavings.ViewModels.Read;
using LPGSavings.Views.Base;
using Xamarin.Forms;

namespace LPGSavings.Views.Read
{
    public partial class ListFuelingView : ContentView, IAnimationCompleted
    {
        private readonly ListFuelingViewModel _vm;
        public ListFuelingView()
        {
            InitializeComponent();
            BindingContext = _vm = new ListFuelingViewModel();
        }

        Task IAnimationCompleted.AnimationCompleted()
        {
            return _vm.Init();
        }
    }
}
