using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6lb_2_ur
{
    struct Sportsmen
    {
        private string _famile_;
        private double _maxResult;

        public Sportsmen(string famile, double rez1, double rez2, double rez3)
        {
            _famile_ = famile;
            _maxResult = Math.Max(rez1, Math.Max(rez2, rez3));
        }

        public void Print() => Console.WriteLine("Famile: {0,-10} Best Result: {1,-10}", _famile_, _maxResult);

        public static void InsertionSort(Sportsmen[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                Sportsmen key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j]._maxResult > key._maxResult)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sportsmen[] players = new Sportsmen[3];
            players[0] = new Sportsmen("ivanov", 3, 8, 5);
            players[1] = new Sportsmen("sidorov", 6, 4, 7);
            players[2] = new Sportsmen("smirnov", 9, 10, 5);

            Sportsmen.InsertionSort(players, 3);

            foreach (var player in players)
            {
                player.Print();
            }
        }
    }
}
