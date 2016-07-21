using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Collections.ObjectModel;

namespace Laba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encrypted file;
        List<string> filesInDir = new List<string>();
        List<string> XFiles = new List<string>();
        string directoryPath = "./Laba3";
        string filename;
        string passwordFileName;
        string encryptedFileName;
        string decryptedFileName;
        ObservableCollection<string> files = new ObservableCollection<string>();

        public ObservableCollection<string> Files { get { return files; } }
        string[] filesinDirAll;

        public MainWindow()
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(fileName.Text))
            {
                CreateFile_btn.IsEnabled = false;
            }
            if (Directory.Exists(directoryPath))
            {
                filesinDirAll = Directory.GetFiles(directoryPath);
                foreach (var file in filesinDirAll)
                {
                    if (file.EndsWith("_Encrypted.txt") || file.EndsWith("_Password.txt") || file.EndsWith("_Decrypted.txt"))
                    {
                        XFiles.Add(file);
                        continue;
                    }
                    else
                    {
                        files.Add(file);
                    }
                }
                file = new Encrypted();
                this.DataContext = this;

            }
        }

        private void NameChanged(object sender, TextChangedEventArgs e)
        {
            CreateFile_btn.IsEnabled = true;
        }

        private void Create_File(object sender, RoutedEventArgs e)
        {

            CreateFiles();
        }

        private void CreateFiles()
        {

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            filename = directoryPath + "/" + fileName.Text + ".txt";
            encryptedFileName = directoryPath + '/' + fileName.Text + "_Encrypted" + ".txt";
            passwordFileName = directoryPath + '/' + fileName.Text + "_Password" + ".txt";
            file = new Encrypted(fileContent.Text, filename);
            file.CreateEmptyFiles(filename, encryptedFileName, passwordFileName);
        }

        private void Save_File_Click(object sender, RoutedEventArgs e)
        {
            if (file == null)
            {
                file = new Encrypted(filename, fileContent.Text);
            }
            //Regex reg = new Regex("//");
            if (filename != null)
            {
                //filename = Regex.Replace(@"\w-");
                file.WriteTextToFiles(filename, fileContent.Text);
            }
            else
            {
                MessageBox.Show("Please, create file first");
                return;
            }
        }

        private async void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {

            if (filename == null)
            {
                MessageBox.Show("Create or choose file first");
                return;
            }
            file.WritePasswordToFile(this.Password_Text.Text, passwordFileName);
            var result = await file.EncryptTextAsync(passwordFileName, encryptedFileName, fileContent.Text);
            this.Encrypted_Decrypted_TextBox.Text = result;

        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(decryptedFileName))
            {
                decryptedFileName = fileName.Text.Replace(".txt", "_Decrypted.txt");
            }

            if (!File.Exists(decryptedFileName))
            {
                FileStream decryptedFile = new FileStream(decryptedFileName, FileMode.CreateNew);
                decryptedFile.Dispose();
            }
            this.Encrypted_Decrypted_TextBox.Text = file.DecryptTextFile(encryptedFileName, decryptedFileName);
        }

        private void fileChanged(object sender, SelectionChangedEventArgs e)
        {

            CreateFile_btn.IsEnabled = true;
            this.fileName.Text = filesList.SelectedItem.ToString();
            string currentFileSelected = filesList.SelectedItem.ToString();
            filename = currentFileSelected;
            string fileText = null;
            foreach (var file in XFiles)
            {
                if (file.EndsWith("_Encrypted.txt"))
                {
                    encryptedFileName = file;
                }
                if (file.EndsWith("_Password.txt"))
                {
                    passwordFileName = file;
                }
                if (file.EndsWith("_Decrypted.txt"))
                {
                    decryptedFileName = file;
                }
            }
            using (StreamReader sr = new StreamReader(currentFileSelected))
            {
                fileText = sr.ReadToEnd();
            }
            fileContent.Text = fileText;
        }
    }
}
