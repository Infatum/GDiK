using System;
using System.IO;
using System.Collections.Generic;

namespace QestionAnswer
{
    static class Constants
    {
        public static string path1 = "./Прізвище1.txt";
        public static string path2 = "./Прізвище2.txt";
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // 1. Створити пусті файли за допомогою С# формату Прізвище1.txt, Прізвище2.txt та Прізвище3.
            if (!File.Exists(Constants.path1))
            {
                (File.Create(Constants.path1)).Close();
                (File.Create(Constants.path2)).Close();
                Console.WriteLine("Файли створені. Відкрийте файл \"Прізвище1.txt\" та запишіть туди 5 запитань.\n(Нажміть Enter щоб продовжити)");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Файли вже стоврені. Намагаюся прочитати запитання...");
            }

            // 2. Прочитати файл.
            string[] questions = File.ReadAllLines(Constants.path1);

            if (questions.Length < 1)
            {
                Console.WriteLine("Файл з запитаннями пустий. Припиняю роботу.");
                // Windows GUI programm
                //System.Windows.Forms.Application.Exit();
                // Console programm
                Environment.Exit(0);
            }

            List<string> answers = new List<string>();

            // 3. Дати відповіді на питання.
            foreach (var question in questions)
            {
                Console.WriteLine(question);
                answers.Add(Console.ReadLine());
            }

            // 4. Записати відповіді в файл Прізвище2.txt.
            File.WriteAllLines(Constants.path2, answers);
        }
    }
}
