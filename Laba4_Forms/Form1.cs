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

                this.ReadFileWithQuestions(fileDialog.FileName);
            }
        }

        public void ReadFileWithQuestions(string path)
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
    }
}
