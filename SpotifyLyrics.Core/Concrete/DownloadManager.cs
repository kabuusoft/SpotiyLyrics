using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Common;
using SpotifyLyrics.Core.Abstract;
using SpotifyLyrics.Data.Services.Abstract;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Core.Concrete
{
    public class DownloadManager : BaseLog<DownloadManager>, IDownloadManager
    {
        private readonly ILyricService _lyricService;
        private readonly List<IPlugin> _plugins;

        public DownloadManager(ILogger<DownloadManager> logger, IPluginManager pluginManager, ILyricService lyricService) : base(logger)
        {
            _lyricService = lyricService;
            _plugins = pluginManager.LoadPlugins();
        }

        public async Task<(string lyric, string source)> DownloadLyric(string artist, string songTitle, string windowTitle, bool forceRedownload = false)
        {
            try
            {
                if (!forceRedownload)
                {
                    var lyric = await _lyricService.GetLyric(windowTitle);
                    if (!string.IsNullOrEmpty(lyric))
                    {
                        return (lyric, "Cache");
                    }
                }

                foreach (var plugin in _plugins)
                    try
                    {
                        var lyricContent = await plugin.DownloadLyric(artist, songTitle);
                        if (!string.IsNullOrEmpty(lyricContent))
                        {
                            var saveResult = await _lyricService.AddLyric(windowTitle, lyricContent);
                            if (!string.IsNullOrEmpty(saveResult)) LogError($"DownloadLyric save error {saveResult}.");

                            return (lyricContent, plugin.GetTitle());
                        }
                    }
                    catch (Exception e)
                    {
                        LogError($"DownloadLyric for loop plugin {plugin.GetTitle()} {plugin.GetVersion()}", e);
                    }

                return (string.Empty, string.Empty);
            }
            catch (Exception e)
            {
                LogFatal("DownloadLyric", e);
                return (string.Empty, string.Empty);
            }
        }
    }
}