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

namespace Lab3_Forms
{
    public partial class Form1 : Form
    {
        string[] questions;
        string[] answers;
        public Form1()
        {
            InitializeComponent();
        }

        public void QuestionAndAnswers()
        {
            // 1. Створити пусті файли за допомогою С# формату Прізвище1.txt, Прізвище2.txt та Прізвище3.
            if (!File.Exists(Constants.path1))
            {
                
                (File.Create(Constants.path2)).Close();
                MessageBox.Show("Файли створені. Відкрийте файл \"Прізвище1.txt\" та запишіть туди 5 запитань.\n(Нажміть Enter щоб продовжити)");
            }
            else
            {
                //MessageBox.Show("Файли вже стоврені. Намагаюся прочитати запитання...");
            }

            ReadFileWithQuestions(Constants.path1);
    
            // 4. Записати відповіді в файл Прізвище2.txt.
            
            //Console.ReadKey();
        }

        public void ReadFileWithQuestions(string path)
        {
            // 2. Прочитати файл
            UnicodeEncoding enc = new UnicodeEncoding();
            questions = File.ReadAllLines(path, Encoding.Default);
            List<Control> questionTextBoxes = new List<Control>();
            questionTextBoxes.Add(Question1);
            questionTextBoxes.Add(Question2);
            questionTextBoxes.Add(Question3);
            questionTextBoxes.Add(Question4);
            questionTextBoxes.Add(Question5);

            for (int i = 0; i < questionTextBoxes.Count; i++)
            {
                questionTextBoxes[i].Text = questions[i];
            }
        }

        public void ReadFileWithAnswers(string path)
        {
            // 2. Прочитати файл
            UnicodeEncoding enc = new UnicodeEncoding();
            answers = File.ReadAllLines(path, Encoding.Default);
            List<Control> answersTextBoxes = new List<Control>();
            answersTextBoxes.Add(Answer1);
            answersTextBoxes.Add(Answer2);
            answersTextBoxes.Add(Answer3);
            answersTextBoxes.Add(Answer4);
            answersTextBoxes.Add(Answer5);

            for (int i = 0; i < answersTextBoxes.Count; i++)
            {
                answersTextBoxes[i].Text = answers[i];
            }
        }

        public void WriteFileWithAnswers(string path)
        {

            List<string> answers = new List<string>();
            answers.Add(this.Answer1.Text);
            answers.Add(this.Answer2.Text);
            answers.Add(this.Answer3.Text);
            answers.Add(this.Answer4.Text);
            answers.Add(this.Answer5.Text);
            File.WriteAllLines(Constants.path2, answers, Encoding.Default);
        }

        public void WriteFileWithQuestions(string path)
        {

            List<string> questions = new List<string>();
            questions.Add(this.Question1.Text);
            questions.Add(this.Answer2.Text);
            questions.Add(this.Answer3.Text);
            questions.Add(this.Answer4.Text);
            questions.Add(this.Answer5.Text);
            File.WriteAllLines(Constants.path2, questions, Encoding.Default);
        }


        private void saveQuestions_Click(object sender, EventArgs e)
        {
            WriteFileWithQuestions(Constants.path2);
        }

        private void saveAnswers_Click(object sender, EventArgs e)
        {
            WriteFileWithAnswers(Constants.path1);
        }

        private void openQuestions_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "./";
            fileDialog.Filter = "txt files (Прізвище1.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!fileDialog.CheckFileExists)
                    (File.Create(fileDialog.FileName)).Close();

                this.ReadFileWithQuestions(fileDialog.FileName);
            }
        }

        private void openAnswers_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "./";
            fileDialog.Filter = "txt files (Прізвище1.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!fileDialog.CheckFileExists)
                    (File.Create(fileDialog.FileName)).Close();

                this.ReadFileWithAnswers(fileDialog.FileName);
            }
        }
    }
}
