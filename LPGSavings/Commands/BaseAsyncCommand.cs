
using System;
using System.Threading.Tasks;

namespace LPGSavings.Commands
{
    public abstract class BaseAsyncCommand : IBaseAsyncCommand
    {
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged(EventArgs parameter = null)
        {
            CanExecuteChanged?.Invoke(this, parameter);
        }
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        public abstract Task ExecuteAsync(object parameter = null);
    }
}
