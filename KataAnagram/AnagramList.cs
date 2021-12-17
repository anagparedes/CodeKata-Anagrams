using System;
using System.Collections.Generic;


namespace KataAnagram
{
    public class AnagramList
    {
        private const string ANAGRAM_SEPARATOR = ", ";
        private const string DIFFERENT_ANAGRAM_SEPARATOR = "\r\n";

        Dictionary<String, List<String>> AnagramCollection = new Dictionary<String, List<String>>();

        public void Add(string str)
        {
            string anagramkey = str.CalculateAnagramKey();
            if (AnagramCollection.ContainsKey(anagramkey))
            {
                AnagramCollection.TryGetValue(anagramkey, out List<string> Anagrams);
                Anagrams.Add(str);
            }
            else
            {
                AnagramCollection.Add(anagramkey, new List<string> { str });
            }

        }

        public override string ToString()
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            AppendAnagrams(stringBuilder);

            return stringBuilder.ToString();
        }

        private void AppendAnagrams(System.Text.StringBuilder stringBuilder)
        {
            foreach (var anagrams in AnagramCollection.Values)
            {
                AppendLine(stringBuilder, anagrams);

                stringBuilder.Append(DIFFERENT_ANAGRAM_SEPARATOR);
            }

            RemoveLast(stringBuilder, DIFFERENT_ANAGRAM_SEPARATOR.Length);
        }

        private static void AppendLine(System.Text.StringBuilder stringBuilder, List<string> anagrams)
        {
            foreach (string word in anagrams)
            {
                AppendAnagram(stringBuilder, word);
            }

            RemoveLast(stringBuilder, ANAGRAM_SEPARATOR.Length);
        }

        private static void RemoveLast(System.Text.StringBuilder stringBuilder, int length)
        {
            stringBuilder.Remove( length - stringBuilder.Length , length);
        }

        private static void AppendAnagram(System.Text.StringBuilder stringBuilder, string word)
        {
            stringBuilder.Append(word);
            stringBuilder.Append(ANAGRAM_SEPARATOR);
        }
    }
}
