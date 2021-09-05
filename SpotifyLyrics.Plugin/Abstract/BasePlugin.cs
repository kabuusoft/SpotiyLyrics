using System;

namespace SpotifyLyrics.Plugin.Abstract
{
    public class BasePlugin
    {
        protected string DoRemoveRemastered(string str)
        {
            str = str.ToLowerInvariant();
            var index = str.IndexOf("- remastered", StringComparison.Ordinal);
            if (index > -1) return str.Substring(0, index);

            index = str.IndexOf("remaster", StringComparison.Ordinal);
            if (index > -1)
            {
                var tempStr = str.Substring(0, index).Trim();
                return DoRemoveLast4CharsIfDigit(tempStr);
            }

            return str;
        }

        protected string DoRemoveMtvUnplugged(string str)
        {
            str = str.ToLowerInvariant();
            var index = str.IndexOf("- mtv unplugged", StringComparison.Ordinal);
            if (index > -1) return str.Substring(0, index);

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

        protected string DoRemoveTheFromArtistName(string artist)
        {
            return artist.Substring(3).Trim();
        }

        private string DoRemoveTrailingDash(string str)
        {
            if (str.EndsWith("-")) return str.Substring(0, str.Length - 1);

            return str;
        }
        protected string TurkishCharacterToEnglish(string text)
        {
            string[] turkishChars = { "ı", "ğ", "İ", "Ğ", "ç", "Ç", "ş", "Ş", "ö", "Ö", "ü", "Ü" };
            string[] englishChars = { "", "g", "i", "G", "c", "C", "s", "S", "o", "O", "u", "U" };

            // Match chars
            for (int i = 0; i < turkishChars.Length; i++)
                text = text.Replace(turkishChars[i], englishChars[i]);

            return text;
        }
    }
}