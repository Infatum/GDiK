using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba4_Forms
{
    public partial class Form1 : Form
    {
        private string[] text;
        private string path;
        private string path2 = "./result.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "./";
            fileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!fileDialog.CheckFileExists)
                    (File.Create(fileDialog.FileName)).Close();
                this.path = fileDialog.FileName;
                this.ReadFileWithText(fileDialog.FileName);
            }
        }

        public void ReadFileWithText(string path)
        {
            // 2. Прочитати файл
            UnicodeEncoding enc = new UnicodeEncoding();
            text = File.ReadAllLines(path, Encoding.Default);
            StringBuilder textInfield = new StringBuilder();

            foreach (var t in text)
            {
                textInfield.Append(t);
                textInfield.Append(Environment.NewLine);
            }
            this.textField.Text = textInfield.ToString();
        }

        private void clculateSymbolsBtn_Click(object sender, EventArgs e)
        {
            MainClass charsCount = new MainClass();
            charsCount.CalculateLetters(path);
            UnicodeEncoding enc = new UnicodeEncoding();
            var calculated = File.ReadAllLines(path2, Encoding.Default);
            StringBuilder calculatedSymbols = new StringBuilder();

            foreach (var s in calculated)
            {
                calculatedSymbols.Append(s);
                calculatedSymbols.Append(Environment.NewLine);
            }
            this.calculatedSymbolsField.Text = calculatedSymbols.ToString();
        }
    }
}
