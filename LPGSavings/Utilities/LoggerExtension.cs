using Microsoft.Extensions.Logging;

using System;

namespace LPGSavings.Utilities
{
    public static class LoggerExtension
    {
        public static void LogException<T>(this ILogger<T> logger, Exception ex)
        {
            logger.LogError(new EventId(0), ex, ex.Message);
        }
    }
}
