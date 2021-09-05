using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Common;
using SpotifyLyrics.Data.Model;
using SpotifyLyrics.Data.Services.Abstract;

namespace SpotifyLyrics.Data.Services.Concrete
{
    public class LyricService : BaseLog<LyricService>, ILyricService
    {
        private readonly LyricContext _lyricContext;

        public LyricService(ILogger<LyricService> logger, LyricContext lyricContext) : base(logger)
        {
            _lyricContext = lyricContext;
        }

        public async Task<string> GetLyric(string windowTitle)
        {
            try
            {
                var model = await _lyricContext.Lyrics.FirstOrDefaultAsync(q => q.IsActive && q.WindowTitle == windowTitle);

                return model?.Content ?? string.Empty;
            }
            catch (Exception e)
            {
                LogFatal("GetLyric", e);
                return string.Empty;
            }
        }

        public async Task<string> AddLyric(string windowTitle, string lyric)
        {
            try
            {
                await _lyricContext.Lyrics.AddAsync(new Lyric()
                {
                    AddDateTime = DateTime.Now,
                    Content = lyric,
                    IsActive = true,
                    WindowTitle = windowTitle
                });

                var count = await _lyricContext.SaveChangesAsync();

                return count > 0 ? string.Empty : "SaveError";
            }
            catch (Exception e)
            {
                LogFatal("AddLyric", e);
                return e.Message;
            }
        }
    }
}