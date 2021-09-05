using System.Threading.Tasks;

namespace SpotifyLyrics.Core.Abstract
{
    public interface IDownloadManager
    {
        Task<(string lyric, string source)> DownloadLyric(string artist, string songTitle, string windowTitle, bool forceRedownload = false);
    }
}