using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2
{
    class Program
    {
        static void Main()
        {
            Sportsmen[] a = new Sportsmen[5];
            string name;
            double[] b = new double[7];
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < 7; j++)
                    b[j] = Convert.ToDouble(Console.ReadLine());
                a[i] = new Sportsmen(name, b);
            }
            initPlaces(a);
            for (int i = 0; i < a.Length; i++)
                a[i].calcSum();
            FinishPlacesSort(a);
            for (int i = 0; i < a.Length; i++)
                a[i].print();
        }
        static void initPlaces(Sportsmen[] a)
        {
            for (int j = 0; j < 7; j++)
            {
                double[] b = new double[a.Length];
                int[] p = new int[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    b[i] = a[i].getBall(j);
                    p[i] = i;
                }
                bubbleSort(b, p);
                for (int i = 0; i < a.Length; i++)
                {
                    a[p[i]].setPlace(j, i + 1);       //a[p[i]].place[j] = i+1;
                }
            }
        }
        static void bubbleSort(double[] b, int[] p)
        {
            int tmp;
            double tmpd;
            for (int step = 1; step < b.Length; step++)
                for (int i = b.Length - 1; i >= step; i--)
                    if (b[i] > b[i - 1])
                    {
                        tmpd = b[i];
                        b[i] = b[i - 1];
                        b[i - 1] = tmpd;
                        tmp = p[i];
                        p[i] = p[i - 1];
                        p[i - 1] = tmp;
                    }
        }
        static void FinishPlacesSort(Sportsmen[] a)
        {
            Sportsmen tmp;
            for (int step = 1; step < a.Length; step++)
                for (int i = a.Length - 1; i >= step; i--)
                    if (a[i].getSum() < a[i - 1].getSum())
                    {
                        tmp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = tmp;
                    }
        }
    }
    struct Sportsmen
    {
        private string name;
        private double[] ball;
        private int[] place;
        private int sum;
        public Sportsmen(string name, double[] b)
        {
            this.name = name;
            ball = new double[7];
            place = new int[7];
            for (int j = 0; j < 7; j++)
                ball[j] = b[j];
            sum = 0;
        }
        public double getBall(int j)
        {
            return ball[j];
        }
        public void setPlace(int j, int pl)
        {
            place[j] = pl;
        }
        public int getSum()
        {
            return sum;
        }
        public void print()
        {
            Console.WriteLine(name);
            for (int j = 0; j < 7; j++)
                Console.Write(ball[j] + " ");
            Console.WriteLine();
            for (int j = 0; j < 7; j++)
                Console.Write(place[j] + " ");
            Console.WriteLine();
            Console.WriteLine(sum);
        }
        public void calcSum()
        {
            sum = 0;
            for (int j = 0; j < 7; j++)
                sum += place[j];
        }
    }
}
