using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2
{
    struct Info
    {
        private string Surname;
        private double[] Marks;
        private double Summa;
        public double Summ { get { return Summa; } } //публичное свойство
        public Info(string surname, double[] marks)
        {
            Surname = surname;
            Marks = marks;
            Summa = 0;
            for (int i = 0; i < Marks.Length; i++) { Summa += Marks[i]; } //подсчёт суммы
        }
        public void Print() => Console.WriteLine("{0}\t {1}", Surname, Summa);
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
            Console.WriteLine("Фамилия\t Набранные быллы");  //вывод исходных данных
            for (int i = 0; i < info.Length; i++)
                info[i].Print();

            Sortirovka(info); //сортировка

            Console.WriteLine();
            Console.WriteLine("Место\tФамилия\t Набранные баллы");
            for (int i = 0; i < info.Length; i++)  //Вывод итоговой таблицы
            {
                Console.Write($"{i + 1}\t");
                info[i].Print();
            }
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
