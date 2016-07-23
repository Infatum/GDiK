using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace Laba2
{
    public class Encrypted
    {
        private Dictionary<char, int> alphabet = new Dictionary<char, int>()
        {
            {'А', 1}, {'Б', 2}, {'В', 3}, {'Г', 4}, {'Д', 5}, {'Е', 6}, {'Ё', 7}, {'Ж', 8}, {'З', 9}, {'И', 10}, {'Й', 11}, {'К', 12}, {'Л', 13}, {'М', 14}, {'Н', 15}, {'О', 16}, {'П', 17}, {'Р', 18}, {'С', 19}, {'Т', 20}, {'У', 21}, {'Ф', 22}, {'Х', 23}, {'Ц', 24}, {'Ч', 25}, {'Ш', 26}, {'Щ', 27},{'Ы', 28}, {'Ь', 29}, {'Э', 30}, {'Ю', 31}, {'Я', 32},
            {'a', 33}, {'б', 34}, {'в', 35}, {'г', 36}, {'д', 37}, {'е', 38}, {'ё', 39}, {'ж', 40}, {'з', 41}, {'и', 42}, {'й', 43}, {'к', 44}, {'л', 45}, {'м', 46}, {'н', 47}, {'о', 48}, {'п', 49}, {'р', 50}, {'с', 51}, {'т', 52}, {'у', 53}, {'ф', 54}, {'х', 55}, {'ц', 56}, {'ч', 57}, {'ш', 58}, {'щ', 59},{'ы', 60}, {'ь', 61}, {'э', 62}, {'ю', 63}, {'я', 64},
            {'A', 65}, {'B', 66}, {'C', 67}, {'D', 68}, {'E', 69}, {'F', 70}, {'G', 71}, {'H', 72}, {'I', 73}, {'J', 74}, {'K', 75}, {'L', 76}, {'M', 77}, {'N', 78}, {'O', 79}, {'P', 80}, {'Q', 81}, {'R', 82}, {'S', 83}, {'T', 84}, {'U', 85}, {'V', 86}, {'W', 87}, {'X', 88}, {'Y', 89}, {'Z', 90},
            {'а', 91}, {'b', 92}, {'c', 93}, {'d', 94}, {'e', 95}, {'f', 96}, {'g', 97}, {'h', 98}, {'i', 99}, {'j', 100}, {'k', 101}, {'l', 102}, {'m', 103}, {'n', 104}, {'o', 105}, {'p', 106}, {'q', 107}, {'r', 108}, {'s', 109}, {'t', 110}, {'u', 111}, {'v', 112}, {'w', 113}, {'x', 114}, {'y', 115}, {'z', 116},
            {'—', 117 }, {'\'', 118 }, {'!', 119 }, {',', 120 }, {':', 121 }, {';', 123 }, {'.', 124 }, {'-', 125 }, {'(', 126 } , {')', 127 }, {'?', 128 }, {'\"', 129 }
        };
        private string OriginalText { get; set; }
        public string EncryptedText { get; private set; }
        private string Password { get; set; }
        private string SourcePath { get; set; }
        private string EncryptedFilePath { get; set; }
        private string PasswordFilePath { get; set; }
        public string DecryptedPath { get; private set; }

        public Encrypted() { }
        public Encrypted(string sourcePath)
        {
            SourcePath = sourcePath;
        }

        public Encrypted(string text, string sourcePath)
        {
            OriginalText = text;
            SourcePath = sourcePath;
        }

        public Encrypted(string text, string sourcePath, string secreeKey)
        {
            OriginalText = text;
            SourcePath = sourcePath;
            Password = secreeKey;
        }

        public void CreateEmptyFiles(string originalFilePath, string encryptedFilePath, string passwordFilePath)
        {
            try
            {
                using (FileStream originalFile = new FileStream(originalFilePath, FileMode.CreateNew))
                {

                }
                using (FileStream encryptedFile = new FileStream(encryptedFilePath, FileMode.CreateNew))
                {

                }
                using (FileStream passwordFile = new FileStream(passwordFilePath, FileMode.CreateNew))
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WriteTextToFiles(string originalFilePath, string originalText)
        {
            try
            {
                SourcePath = originalFilePath;
                UnicodeEncoding uniencoding = new UnicodeEncoding();
                byte[] result = uniencoding.GetBytes(originalText);
                char[] text = Encoding.Unicode.GetChars(result);

                using (StreamWriter wr = new StreamWriter(originalFilePath, false))
                {
                    wr.Write(originalText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WritePasswordToFile(string password, string passwordPath)
        {
            Password = password;
            PasswordFilePath = passwordPath;
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            byte[] result = uniencoding.GetBytes(Password);
            char[] paswd = Encoding.Unicode.GetChars(result);

            using (StreamWriter wr = new StreamWriter(passwordPath, false))
            {
                wr.Write(paswd);
            }
        }

        public long OriginalTextFileByteCount(string originalFilePath)
        {
            FileInfo info = new FileInfo(originalFilePath);
            return info.Length;
        }

        public string ReadPasswordFile(string path)
        {
            string Text = null;

            using (StreamReader rd = new StreamReader(path))
            {
                string ts = rd.ReadToEnd();
                Text = ts;
            }
            return Text;
        }

        public int PasswordFileCharCount(string path)
        {
            int asciSymb = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                var s = sr.ReadToEnd();
                int ts = sr.Read(s.ToCharArray(), 0, s.Length);
                asciSymb = ts;
            }
            return asciSymb;
        }

        public byte[] ReadPasswordFileToByteArray(string path)
        {
            byte[] result;
            using (FileStream fileSource = File.Open(path, FileMode.Open))
            {
                result = new byte[fileSource.Length];
                fileSource.ReadAsync(result, 0, (int)fileSource.Length);
            }
            return result;
        }
        public async Task<string> EncryptTextAsync(string passwordFilePath, string encryptedFilePath, string originalText)
        {
            PasswordFilePath = passwordFilePath;
            EncryptedFilePath = encryptedFilePath;
            OriginalText = originalText;

            float chunkCharIndex = OriginalText.Length / 2;
            var firstChunkOfText = OriginalText.Substring(0,(int)chunkCharIndex - 1);
            var secondChunkOfText = OriginalText.Substring((int)chunkCharIndex - 1);

            var tf = new TaskFactory<string>(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
            string encryption = "";
            string res = "";

            var encrTasks = new[]
                {
                tf.StartNew(() => EncryptTextFile(firstChunkOfText)),
                tf.StartNew(() => EncryptTextFile(secondChunkOfText))
                };

            try
            {
                
                encryption = await tf.ContinueWhenAll(encrTasks, completedEncryption =>
                {
                    res = encrTasks[0].Result + encrTasks[1].Result;
                    return res;
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.EncryptedText = res;
            return encryption;


        }

        public async Task<string> DecryptTextFileAsync(string decryptedFilePath)
        {
                DecryptedPath = decryptedFilePath;

                var decryption = await Task<string>.Run<string>(() => {
                    return DecryptTextFile();
                });
                WriteEncryptedDecryptedTextAsync(decryption.ToCharArray(), DecryptedPath);
                return decryption;
        }
        private string EncryptTextFile(string originalTextChunk)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            StringBuilder encryptedText = new StringBuilder();

            char[] encryptedChars = new char[originalTextChunk.Length];
            byte[] result = uniencoding.GetBytes(Password);
            char[] password = Encoding.Unicode.GetChars(result);
            int index = 0;
            int keyCarret = 0;
            int tmpCharNumber = -1;
            int tmpKeyCharNumber = -1;
            int tmpCryptedCharNumber = -1;

            foreach (var c in originalTextChunk)
            {
                if (alphabet.ContainsKey(c))
                {
                    tmpCharNumber = alphabet[c]; //Gets the current index of a character
                    tmpKeyCharNumber = alphabet[password[keyCarret % password.Length]];//Get index of current password character
                    tmpCryptedCharNumber = (tmpCharNumber + tmpKeyCharNumber);

                    if (tmpCryptedCharNumber > alphabet.Count)
                    {
                        tmpCryptedCharNumber -= alphabet.Count;//Encrupt current char in text with character from password

                    }
                    encryptedChars[index] = GetKeyByValue(tmpCryptedCharNumber);
                }
                else
                {
                    encryptedChars[index] = c;
                }
                ++index;
            }

            encryptedText.Append(encryptedChars);
            return encryptedText.ToString();
        }

        private async void WriteEncryptedDecryptedTextAsync(char[] text, string filePath)
        {
            using (StreamWriter streamCrypted = new StreamWriter(filePath))
            {
                await streamCrypted.WriteAsync(text);
            }
        }

        private char GetKeyByValue(int value)
        {
            char escape = ' ';
            foreach (var chr in this.alphabet)
            {
                if (chr.Value == value)
                {
                    return chr.Key;
                }
            }
            return escape;
        }

        private string DecryptTextFile()
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            StringBuilder decryptedText = new StringBuilder();
            
            char[] encryptedTextChars = EncryptedText.ToCharArray();
            char[] decryptedChars = new char[encryptedTextChars.Length];
            char[] password = Password.ToCharArray();
            int index = 0;
            int keyCarret = 0;
            int tmpCharNumber = -1;
            int tmpKeyCharNumber = -1;
            int tmpCryptedCharNumber = -1;

            foreach (var c in encryptedTextChars)
            {
                if (alphabet.ContainsKey(c))
                {
                    tmpCharNumber = alphabet[c]; 
                    tmpKeyCharNumber = alphabet[password[keyCarret % password.Length]];
                    tmpCryptedCharNumber = (tmpCharNumber - tmpKeyCharNumber);

                    if (tmpCryptedCharNumber < 1)
                    {
                        tmpCryptedCharNumber += alphabet.Count;

                    }
                    decryptedChars[index] = GetKeyByValue(tmpCryptedCharNumber);
                }
                else
                {
                    decryptedChars[index] = c;
                }
                ++index;
            }
            return decryptedText.Append(decryptedChars).ToString();
        }
    }
}