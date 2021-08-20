
using System;
using System.Threading.Tasks;
using LPGSavings.Utilities;
using Microsoft.Extensions.Logging;

namespace LPGSavings.Commands
{
    public abstract class BaseAsyncCommand : IBaseAsyncCommand
    {
        protected ILogger<IBaseAsyncCommand> _logger = LoggerHelper.PrepareLogger<IBaseAsyncCommand>();
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
