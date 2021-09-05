    using System;
using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using SpotifyLyrics.Data.Model;

    namespace SpotifyLyrics.Data
{
    class LyricContextFactory : IDesignTimeDbContextFactory<LyricContext>
    {
        public LyricContext CreateDbContext(string[] args)
        {
            const string dbFileName = "data.db";
            string dbFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SpotiyLyrics");
            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }

            var dbFilePath = Path.Combine(dbFolderPath, dbFileName);

            var optionsBuilder = new DbContextOptionsBuilder<LyricContext>();
            optionsBuilder.UseSqlite($"Data Source={dbFilePath}");

            return new LyricContext(optionsBuilder.Options);
        }
    }
}
