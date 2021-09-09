using System;
using System.Windows.Input;
using LPGSavings.Commands.Insert;
using LPGSavings.Commands.Intro;
using LPGSavings.Models.Forms;
using LPGSavings.Services;
using LPGSavings.ViewModels.Base;

namespace LPGSavings.ViewModels.Insert
{
    public class InsertFuelingViewModel : BaseViewModel
    {
        public FuelingForm Form { get; } = new FuelingForm();

        public ICommand CloseModalCommand { get; }
        public ICommand AddFuelingCommand { get; }

        public InsertFuelingViewModel()
        {
            CloseModalCommand = new CloseModalCommand(this);
            AddFuelingCommand = new CreateFuelingCommand(this,new FuelingService()); //TODO: Change me
        }
    }
}
