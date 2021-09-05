using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Plugin.Concrete
{
    public class SongLyricsPlugin : BasePlugin, IPlugin
    {
        public async Task<string> DownloadLyric(string artist, string title)
        {
            var fixedArtistName = DoFixParameters(artist);
            var fixedTitle = DoFixParameters(DoRemoveRemastered(DoRemoveMtvUnplugged(title)));

            var downloadUrl = $"https://www.songlyrics.com/{fixedArtistName}/{fixedTitle}-lyrics/";

            using (var webClient = new WebClient())
            {
                var htmlData = await webClient.DownloadStringTaskAsync(downloadUrl);

                var doc = new HtmlDocument();
                doc.LoadHtml(htmlData);

                doc.DocumentNode.Descendants()
                    .Where(n => n.NodeType == HtmlNodeType.Comment)
                    .ToList()
                    .ForEach(n => n.Remove());

                const string xPath = "//*[@id=\"songLyricsDiv\"]";

                var div = doc.DocumentNode.SelectNodes(xPath).FirstOrDefault();
                if (div == null) return string.Empty;

                var lyricContent = div.InnerHtml;
                lyricContent = lyricContent.Replace("<br>", Environment.NewLine);

                var lines = lyricContent.Split(Environment.NewLine).ToList();

                return string.Join(Environment.NewLine, lines);
            }
        }

        private object DoFixParameters(string str)
        {
            var tmp = str.ToLowerInvariant()
                .Replace(" ", "-")
                .Replace("&", "")
                .Replace("Ö", "ö")
                .Replace(",", "")
                .Replace("!", "")
                .Replace("?", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("[", "")
                .Replace("!", "")
                .Replace("]", "")
                .Replace(".", "")
                .Replace("*", "")
                .Replace("'", "")
                .Replace("ö", "o")
                .Replace("- remastered", "");

            return TurkishCharacterToEnglish(tmp);
        }

        public string GetTitle()
        {
            return "https://www.songlyrics.com downloader";
        }

        public string GetVersion()
        {
            return "1";
        }

        public string GetAuthor()
        {
            return "Okan Özcan";
        }

        public string GetWebSite()
        {
            return "https://www.songlyrics.com";
        }

        public bool IsActive()
        {
            return true;
        }
    }
}
