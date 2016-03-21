using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Laba2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Encrypted file;
        UnicodeEncoding encoding;
        string directoryPath = "./Laba3";
        string filename;
        string passwordfileName;
        string encryptedFileName;
        string DecryptedFileName;
        ObservableCollection<string> files = new ObservableCollection<string>();

        public ObservableCollection<string> Files { get { return files; } }
        string[] filesinDir;

        public MainWindow()
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(fileName.Text))
            {
                CreateFile_btn.IsEnabled = false;
            }
            if (Directory.Exists(directoryPath))
            {
                filesinDir = Directory.GetFiles(directoryPath);
                foreach (var file in filesinDir)
                {
                    files.Add(file);
                }

                this.DataContext = this;

            }
        }

        private void CreateFile_btn_Click(object sender, RoutedEventArgs e)
        {
            
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
            passwordfileName = directoryPath + '/' + fileName.Text + "_Password" + ".txt";
            file = new Encrypted(fileContent.Text, filename);
            file.CreateEmptyFiles(filename, encryptedFileName, passwordfileName);
        }

        private void Save_File_Click(object sender, RoutedEventArgs e)
        {
            if (filename != null)
            {
                file.WriteTextToFiles(filename, fileContent.Text);
            }
            else
            {
                MessageBox.Show("Please, create file first");
                return;
            }
        }

        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            if (filename == null)
            {
                MessageBox.Show("Create or choose file first");
                return;
            }
            file.WritePasswordToFile(this.Password_Text.Text, passwordfileName);
            file.EncryptTextFile(passwordfileName, encryptedFileName);

        }

        private void Decrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            DecryptedFileName = directoryPath + '/' + fileName.Text + "_Decrypted" + ".txt";
            if (File.Exists(encryptedFileName))
            {
                if (!File.Exists(DecryptedFileName))
                {
                    FileStream decryptedFile = new FileStream(DecryptedFileName, FileMode.CreateNew);
                    decryptedFile.Dispose();
                }
                Encrypted_Decrypted_TextBox.Text = file.DecryptTextFile(encryptedFileName, DecryptedFileName).Result;
            }
        }

        private void fileChanged(object sender, SelectionChangedEventArgs e)
        {
            string currentFileSelected = filesList.SelectedItem.ToString();
            string fileText = null;
            using (StreamReader sr = new StreamReader(currentFileSelected))
            {
                fileText = sr.ReadToEnd();
            }
            fileContent.Text = fileText;
        }
    }
}
