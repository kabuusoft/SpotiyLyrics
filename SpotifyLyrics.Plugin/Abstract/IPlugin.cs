using System.Threading.Tasks;

namespace SpotifyLyrics.Plugin.Abstract
{
    public interface IPlugin
    {
        Task<string> DownloadLyric(string artist, string title);
        string GetTitle();
        string GetVersion();
        string GetAuthor();
        string GetWebSite();
        bool IsActive();
    }
}