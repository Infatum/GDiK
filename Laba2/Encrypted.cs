using System;
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
        private string OriginalText { get; set; }
        public string EncryptedText { get; }
        private string Password { get; set; }

        public Encrypted(string text)
        {
            OriginalText = text;
        }

        public async void CreateFilesWithText(string path, string path2, Encoding encoding)
        {
            try
            {
                FileStream encryptedFile = new FileStream(path2, FileMode.CreateNew);
                UnicodeEncoding uniencoding = new UnicodeEncoding();
                byte[] result = uniencoding.GetBytes(OriginalText);

                using (FileStream source = File.Open(path, FileMode.OpenOrCreate))
                {
                    source.Seek(0, SeekOrigin.End);
                    await source.WriteAsync(result, 0, result.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void WritePasswordToFile(string password, string path)
        {
            Password = password;
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            byte[] result = uniencoding.GetBytes(password);

            using (FileStream wr = new FileStream(path, FileMode.Open))
            {
                wr.Write(result, 0, result.Length);
            }
        }

        public async Task<int> ReadTextFileByteCount(string path)
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

        public async Task<byte[]> ReadPasswordFileToByteArray(string path)
        {
            byte[] result;
            using (FileStream fileSource = File.Open(path, FileMode.Open))
            {
                result = new byte[fileSource.Length];
                await fileSource.ReadAsync(result, 0, (int)fileSource.Length);   
            }
            return result;
        }

        public async Task<byte[]> EncryptTextFile(string sourceFilePath, string encryptedFilePath)
        {
            byte[] password = ReadPasswordFileToByteArray(sourceFilePath).Result;
            byte[] encryptedText;
            int index = 0;

            using (FileStream fileSource = File.Open(sourceFilePath, FileMode.Open))
            {
                encryptedText = new byte[fileSource.Length];
                for (int i = 0; i < fileSource.Length; i++)
                {
                    
                    if(i == password.Length - 1)
                    {
                        index = 0;
                    }
                    
                    encryptedText[i] += (byte)(password[index] % ((int)'А' - 1));
                    ++index;
                }
                using (FileStream encryptedFile = File.OpenWrite(encryptedFilePath))
                {
                    encryptedFile.Seek(0, SeekOrigin.Begin);
                    await encryptedFile.WriteAsync(encryptedText, 0, encryptedText.Length);
                }
            }
            return encryptedText;
        }

        public byte[] DecryptTextFile(string encryptedFilePath, string passwordFilePath)
        {
            byte[] decryptedText;
            byte[] encryptedText;
            int passwordCount = 
            int index = 0;

            using (FileStream encrypted = File.OpenRead(encryptedFilePath))
            {
                encryptedText = new byte[encrypted.Length];
                encrypted.Read(encryptedText, 0, (int)encrypted.Length);

                for (int i = 0; i < encrypted.Length; i++)
                {
                    encryptedText[i] += (byte)(password[index] % ((int)'А' - 1));
                    ++index;
                }

            }  
        }
    }
}