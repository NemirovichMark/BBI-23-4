using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР_2_2_2
{
    struct Sportsmen
    {
        private string _surname;
        private double rez_1, rez_2, rez_3;
        public Sportsmen(string surname, double rez1, double rez2, double rez3)
        {
            rez_1 = rez1;
            rez_2 = rez2;
            rez_3 = rez3;
            _surname = surname;
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
        public void Print(Sportsmen players, double rez) => Console.WriteLine("Фамилия: {0,10} Результат: {1,10}", _surname, rez);
        public void PoiskBest(double a, double b, double c, ref double maxim)
        {
            double maxx = 0;
            double[] tec = new double[3] { a, b, c };
            for (int i = 0; i < 3; i++)
            {
                if (tec[i] > maxx)
                {
                    maxx = tec[i];
                }
            }
            maxim = maxx;
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Sportsmen[] players = new Sportsmen[5];
                players[0] = new Sportsmen("Иванов", 5, 4, 3);
                players[1] = new Sportsmen("Лебедев", 6, 4, 7);
                players[2] = new Sportsmen("Андреев", 9, 8, 9);
                double[] end = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    players[i].PoiskBest(players[i].Getrez1, players[i].Getrez2, players[i].Getrez3, ref end[i]);
                }
                for (int i = 0; i < 3; i++)
                {
                    players[i].Print(players[i], end[i]);
                }
            }

        }
    }
}
