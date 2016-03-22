using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Laba1_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        static class Constants
        {
            public const int DEF_OFFSET = 3;
            public const string path1 = "./Vityuk1.txt";
            public const string path2 = "./Vityuk2.txt";
            public const string path3 = "./Vityuk3.txt";
        }

        class MainClass
        {

            public static void Main(string[] args)
            {
                string[] lines;
                try
                {
                    lines = File.ReadAllLines(Constants.path1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("File does'nt exist, try to create new file. Input you lines (empty line - to finish):");
                    List<string> inputLinesList = new List<string>();
                    string inputLine;
                    while (!String.IsNullOrEmpty(inputLine = Console.ReadLine()))
                    {
                        inputLinesList.Add(inputLine);
                    }

                    string[] inputLines = inputLinesList.ToArray();

                    using (File.Create(Constants.path1))
                    {

                    }

                    File.WriteAllLines(Constants.path1, inputLines);

                    lines = File.ReadAllLines(Constants.path1);
                }


                // Get offset
                GetOffset:
                Console.Write("Offset (def: " + Constants.DEF_OFFSET + "): ");
                string strOffset = Console.ReadLine();
                int offset = Constants.DEF_OFFSET;
                if (strOffset != String.Empty)
                {
                    try
                    {
                        offset = Int32.Parse(strOffset);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong value, use decimal:");
                        goto GetOffset;
                    }
                }

                // Create crypt object
                Cesar cryptMethod = new Cesar(offset, (int)("А")[0], (int)("я")[0]);

                // Prepare variables for crypt
                List<string> cryptedLinesList = new List<string>();
                string[] cryptedLines;

                // Crypt every line
                foreach (var line in lines)
                {
                    cryptedLinesList.Add(cryptMethod.Encrypt(line));
                }
                cryptedLines = cryptedLinesList.ToArray();

                // Create file if not exist
                if (File.Exists(Constants.path2))
                {
                    File.Create(Constants.path2);
                }

                // Write data to file
                File.WriteAllLines(Constants.path2, cryptedLines);

                // Prepare variables for decrypt
                List<string> decryptedLinesList = new List<string>();
                string[] decryptedLines;
                if (File.Exists(Constants.path2))
                {
                    // Read file
                    lines = File.ReadAllLines(Constants.path2);

                    // Decrypt every line
                    foreach (var line in lines)
                    {
                        decryptedLinesList.Add(cryptMethod.Decrypt(line));
                    }
                    decryptedLines = decryptedLinesList.ToArray();

                    // Create file if not exist
                    if (File.Exists(Constants.path3))
                    {
                        File.Create(Constants.path3);
                    }

                    // Write data to file
                    File.WriteAllLines(Constants.path3, decryptedLines);
                }

                Console.ReadKey();
            }
        }


        public class Cesar
        {
            int offset = 0;
            int chars_length;
            int min_length;
            int max_length;

            public Cesar(int offset, int min_letter, int max_letter)
            {
                this.min_length = min_letter;
                this.max_length = max_letter;
                this.chars_length = max_letter - min_letter + 1;
                this.offset = offset % chars_length;
            }

            public string Encrypt(string str)
            {
                string tmp = "";
                int tmp_chr;

                foreach (var chr in str)
                {
                    if (isIgnoreChar(chr))
                    {
                        tmp += chr;
                        continue;
                    }

                    tmp_chr = ((int)chr + offset);
                    if (tmp_chr > max_length)
                    {
                        tmp_chr -= chars_length;
                    }
                    tmp += (char)tmp_chr;
                }
                return tmp;
            }

            public string Decrypt(string str)
            {
                string tmp = "";
                int tmp_chr;

                foreach (var chr in str)
                {
                    if (isIgnoreChar(chr))
                    {
                        tmp += chr;
                        continue;
                    }
                    tmp_chr = ((int)chr - offset);
                    if (tmp_chr < min_length)
                    {
                        tmp_chr += chars_length;
                    }
                    tmp += (char)tmp_chr;
                }
                return tmp;
            }

            bool isIgnoreChar(char c)
            {
                return c == '_' || ((int)c < min_length || (int)c > max_length);
            }
        }
    }

}

