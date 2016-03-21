﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Laba2
{
    public class Encrypted
    {
        private Dictionary<char, int> alphabet = new Dictionary<char, int>()
        {
            {'А', 1}, {'Б', 2}, {'В', 3}, {'Г', 4}, {'Д', 5}, {'Е', 6}, {'Ё', 7}, {'Ж', 8}, {'З', 9}, {'И', 10}, {'Й', 11}, {'К', 12}, {'Л', 13}, {'М', 14}, {'Н', 15}, {'О', 16}, {'П', 17}, {'Р', 18}, {'С', 19}, {'Т', 20}, {'У', 21}, {'Ф', 22}, {'Х', 23}, {'Ц', 24}, {'Ч', 25}, {'Ш', 26}, {'Щ', 27},{'Ы', 28}, {'Ь', 29}, {'Э', 30}, {'Ю', 31}, {'Я', 32},
            {'а', 33}, {'б', 34}, {'в', 35}, {'г', 36}, {'д', 37}, {'е', 38}, {'ё', 39}, {'ж', 40}, {'з', 41}, {'и', 42}, {'й', 43}, {'к', 44}, {'л', 45}, {'м', 46}, {'н', 47}, {'о', 48}, {'п', 49}, {'р', 50}, {'с', 51}, {'т', 52}, {'у', 53}, {'ф', 54}, {'х', 55}, {'ц', 56}, {'ч', 57}, {'ш', 58}, {'щ', 59},{'ы', 60}, {'ь', 61}, {'э', 62}, {'ю', 63}, {'я', 64},
            {'A', 65}, {'B', 66}, {'C', 67}, {'D', 68}, {'E', 69}, {'F', 70}, {'G', 71}, {'H', 72}, {'I', 73}, {'J', 74}, {'K', 75}, {'L', 76}, {'M', 77}, {'N', 78}, {'O', 79}, {'P', 80}, {'Q', 81}, {'R', 82}, {'S', 83}, {'T', 84}, {'U', 85}, {'V', 86}, {'W', 87}, {'X', 88}, {'Y', 89}, {'Z', 90},
            {'a', 91}, {'b', 92}, {'c', 93}, {'d', 94}, {'e', 95}, {'f', 96}, {'g', 97}, {'h', 98}, {'i', 99}, {'j', 100}, {'k', 101}, {'l', 102}, {'m', 103}, {'n', 104}, {'o', 105}, {'p', 106}, {'q', 107}, {'r', 108}, {'s', 109}, {'t', 110}, {'u', 111}, {'v', 112}, {'w', 113}, {'x', 114}, {'y', 115}, {'z', 116},
        };
        private string OriginalText { get; set; }
        public string EncryptedText { get; set; }
        private string Password { get; set; }
        private string SourcePath { get; set; }
        private string EncryptedFilePath { get; set; }
        private string PasswordFilePath { get; set; }
        public string DecryptedPath { get; set; }

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
                FileStream originalFile = new FileStream(originalFilePath, FileMode.CreateNew);
                FileStream encryptedFile = new FileStream(encryptedFilePath, FileMode.CreateNew);
                FileStream passwordFile = new FileStream(passwordFilePath, FileMode.CreateNew);
                originalFile.Dispose();
                encryptedFile.Dispose();
                passwordFile.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void WriteTextToFiles(string originalFilePath, string originalText)
        {
            try
            {
                SourcePath = originalFilePath;
                UnicodeEncoding uniencoding = new UnicodeEncoding();
                byte[] result = uniencoding.GetBytes(originalText);
                char[] text = Encoding.Unicode.GetChars(result);

                using (StreamWriter wr = new StreamWriter(originalFilePath, false))
                {
                    await wr.WriteAsync(originalText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void WritePasswordToFile(string password, string passwordPath)
        {
            Password = password;
            PasswordFilePath = password;
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            byte[] result = uniencoding.GetBytes(Password);
            char[] paswd = Encoding.Unicode.GetChars(result);

            using (StreamWriter wr = new StreamWriter(passwordPath, false))
            {
                await wr.WriteAsync(paswd);
            }
        }

        public async Task<int> OriginalTextFileByteCount(string originalFilePath)
        {
            int asciSymb = 0;

            using (StreamReader sr = new StreamReader(originalFilePath))
            {
                var s = sr.ReadToEnd();
                Task<int> ts = sr.ReadAsync(s.ToCharArray(), 0, s.Length);
                asciSymb = await ts;
            }
            return asciSymb;
        }

        public async Task<string> ReadPasswordFile(string path)
        {
            string Text = null;

            using (StreamReader rd = new StreamReader(path))
            {
                Task<string> ts = rd.ReadToEndAsync();
                Text = await ts;
            }
            return Text;
        }

        public async Task<int> PasswordFileCharCount(string path)
        {
            int asciSymb = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                var s = sr.ReadToEnd();
                Task<int> ts = sr.ReadAsync(s.ToCharArray(), 0, s.Length);
                asciSymb = await ts;
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

        public async void EncryptTextFile(string passwordFilePath, string encryptedFilePath)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            StringBuilder encryptedText = new StringBuilder();
            byte[] originalTextBytes = uniencoding.GetBytes(OriginalText);
            char[] originalTextChars = Encoding.Unicode.GetChars(originalTextBytes);
            char[] encryptedChars = new char[originalTextChars.Length];
            byte[] result = uniencoding.GetBytes(Password);
            char[] paswd = Encoding.Unicode.GetChars(result);
            int index = 0;
            int keyCarret = 0;
            int tmpCharNumber = -1;
            int tmpKeyCharNumber = -1;
            int tmpCryptedCharNumber = -1;

            foreach (var c in originalTextChars)
            {
                if (alphabet.ContainsKey(c))
                {
                    tmpCharNumber = alphabet[c]; //Gets the current index of a character
                    tmpKeyCharNumber = alphabet[paswd[keyCarret % paswd.Length]];//Get index of current password character
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
            using (StreamWriter streamCrypted = new StreamWriter(encryptedFilePath))
            {
                await streamCrypted.WriteAsync(encryptedChars);
            }
            encryptedText.Append(encryptedChars);
            this.EncryptedText = encryptedText.ToString();
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

        public async Task<string> DecryptTextFile(string encryptedFilePath, string decryptedFilePath)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            StringBuilder decryptedText = new StringBuilder();
            byte[] encryptedTextBytes = uniencoding.GetBytes(EncryptedText);
            char[] encryptedTextChars = Encoding.Unicode.GetChars(encryptedTextBytes);
            char[] decryptedChars = new char[encryptedTextChars.Length];
            byte[] result = uniencoding.GetBytes(Password);
            char[] paswd = Encoding.Unicode.GetChars(result);
            int index = 0;
            int keyCarret = 0;
            int tmpCharNumber = -1;
            int tmpKeyCharNumber = -1;
            int tmpCryptedCharNumber = -1;

            foreach (var c in encryptedTextChars)
            {
                if (alphabet.ContainsKey(c))
                {
                    tmpCharNumber = alphabet[c]; //Gets the current index of a character
                    tmpKeyCharNumber = alphabet[paswd[keyCarret % paswd.Length]];//Get index of current password character
                    tmpCryptedCharNumber = (tmpCharNumber - tmpKeyCharNumber);

                    if (tmpCryptedCharNumber < 1)
                    {
                        tmpCryptedCharNumber += alphabet.Count;//Encrupt current char in text with character from password

                    }
                    decryptedChars[index] = GetKeyByValue(tmpCryptedCharNumber);
                }
                else
                {
                    decryptedChars[index] = c;
                }
                ++index;
            }

            using (StreamWriter streamCrypted = new StreamWriter(encryptedFilePath))
            {
                 await streamCrypted.WriteAsync(decryptedChars);
            }
            return decryptedText.Append(decryptedChars).ToString();
        }
    }
}