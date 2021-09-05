using System;
using Microsoft.Extensions.Logging;

namespace SpotifyLyrics.Common
{
    public abstract class BaseLog<T> where T: class
    {
        private readonly ILogger<T> _logger;

        protected BaseLog(ILogger<T> logger)
        {
            this._logger = logger;
        }

        protected void LogInfo(string msg, string transId = "")
        {
            try
            {
                _logger.LogInformation($"{transId} {msg}");
            }
            catch
            {
                // ignored
            }
        }

        protected void LogError(string msg, string transId = "")
        {
            try
            {
                _logger.LogError($"{transId} {msg}");
            }
            catch
            {
                // ignored
            }
        }

        protected void LogError(string msg, Exception exception, string transId = "")
        {
            try
            {
                _logger.LogError($"{transId} {msg}", exception);
            }
            catch
            {
                // ignored
            }
        }

        protected void LogFatal(string msg, string transId = "")
        {
            try
            {
                _logger.LogCritical($"{transId} {msg}");
            }
            catch
            {
                // ignored
            }
        }

        protected void LogFatal(string msg, Exception exception, string transId = "")
        {
            try
            {
                _logger.LogCritical($"{transId} {msg}", exception);
            }
            catch
            {
                // ignored
            }
        }
    }
}
