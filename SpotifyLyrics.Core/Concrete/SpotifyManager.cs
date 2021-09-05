using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Common;
using SpotifyLyrics.Core.Abstract;

namespace SpotifyLyrics.Core.Concrete
{
    public class SpotifyManager : BaseLog<SpotifyManager>, ISpotifyManager
    {
        private Process DoGetSpotifProcess()
        {
            return Process.GetProcesses().FirstOrDefault(q => q.ProcessName == "Spotify" && !string.IsNullOrEmpty(q.MainWindowTitle));
        }

        public bool IsSpotifyWorking(string transId = "")
        {
            try
            {
                return DoGetSpotifProcess() != null;
            }
            catch (Exception e)
            {
                LogFatal("IsSpotifyWorking", e, transId);
                return false;
            }
        }

        public string GetSpotifyWindowTitle(string transId = "")
        {
            try
            {
                var spotifyProcess = DoGetSpotifProcess();
                if (spotifyProcess == null)
                {
                    return string.Empty;
                }

                return spotifyProcess.MainWindowTitle;
            }
            catch (Exception e)
            {
                LogFatal("GetSpotifyWindowTitle", e, transId);
                return string.Empty;
            }
        }

        public SpotifyManager(ILogger<SpotifyManager> logger) : base(logger)
        {
        }
    }
}
