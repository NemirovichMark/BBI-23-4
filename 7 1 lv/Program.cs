using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_1_lv
{
    internal class Program
    {

        abstract class Character
        {
            protected string _surname, _group, _trainer;
            protected int _Distance;
            protected double _rez;
            public Character(string surname, string group, string trainer, int distance, double rez)
            {
                _surname = surname;
                _group = group;
                _trainer = trainer;
                _Distance = distance;
                _rez = rez;
            }
            public double rez { get { return _rez; } }
            public int distance { get { return _Distance; } }
            public abstract void Print();
        }
        class Run100 : Character
        {
            public Run100(string surname, string group, string trainer, int distance, double rez) : base(surname, group, trainer, distance, rez) { }
            public override void Print()
            {
                Console.WriteLine("Забег на 100 метров:");
                Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", _surname, _group, _trainer, _rez);
                if (_rez <= 2.5)
                {
                    Console.Write(" - норматив сдан");
                }
                else { Console.WriteLine(" - норматив не сдан"); }
                Console.WriteLine();
            }
        }
        class Run500 : Character
        {
            public Run500(string surname, string group, string trainer, int distance, double rez) : base(surname, group, trainer, distance, rez) { }
            public override void Print()
            {
                Console.WriteLine("Забег на 500 метров:");
                Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", _surname, _group, _trainer, _rez);
                if (_rez <= 5.0)
                {
                    Console.Write(" - норматив сдан");
                }
                else { Console.WriteLine(" - норматив не сдан"); }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Character[] runner = new Character[5];
            runner[0] = new Run100("Иванова", "1", "Полякова", 100, 3);
            runner[1] = new Run100("Смирнова", "7", "Аванесова", 100, 7);
            runner[2] = new Run500("Сидорова", "3", "Березка", 500, 5.0);
            runner[3] = new Run500("Петрова", "2", "Шварц", 500, 4.5);
            runner[4] = new Run500("Попова", "7", "Кузнецов", 500, 6.8);

            Character[] runner2 = new Character[2];
            int u = 0;
            Character[] runner3 = new Character[3];
            int v = 0;
            for (int i = 0; i < runner.Length; i++)
            {
                if (runner[i].distance == 100)
                { runner2[u] = runner[i]; u++; }
                else { runner3[v] = runner[i]; v++; }
            }
            Sort(runner2);
            Sort(runner3);
            //вывод отсортированных данных

            for (int i = 0; i < runner2.Length; i++)
            {
                runner2[i].Print();
            }
            for (int i = 0; i < runner3.Length; i++)
            {
                runner3[i].Print();
            }
        }
        static void Sort(Character[] runner)
        {
            for (int i = 0; i < runner.Length; i++)
            {
                for (int j = 0; j < runner.Length - 1 - i; j++)
                {
                    if (runner[j].rez > runner[j + 1].rez)
                    {
                        Character temp = runner[j];
                        runner[j] = runner[j + 1];
                        runner[j + 1] = temp;
                    }
                }
            }
        }
    }
}

