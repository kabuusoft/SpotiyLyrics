using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpotifyLyrics.Core.Abstract;
using SpotifyLyrics.Core.Concrete;
using SpotifyLyrics.Data.Model;
using SpotifyLyrics.Data.Services.Abstract;
using SpotifyLyrics.Data.Services.Concrete;

namespace SpotifyLyrics
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainForm>()
                .AddLogging()
                .AddDbContext<LyricContext>(OptionsAction)
                .AddSingleton<ISpotifyManager, SpotifyManager>()
                .AddSingleton<IPluginManager, PluginManager>()
                .AddSingleton<IDownloadManager, DownloadManager>()
                .AddSingleton<ISongNameParser, SongNameParser>()
                .AddSingleton<ILyricService, LyricService>();
        }

        private static void OptionsAction(DbContextOptionsBuilder obj)
        {
            const string dbFileName = "data.db";
            string dbFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SpotiyLyrics");
            if (!Directory.Exists(dbFolderPath))
            {
                Directory.CreateDirectory(dbFolderPath);
            }

            var dbFilePath = Path.Combine(dbFolderPath, dbFileName);

            obj.UseSqlite($"Data Source={dbFilePath}");
        }
    }
}