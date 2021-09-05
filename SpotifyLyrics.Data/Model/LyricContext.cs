using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SpotifyLyrics.Data.Model
{
    public class LyricContext : DbContext
    {
        public LyricContext(DbContextOptions<LyricContext> options) : base(options)
        {
            
        }
        
        public DbSet<Lyric> Lyrics { get; set; }
    }
}
