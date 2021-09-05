using System.Threading.Tasks;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Plugin.Concrete
{
    public class DummyPlugin : IPlugin
    {
        public async Task<string> DownloadLyric(string artist, string title)
        {
            return string.Empty;
        }

        public string GetTitle()
        {
            return "Dummy Plugin";
        }

        public string GetVersion()
        {
            return "1";
        }

        public string GetAuthor()
        {
            return "Okan Özcan";
        }

        public string GetWebSite()
        {
            return "https://kabuusoft.com";
        }
    }
}