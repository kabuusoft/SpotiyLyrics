using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpotifyLyrics.Core.Abstract;
using SpotifyLyrics.Core.Concrete;

namespace SpotifyLyrics
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainForm>()
                .AddLogging()
                .AddSingleton<ISpotifyManager, SpotifyManager>()
                .AddSingleton<IPluginManager, PluginManager>()
                .AddSingleton<IDownloadManager, DownloadManager>()
                .AddSingleton<ISongNameParser, SongNameParser>();
        }
    }
}
