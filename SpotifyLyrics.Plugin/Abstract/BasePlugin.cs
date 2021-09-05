using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLyrics.Plugin.Abstract
{
    public class BasePlugin
    {
        public virtual async Task<string> DownloadLyric(string artist, string title)
        {
            return string.Empty;
        }

        public virtual string GetTitle()
        {
            return string.Empty;
        }
        public virtual string GetVersion()
        {
            return string.Empty;
        }
        public virtual string GetAuthor()
        {
            return string.Empty;
        }
    }
}
