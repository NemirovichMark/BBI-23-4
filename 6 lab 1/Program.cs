using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lab_1
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
            public void Print() => Console.WriteLine("Фамилия:{0, 10} Группа:{1, 10}" +
                    " Тренер:{2, 10} Результат:{3, 10}", Surname, Group, Trainer, Rez);
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
            int k = 0;//счетчик выполнивших норматив
            for (int i = 0; i < runner.Length; i++)
            {
                runner[i].Print();
            }
            Console.WriteLine($"Количество сдавших норматив: {k}");
        }
        static void Sort(Character[] runner)
        {
            for (int i = 0; i < runner.Length; i++)
            {
                for (int j = 0; j < runner.Length - 1 - i; j++)
                {
                    if (runner[j].Rez > runner[j + 1].Rez)
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
