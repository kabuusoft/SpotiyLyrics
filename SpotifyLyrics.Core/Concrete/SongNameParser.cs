using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using SpotifyLyrics.Core.Abstract;

namespace SpotifyLyrics.Core.Concrete
{
    public class SongNameParser: BaseLog<SongNameParser>, ISongNameParser
    {
        public SongNameParser(ILogger<SongNameParser> logger) : base(logger)
        {
        }

        public (string artist, string songName) GetSongNameAndArtistFromWindowTitle(string windowTitle)
        {
            try
            {
                int index = windowTitle.IndexOf("-", StringComparison.Ordinal);
                if (index > -1)
                {
                    string artist = windowTitle.Substring(0, index);
                    string song = windowTitle.Substring(index + 1);

                    return (artist, song);
                }
                else
                {
                    return (string.Empty, string.Empty);
                }
            }
            catch (Exception e)
            {
                LogFatal("GetSongNameAndArtistFromWindowTitle", e);
                return (string.Empty, string.Empty);
            }
        }

        public string GenerateLyricFileName(string windowTitle)
        {
            try
            {
                return DoMakeValidFileName(windowTitle.Replace(" ", "_"));
            }
            catch (Exception e)
            {
                LogFatal("GenerateLyricFileName", e);
                return string.Empty;
            }
        }

        private  string DoMakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}
