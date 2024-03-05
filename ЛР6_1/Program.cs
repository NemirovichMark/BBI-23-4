using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6_1
{
    internal class Program
    {
        struct Character
        {
            private string _surname, _group, _surnameTrainer;
            private double _rezult;

            public Character(string surname, string group, string surnameTrainer, double rezult)
            {
                _surname = surname;
                _group = group;
                _rezult = rezult;
                _surnameTrainer = surnameTrainer;
            }
            public double Rezult { get { return _rezult; } }
            public string Surname { get { return _surname; } }
            public string Group { get { return _group; } }
            public string SurnameTrainer { get { return _surnameTrainer; } }

            private static int counter = 0;
            public void Print()
            {
                Console.WriteLine("Фамилия: {0, 10}" + " Группа: {1, 10}" + "Тренер: {2,10}" + " Результат: {3,10}", Surname, Group, SurnameTrainer, Rezult);
                if (Rezult <= 2.5)
                {
                    Console.WriteLine("норматив сдан");
                    counter++;
                }
                else
                {
                    Console.WriteLine("норматив не сдан");
                }

                Console.WriteLine("Количество сдавших норматив", counter);
            }
        }
        static void Main(string[] args)
        {
            Character[] uchastniki = new Character[5];
            uchastniki[0] = new Character("Иванова ", "1", "Трунева", 2.2);
            uchastniki[1] = new Character("Петрова ", "2", "Сергеева", 2.1);
            uchastniki[2] = new Character("Николева ", "3", "Агапова", 2.5);
            uchastniki[3] = new Character("Цветаева ", "4", "Авдеева", 3);
            uchastniki[4] = new Character("Лебедева ", "5", "Ерёмина", 4.16);

            Sort(uchastniki);
            int counter = 0;
            for (int i = 0; i < uchastniki.Length; i++)
            {
                uchastniki[i].Print();
                if (uchastniki[i].Rezult <= 2.5)
                {
                    counter++;
                }
                Console.WriteLine();
            }
        }
        static void Sort(Character[] uchastniki)
        {
            for (int i = 0; i < uchastniki.Length; i++)
            {
                for (int j = 0; j < uchastniki.Length - 1 - i; j++)
                {
                    if (uchastniki[j].Rezult > uchastniki[j + 1].Rezult)
                    {
                        Character temp = uchastniki[j];
                        uchastniki[j] = uchastniki[j + 1];
                        uchastniki[j + 1] = temp;
                    }
                }
            }
        }

    }
}
