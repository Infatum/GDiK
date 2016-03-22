using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CharsCounter
{
    static class Constants
    {
        public static string path1 = "./text.txt";
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            if (!File.Exists(Constants.path1))
            {
                Console.WriteLine("Text file `" + Constants.path1 + "` does'nt exist. Exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Dictionary<char, int> charsCounter = new Dictionary<char, int>();
            int charsTotal = 0;
            string text = File.ReadAllText(Constants.path1);
            StringBuilder resultText = new StringBuilder();

            // Count data
            foreach (var chr in text)
            {
                // Skip not interesting symbols
                if (chr == '\n' || chr == '\r')
                {
                    continue;
                }

                if (charsCounter.ContainsKey(chr))
                {
                    charsCounter[chr]++;
                }
                else
                {
                    charsCounter.Add(chr, 1);
                }
                charsTotal++;
            }

            // Print data
            Console.WriteLine("Total letters: " + charsTotal);
            foreach (var item in charsCounter)
            {
                Console.WriteLine("'{0}': {1}", item.Key, item.Value);
                resultText.Append( $"'{item.Key}'" + ": " + item.Value);
            }
            FileStream fs = new FileStream("./result.txt", FileMode.Create);
            fs.Dispose();
            using (StreamWriter sw = new StreamWriter("./result.txt"))
            {
                sw.Write(resultText);
            }

            Console.ReadKey();
        }
    }
}
