using System;
using System.Xml.Linq;

namespace Lab_6th
{
    internal class Program
    {
        abstract class Jump
        {
            protected int _points = 0;
            protected string _surname = "";
            protected string _name = "Jump";
            public int Points { get { return _points; } private set { _points += value; } }
            public Jump(string surname) { _surname = surname; CalculateJumpPoints(); CalculateJuryPoints(); }
            public void Write()
            {
                Console.WriteLine($"Дисциплина {_name}, Участник {_surname}, Счёт: {_points}");
            }
            void CalculateJuryPoints()
            {
                Random random = new Random();
                int max = 0;
                int min = 21;
                for (int i = 0; i < 5; i++)
                {
                    int point = random.Next(0, 20);
                    if (point < min) min = point;
                    if (point > max) max = point;
                    Points = point;
                }
                Points = -1 * (min + max);
            }
            void CalculateJumpPoints()
            {
                Random random = new Random();
                int jump = random.Next(100, 140);
                Points = (jump - 120) * 2;
            }
        }
        class Jump120 : Jump
        {
            public Jump120(string surname) : base(surname) { _name = "Jump120"; }
        }
        class Jump180 : Jump
        {
            
            public Jump180(string surname) : base(surname) { _name = "Jump180"; }
        }
        static void Main(string[] args)
        {
            void ShellSort120(Jump120[] array)
            {
                int size = array.Length;
                for (int interval = size / 2; interval > 0; interval /= 2)
                {
                    for (int i = interval; i < size; i++)
                    {
                        Jump120 currentKey = array[i];
                        int k = i;
                        while (k >= interval && array[k - interval].Points < currentKey.Points)
                        {
                            array[k] = array[k - interval];
                            k -= interval;
                        }
                        array[k] = currentKey;
                    }
                }
            }
            void ShellSort180(Jump180[] array)
            {
                int size = array.Length;
                for (int interval = size / 2; interval > 0; interval /= 2)
                {
                    for (int i = interval; i < size; i++)
                    {
                        Jump180 currentKey = array[i];
                        int k = i;
                        while (k >= interval && array[k - interval].Points < currentKey.Points)
                        {
                            array[k] = array[k - interval];
                            k -= interval;
                        }
                        array[k] = currentKey;
                    }
                }
            }
            string[] Surnames = { "Хвойный", "Вертюк", "Пенаст", "Гаврилов", "Тернюк" };
            Jump180[] Competitors = new Jump180[Surnames.Length];
            for (int i = 0; i < Surnames.Length; i++)
            {
                Competitors[i] = new Jump180(Surnames[i]);
            }
            ShellSort180(Competitors);
            for (int i = 0; i < Competitors.Length; i++)
            {
                Competitors[i].Write();
            }
            Jump120[] Competitors2 = new Jump120[Surnames.Length];
            for (int i = 0; i < Surnames.Length; i++)
            {
                Competitors2[i] = new Jump120(Surnames[i]);
            }
            ShellSort120(Competitors2);
            for (int i = 0; i < Competitors2.Length; i++)
            {
                Competitors2[i].Write();
            }
            Console.ReadKey();
        }
    }
}