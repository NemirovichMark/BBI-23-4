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

        public double Distance { get { return Math.Sqrt(_x_pos * _x_pos + _y_pos * _y_pos); } }// публичное свойство
        
        public int Lvl { get; private set; } // автосвойство только для чтения!!!

        public Character(int x, int y, string name) // конструктор для создания переменной с типом Character
        {
            _x_pos = x; // Обязательно все поля и автосвойства проинициализировать!
            _y_pos = y;
            _name = name;
            Lvl = 0;
        }
        public void Print() => Console.WriteLine($"{_x_pos}, {_y_pos}, {_name}"); 
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
            players[0] = new Character(1,2, "Jonatan");
            players[1] = new Character(-8, 2, "Smith");
            players[2] = new Character(1, 6, "Rob");

            for (int i = 0; i < players.Length; i++)
            {
                players[i].Print();
            }

            players = Sort(players);


            for (int i = 0; i < players.Length; i++)
            {
                players[i].Print();
                Console.WriteLine(players[i].Lvl);
            }

        }

        static Character[] Sort(Character[] players) 
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
                // do sort
                return players; // вернуть тот же тип, что требуется у метода
        }
    }
}
