using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.Data.Model
{
    public class Lyric: BaseModel
    {
        public string WindowTitle { get; set; }
        public string Content { get; set; }
    }
}
