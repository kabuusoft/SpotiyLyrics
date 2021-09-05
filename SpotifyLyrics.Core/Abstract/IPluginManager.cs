using System.Collections.Generic;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Core.Abstract
{
    public interface IPluginManager
    {
        List<IPlugin> LoadPlugins();
    }
}