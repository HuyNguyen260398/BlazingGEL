using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BlazingGEL.WASM.Static;

public static class Extension
{
    public static string GenerateSlug(string phrase)
    {
        string str = RemoveAcent(phrase).ToLower();

        // invalid chars
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

        // convert multiple spaces into one space
        str = Regex.Replace(str, @"\s+", " ").Trim();

        // cut and trim
        str = str.Substring(0, str.Length <= 50 ? str.Length : 50).Trim();

        // add hyphens
        str = Regex.Replace(str, @"\s", "-");

        return str;
    }

    public static string RemoveAcent(string phrase)
    {
        //byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(phrase);
        //return Encoding.ASCII.GetString(bytes);

        if (string.IsNullOrWhiteSpace(phrase))
            return phrase;

        phrase = phrase.Normalize(NormalizationForm.FormD);
        char[] chars = phrase
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
            != UnicodeCategory.NonSpacingMark).ToArray();

        return new string(chars).Normalize(NormalizationForm.FormC);
    }
}
