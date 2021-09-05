using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SpotifyLyrics.Plugin.Abstract;

namespace SpotifyLyrics.Plugin.Concrete
{
    public class AzLyricsPlugin : IPlugin
    {
        public async Task<string> DownloadLyric(string artist, string title)
        {
            var fixedArtistName = artist.ToLowerInvariant().StartsWith("the") ? DoFixParameters(DoRemoveTheFromArtistName(artist)) : DoFixParameters(artist);
            var fixedTitle = DoFixParameters(DoRemoveRemastered(DoRemoveMtvUnplugged(title)));

            return await DoDownloadSongWithoutTheInName(fixedArtistName, fixedTitle);
        }

        public string GetTitle()
        {
            return "https://www.azlyrics.com downloader";
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
            return "https://www.azlyrics.com";
        }

        private string DoFixParameters(string str)
        {
            return str.ToLowerInvariant()
                .Replace(" ", "")
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
                .Replace("-", "")
                .Replace(".", "")
                .Replace("*", "")
                .Replace("'", "")
                .Replace("ö", "o")
                .Replace("- remastered", "");
        }

        private string DoRemoveTrailingDash(string str)
        {
            if (str.EndsWith("-")) return str.Substring(0, str.Length - 1);

            return str;
        }

        private string DoRemoveLast4CharsIfDigit(string str)
        {
            if (str.Length >= 4)
            {
                var tmpStr = str.Substring(str.Length - 4);
                if (int.TryParse(tmpStr, out var _))
                {
                    var tmpStr2 = str.Substring(0, str.Length - 4).Trim();

                    return DoRemoveTrailingDash(tmpStr2);
                }

                return DoRemoveTrailingDash(str);
            }

            return DoRemoveTrailingDash(str);
        }

        private string DoRemoveRemastered(string str)
        {
            str = str.ToLowerInvariant();
            var index = str.IndexOf("- remastered", StringComparison.Ordinal);
            if (index > -1)
            {
                return str.Substring(0, index);
            }

            index = str.IndexOf("remaster", StringComparison.Ordinal);
            if (index > -1)
            {
                var tempStr = str.Substring(0, index).Trim();
                return DoRemoveLast4CharsIfDigit(tempStr);
            }

            return str;
        }

        private string DoRemoveMtvUnplugged(string str)
        {
            str = str.ToLowerInvariant();
            var index = str.IndexOf("- mtv unplugged", StringComparison.Ordinal);
            if (index > -1) return str.Substring(0, index);

            return str;
        }

        private string DoRemoveTheFromArtistName(string artist)
        {
            return artist.Substring(3).Trim();
        }

        private static async Task<string> DoDownloadSongWithoutTheInName(string fixedArtistName, string fixedTitle)
        {
            var downloadUrl = $"https://www.azlyrics.com/lyrics/{fixedArtistName}/{fixedTitle}.html";

            using (var webClient = new WebClient())
            {
                var htmlData = await webClient.DownloadStringTaskAsync(downloadUrl);

                var doc = new HtmlDocument();
                doc.LoadHtml(htmlData);

                doc.DocumentNode.Descendants()
                    .Where(n => n.NodeType == HtmlNodeType.Comment)
                    .ToList()
                    .ForEach(n => n.Remove());

                const string xPath = "html/body/div[2]/div/div[2]/div[5]";

                var div = doc.DocumentNode.SelectNodes(xPath).FirstOrDefault();
                if (div == null) return string.Empty;

                var lyricContent = div.InnerHtml;
                lyricContent = lyricContent.Replace("<br>", Environment.NewLine);

                var lines = lyricContent.Split(Environment.NewLine).ToList();
                lines.RemoveAt(0);
                lines.RemoveAt(0);

                return string.Join(Environment.NewLine, lines);
            }
        }
    }
}