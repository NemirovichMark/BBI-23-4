using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _6th_lab
{
    struct Character
    {
        private int _x_pos; // default(int) = 0
        private int _y_pos;
        private string _name; // default(string) = null 
        private static int _counter; // принаджелит всему типу, а не какому-то отдельно объекту

        public double Distance { get { return Math.Sqrt(_x_pos * _x_pos + _y_pos * _y_pos); } }// публичное свойство
        public int Age { get; private set; } // автосвойство только для чтения!!!
        public int Lvl { get; private set; } // автосвойство только для чтения!!!
        public static int Counter { get { return _counter; } } // автосвойство только для чтения!!!

        public Character(int x, int y, string name) // конструктор для создания переменной с типом Character
        {
            _x_pos = x; // Обязательно все поля и автосвойства проинициализировать!
            _y_pos = y;
            _name = name;
            Lvl = 0;
            Age = new Random().Next(18, 25);
        }
        public void Print() => Console.WriteLine("{0,10}, {1, 10}, {2, 10}", _x_pos, _y_pos, _name);
        public void LvlUp()
        {
            Lvl++;
            _counter++;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            double cost = 12.34;
            string name = "Jack";

            int[] ints = { 1, 2, 3 };
            string[] strings = { "Bob", "Dilan" };

            Character enemy = new Character();
            Character[] players = new Character[ints.Length];
            players[0] = new Character(1, 2, "Jonatan");
            players[1] = new Character(-8, 2, "Smith");
            players[2] = new Character(1, 6, "Rob");

            for (int i = 0; i < players.Length; i++)
            {
                players[i].Print();
                players[i].LvlUp();
            }

            players[2].LvlUp();
            players[2].LvlUp();
            Sort(players);

            for (int i = 0; i < players.Length; i++)
            {
                players[i].Print();
                Console.WriteLine("Player lvl:" + players[i].Lvl);
                Console.WriteLine("Counter:" + Character.Counter);
            }

            enemy = FindYoungest(players); // получить копию из метода
            Character friend = new Character();
            FindYoungest(players, ref friend);
            friend.Print();
            Console.ReadKey();
        }

        static void Sort(Character[] players) 
        {
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = i; j < players.Length; j++)
                    if (players[i].Distance < players[j].Distance)
                    {
                        Character character = players[j]; // меняем
                        players[j] = players[i]; // местами
                        players[i] = character; // игроков
                    }
            }
        }

        static Character FindYoungest(Character[] players) // вернуть значение
        {
            if (players == null && players.Length <= 0) // валидация
                return new Character(); // конструктор по умолчанию
            Character youngest = players[0]; // 
            for (int i = 1; i < players.Length; i++)
            {
                if (players[i].Age < youngest.Age)
                {
                    youngest = players[i];
                }
            }
            return youngest;
        }

        static void FindYoungest(Character[] players, ref Character youngest) // вернуть значение
        {
            if (players == null && players.Length <= 0) // валидация
                return; // конструктор по умолчанию
            youngest = players[0]; // 
            for (int i = 1; i < players.Length; i++)
            {
                if (players[i].Age < youngest.Age)
                {
                    youngest = players[i];
                }
            }
        }
    }
}
