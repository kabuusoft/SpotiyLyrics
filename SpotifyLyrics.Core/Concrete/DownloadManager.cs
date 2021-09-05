using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Core.Abstract;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Core.Concrete
{
    public class DownloadManager : BaseLog<DownloadManager>, IDownloadManager
    {
        private readonly List<IPlugin> _plugins;

        public DownloadManager(ILogger<DownloadManager> logger, IPluginManager pluginManager) : base(logger)
        {
            _plugins = pluginManager.LoadPlugins();
        }

        public async Task<string> DownloadLyric(string artist, string songTitle, string lyricFilePath, bool forceRedownload = false)
        {
            try
            {
                if (File.Exists(lyricFilePath) && !forceRedownload)
                {
                    return await File.ReadAllTextAsync(lyricFilePath);
                }

                foreach (var plugin in _plugins)
                {
                    try
                    {
                        var lyricContent = await plugin.DownloadLyric(artist, songTitle);
                        if (!string.IsNullOrEmpty(lyricContent))
                        {
                            await File.WriteAllTextAsync(lyricFilePath, lyricContent);

                            return lyricContent;
                        }
                    }
                    catch (Exception e)
                    {
                        LogError($"DownloadLyric for loop plugin {plugin.GetTitle()} {plugin.GetVersion()}", e);
                    }
                }

                return string.Empty;
            }
            catch (Exception e)
            {
                LogFatal("DownloadLyric", e);
                return string.Empty;
            }
        }
    }
}