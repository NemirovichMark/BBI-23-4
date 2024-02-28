using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class Program
    {
        struct Sportsmen
        {
            private string name;
            private double rez1;
            private double rez2;
            public Sportsmen(string name, double rez1, double rez2)
            {
                this.name = name;
                this.rez1 = rez1;
                this.rez2 = rez2;
            }
            public double getRez1()
            {
                return rez1;
            }
            public double getRez2()
            {
                return rez2;
            }
            public void print()
            {
                Console.WriteLine(name + " " + rez1 + " " + rez2);
            }

        }
        static void Sort(Sportsmen[] a)
        {
            Sportsmen tmp;
            for (int step = 1; step < a.Length; step++)
                for (int i = a.Length - 1; i >= step; i--)
                    if (Math.Max(a[i].getRez1(), a[i].getRez2()) > Math.Max(a[i - 1].getRez1(), a[i - 1].getRez2()))
                    {
                        tmp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = tmp;
                    }
        }
        static void Main()
        {
            Sportsmen[] a = new Sportsmen[5];
            string name;
            double r1, r2;
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                r1 = Convert.ToDouble(Console.ReadLine());
                r2 = Convert.ToDouble(Console.ReadLine());
                a[i] = new Sportsmen(name, r1, r2);
            }
            for (int i = 0; i < a.Length; i++)
                a[i].print();
            Sort(a);
            for (int i = 0; i < a.Length; i++)
                a[i].print();
        }
    }
}
