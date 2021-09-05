using System.Threading.Tasks;

namespace SpotifyLyrics.Data.Services.Abstract
{
    public interface ILyricService
    {
        Task<string> GetLyric(string windowTitle);
        Task<string> AddLyric(string windowTitle, string lyric);
    }
}