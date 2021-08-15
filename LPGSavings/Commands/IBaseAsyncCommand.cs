
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LPGSavings.Commands
{
    public interface IBaseAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter = null);
        void RaiseCanExecuteChanged(EventArgs parameter = null);
    }
}
