using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text;

namespace LPGSavings.Utilities
{
    public static class LoggerHelper
    {
        private static readonly LoggerFactory Factory = new LoggerFactory();
        public static ILogger<T> PrepareLogger<T>() where T : class
        {
            return new Logger<T>(Factory);
        }
    }
}
