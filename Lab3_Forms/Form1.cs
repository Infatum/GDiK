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
        public Form1()
        {
            InitializeComponent();
            QuestionAndAnswers();
            

        }

        public void QuestionAndAnswers()
        {
            // 1. Створити пусті файли за допомогою С# формату Прізвище1.txt, Прізвище2.txt та Прізвище3.
            if (!File.Exists(Constants.path1))
            {
                (File.Create(Constants.path1)).Close();
                (File.Create(Constants.path2)).Close();
                MessageBox.Show("Файли створені. Відкрийте файл \"Прізвище1.txt\" та запишіть туди 5 запитань.\n(Нажміть Enter щоб продовжити)");
            }
            else
            {
                //MessageBox.Show("Файли вже стоврені. Намагаюся прочитати запитання...");
            }

            ReadFileWithQuestions();
    
            // 4. Записати відповіді в файл Прізвище2.txt.
            
            //Console.ReadKey();
        }

        public void ReadFileWithQuestions()
        {
            // 2. Прочитати файл
            UnicodeEncoding enc = new UnicodeEncoding();
            questions = File.ReadAllLines(Constants.path1, Encoding.Default);
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
    }
}
