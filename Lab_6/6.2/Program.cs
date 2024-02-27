using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2
{
    struct Info
    {
        public string Surname;
        public double[] Marks;
        public double Summ;
        public Info(string surname, double[] marks)
        {
            Surname = surname;
            Marks = marks;
            Summ = 0;
            for (int i = 0; i < Marks.Length; i++) //подсчёт суммы
                Summ += Marks[i];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Info[] info = new Info[5];
            info[0] = new Info("Павлов", new double[] { 0.5, 0, 0, 0.5, 1, 0 });  //ввод данных
            info[1] = new Info("Попов", new double[] { 1, 1, 0, 0.5, 0, 0.5 });
            info[2] = new Info("Ли", new double[] { 0, 1, 1, 0.5, 0, 1 });
            info[3] = new Info("Ким", new double[] { 0, 0, 1, 0.5, 0, 1 });
            info[4] = new Info("Блоков", new double[] { 1, 1, 1, 0.5, 0, 0 });
            for (int i = 0; i < info.Length; i++)
                Console.WriteLine("Фамилия: {0}\t Набранные быллы: {1,4:f2}", info[i].Surname, info[i].Summ);

            Sortirovka(info); //сортировка

            Console.WriteLine();
            Console.WriteLine("Место\t Фамилия\t Набранные баллы");
            for (int i = 0; i < info.Length; i++)  //Вывод итоговой таблицы
                Console.WriteLine("{0}\t {1}\t         {2}", i + 1, info[i].Surname, info[i].Summ);
        }
        static void Sortirovka(Info[] info)
        {
            for (int i = 0; i < info.Length - 1; i++)  //Сортировка пузырьком по убыванию
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[j].Summ > info[i].Summ)
                    {
                        Info pomoch = info[j];
                        info[j] = info[i];
                        info[i] = pomoch;
                    }
                }
            }
        }
    }
}
