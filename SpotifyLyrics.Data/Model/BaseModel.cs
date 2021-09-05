using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.Data.Model
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime AddDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
