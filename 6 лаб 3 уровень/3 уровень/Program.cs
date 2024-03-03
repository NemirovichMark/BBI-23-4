using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Teem[] a = new Teem[3];
            string name;
            int[] m = new int[6];
            for (int i = 0; i < a.Length; i++)
            {
                name = Console.ReadLine();
                for (int j = 0; j < m.Length; j++)
                    m[j] = Convert.ToInt32(Console.ReadLine());
                a[i] = new Teem(name, m);
            }
            int k = MaxBall(a);
            Console.Write("Winner:");
            Console.WriteLine(a[k].getName());
        }
        static public int MaxBall(Teem[] a)
        {
            int max = 0;
            int k = 0, countMax = 0;
            for (int i = 0; i < 3; i++)
                if (a[i].getSum() > max)
                {
                    max = a[i].getSum();
                    countMax = 1;
                    k = i;
                }
                else if (a[i].getSum() == max)
                    countMax += 1;
            if (countMax > 1)
                for (int i = 0; i < 3; i++)
                    if (a[i].getSum() == max)
                    {
                        if (a[i].hasFirst() == true)
                            return i;
                    }
            return k;
        }
    }
    struct Teem
    {
        private string name;
        private int[] place;
        private int[] ball;
        private int sum;
        public Teem(string name, int[] m)
        {
            this.name = name;
            place = new int[6];
            ball = new int[6];
            for (int i = 0; i < 6; i++)
            {
                place[i] = m[i];
                if (place[i] == 1)
                    ball[i] = 5;
                else if (place[i] == 2)
                    ball[i] = 4;
                else if (place[i] == 3)
                    ball[i] = 3;
                else if (place[i] == 4)
                    ball[i] = 2;
                else if (place[i] == 5)
                    ball[i] = 1;
                else ball[i] = 0;
            }
            sum = 0;
            for (int i = 0; i < 6; i++)
                sum += ball[i];
        }
        public void print()
        {
            Console.WriteLine(name);
            for (int j = 0; j < 6; j++)
                Console.Write(place[j] + " ");
            Console.WriteLine();
            for (int i = 0; i < 6; i++)
                Console.Write(ball[i] + " ");
            Console.WriteLine();
            Console.WriteLine(sum);
        }
        public int getSum()
        {
            return sum;
        }
        public string getName()
        {
            return name;
        }
        public bool hasFirst()
        {
            for (int j = 0; j < 6; j++)
                if (place[j] == 1)
                    return true;
            return false;
        }
    }
}