namespace SpotifyLyrics.Core.Abstract
{
    public interface ISpotifyManager
    {
        bool IsSpotifyWorking(string transId = "");
        string GetSpotifyWindowTitle(string transId = "");
    }
}