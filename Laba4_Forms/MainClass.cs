using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Laba4_Forms
{
    static class Constants
    {
        public static string path1 = "./Текст.txt";
    }

    class MainClass
    {
        public int CalculateLetters(string path)
        {
            if (!File.Exists(Constants.path1))
            {
                MessageBox.Show("Text file `" + Constants.path1 + "` does'nt exist. Exit.");
                (File.Create(Constants.path1)).Close();
            }

            Dictionary<char, int> charsCounter = new Dictionary<char, int>();
            int charsTotal = 0;
            string text = File.ReadAllText(path, Encoding.Default);
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
                resultText.Append($"'{item.Key}': {item.Value}");
                resultText.Append(Environment.NewLine);
            }
            File.WriteAllText("./result.txt", resultText.ToString(), Encoding.Default);
            return charsTotal;
        }
    }
}
