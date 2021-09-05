namespace SpotifyLyrics.Core.Abstract
{
    public interface ISongNameParser
    {
        (string artist, string songName) GetSongNameAndArtistFromWindowTitle(string windowTitle);
        string GenerateLyricFileName(string windowTitle);
    }
}