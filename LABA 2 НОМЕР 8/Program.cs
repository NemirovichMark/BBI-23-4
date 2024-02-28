using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2_НОМЕР_8
{
    internal class Program
    {
        public struct Player
        {
            private string surname;
            private int[] numberMinutes;
            public Player(string _surname, int[] _numberMinutes)
            {
                surname = _surname;
                numberMinutes = _numberMinutes;
            }
            public string Surname
            {
                get { return surname; }
                private set { surname = value; }
            }
            public int[] NumberMinutes
            {
                get { return numberMinutes; }
                private set { numberMinutes = value; }
            }
            public void PrintPlayerInfo()
            {
                Console.Write(surname + " ");
                for (int i = 0; i < numberMinutes.Length; i++)
                {
                    Console.Write(numberMinutes[i] + " ");
                }
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            Player[] players =
            { new Player ( "Иванов", new int[]{ 0, 2, 0}),
              new Player ("Захаров" , new int[]{ 5, 2, 0}),
              new Player ("Мох" , new int[]{ 5, 5, 0}),
              new Player ("Пупкин" , new int[]{ 2, 0, 10}),
              new Player ("Власов" , new int[]{ 0, 0, 0})
            };
            Sort(players);

            int count = 0; // скольтко играков получило больше 10 штрафных минут 
            for (int i = 0; i < players.Length; i++)
            {
                if (SumationOfPoints(players[i].NumberMinutes) >= 10)
                {
                    count++;
                }
            }

            Player[] players2 = new Player[players.Length - count];

            for (int i = 0; i < players2.Length; i++)
            {
                players2[i] = players[i];
            }

            for (int i = 0; i < players2.Length; i++)
            {
                players2[i].PrintPlayerInfo();
            }
        }

        static int SumationOfPoints(int[] points) // суммируем  штрафные минуты
        {
            int sum = 0;
            for (int i = 0; i < points.Length; i++)
            {
                sum += points[i];
            }
            return sum;
        }

        public static void PrintPoints(int[] points) // метод гдя обрабатываем вывод массива 
        {
            for (int i = 0; i < points.Length; i++)
            {
                Console.Write(points[i] + " ");
            }
            Console.WriteLine();
        }
        public static void Sort(Player[] players)
        {
            for (int i = 0; i < players.Length - 1; i++)
            {
                for (int j = 0; j < players.Length - 1 - i; j++)
                {
                    if (SumationOfPoints(players[j].NumberMinutes) > SumationOfPoints(players[j + 1].NumberMinutes))
                    {
                        Player temp = players[j]; players[j] = players[j + 1];
                        players[j + 1] = temp;
                    }
                }
            }
        }
    }
}


