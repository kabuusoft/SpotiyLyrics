using System.Threading.Tasks;

namespace SpotifyLyrics.Core.Abstract
{
    public interface IDownloadManager
    {
        Task<string> DownloadLyric(string artist, string songTitle, string lyricFilePath, bool forceRedownload = false);
    }
}