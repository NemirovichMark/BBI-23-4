using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_защита
{
    internal class Program
    {

        struct Character
        {
            private string _surname, _group, _trainer;
            private double _rez;
            public Character(string surname, string group, string trainer, double rez)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _rez = rez;
            }
            public double Rez
            { get { return _rez; } }
            public string Surname
            { get { return _surname; } }
            public string Group
            { get { return _group; } }

            public string Trainer
            { get { return _trainer; } }
            private static int k = 0;//счётчик
            public void Print()
            {

                Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", Surname, Group, Trainer, Rez);
                if (Rez <= 2.5)
                {
                    Console.Write(" - норматив сдан"); k++;
                }
                else { Console.WriteLine(" - норматив не сдан"); }
                Console.WriteLine($"Количество сдавших норматив: {k}");
            }
        }
        static void Main(string[] args)
        {
            Character[] runner = new Character[5];
            runner[0] = new Character("Иванова", "1", "Полякова", 3);
            runner[1] = new Character("Смирнова", "7", "Аванесова", 1.3);
            runner[2] = new Character("Сидорова", "3", "Березка", 5.0);
            runner[3] = new Character("Петрова", "2", "Шварц", 2.5);
            runner[4] = new Character("Попова", "7", "Кузнецов", 1.9);

            Sort(runner);
            //вывод отсортированных данных

            for (int i = 0; i < runner.Length; i++)
            {
                runner[i].Print();
            }
        }
        static void Sort(Character[] runner)
        {
            int d = runner.Length / 2;
            while (d > 0)
            {
                for (int i = d; i < runner.Length; i++)
                {
                    int j = i;
                    Character temp = runner[i];
                    while ((j >= d) && (runner[j - d].Rez > temp.Rez))
                    {
                        runner[j] = runner[j - d];
                        j -= d;
                    }
                    runner[j] = temp;
                }
                d = d / 2;
            }
        }
    }
}
