using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace KataAnagram
{
    class Program
    {
        private static long _elapsedTime;

        static void Main(string[] args)
        {
            const string FILE = "wordlist.txt";
            const string SORTED_WORDS = "WordsSorted.txt";
            const string STANDARD_TEXT_ENCODING = "iso-8859-1";
            const string ERROR_MESSAGE = "The file could not be read.";

            AnagramList container = new AnagramList();
            var stopWatch = Stopwatch.StartNew();
            try
            {
                

                using (StreamReader streamReader = new StreamReader(FILE, Encoding.GetEncoding(STANDARD_TEXT_ENCODING)))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        container.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(ERROR_MESSAGE);
                Console.WriteLine(e.Message);
            }

            string message = container.ToString();

            File.WriteAllText(SORTED_WORDS, message);

            stopWatch.Stop();
            _elapsedTime = stopWatch.ElapsedMilliseconds;

            Console.WriteLine(string.Format("\r\nElapsed time with file read: {0} ms", _elapsedTime.ToString()));
        }
    }
    
}
