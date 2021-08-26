using LPGSavings.Utilities;

using Microsoft.Extensions.Logging;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LPGSavings.Commands
{
    public class ExecuteMultipleCommandsAtOnceCommand : BaseAsyncCommand
    {
        private readonly ICommand[] _baseAsyncCommands;
        public ExecuteMultipleCommandsAtOnceCommand(params ICommand[] baseAsyncCommands)
        {
            _baseAsyncCommands = baseAsyncCommands;
            foreach (var command in baseAsyncCommands)
            {
                command.CanExecuteChanged += ChainCanExecuteChanged;
            }
        }

        private void ChainCanExecuteChanged(object sender, EventArgs e)
        {
            this.RaiseCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _baseAsyncCommands.All(a => a.CanExecute(parameter));
        }

        public override async Task ExecuteAsync(object parameter = null)
        {
            try
            {
                foreach (ICommand command in _baseAsyncCommands)
                {
                    if (command is IBaseAsyncCommand asyncCommand)
                    {
                        await asyncCommand.ExecuteAsync(parameter);
                    }
                    else
                    {
                        command.Execute(parameter);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
            }
        }
    }
}
