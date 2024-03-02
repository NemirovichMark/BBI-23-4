using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lab_2_lv__3_task
{
    struct Sportsmen
    {
        private string _famile_;
        private double rez_1, rez_2, rez_3;
        public Sportsmen(string famile, double rez1, double rez2, double rez3)
        {
            rez_1 = rez1;
            rez_2 = rez2;
            rez_3 = rez3;
            _famile_ = famile;
        }
        public double Getrez1
        {
            get => rez_1;
        }
        public double Getrez2
        {
            get => rez_2;
        }
        public double Getrez3
        {
            get => rez_3;
        }
        public void Print(Sportsmen players, double rez) => Console.WriteLine("Famile:{0,10} Rez{1,10}", _famile_, rez);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Sportsmen[] players = new Sportsmen[3];
            players[0] = new Sportsmen("ivanov", 3, 4, 5);
            players[1] = new Sportsmen("sidorov", 6, 4, 7);
            players[2] = new Sportsmen("smirnov", 9, 10, 5);
            double[] itog = new double[3];
            for (int i = 0; i < 3; i++)
            {
                PoiskMax(players[i].Getrez1, players[i].Getrez2, players[i].Getrez3, ref itog[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                players[i].Print(players[i], itog[i]);
            }
        }
        static void PoiskMax(double a, double b, double c, ref double orig)
        {
            double max = 0;
            double[] wew = new double[3] { a, b, c };
            for (int i = 0; i < 3; i++)
            {
                if (wew[i] > max)
                {
                    max = wew[i];
                }
            }
            orig = max;
        }
    }
}
