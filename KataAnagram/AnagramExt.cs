using System;


namespace KataAnagram
{
    public static class AnagramExt
    {
        public static string CalculateAnagramKey(this string str)
        {
            str = ReplaceOrRemoveUnwantedCharacters(str);

            string sortedString = SortString(str);

            return sortedString;
        }

        private static string SortString(string str)
        {
            Char[] characters = str.ToCharArray();
            Array.Sort(characters);

            return new String(characters);
        }

        private static string ReplaceOrRemoveUnwantedCharacters(string str)
        {
            str = str.ToLower();
            str = str.Replace(" ", "");
            str = str.Replace("'", "");
            str = str.Replace("Å", "a");
            str = str.Replace("ö", "o");
            str = str.Replace("Ö", "o");
            str = str.Replace("Ü", "u");
            str = str.Replace("ü", "u");
            str = str.Replace("å", "a");
            str = str.Replace("é", "e");

            return str;
        }
    }
}
