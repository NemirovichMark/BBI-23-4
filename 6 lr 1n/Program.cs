using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lr_1n
{
    struct Challenge
    {
        private string _fam_;
        private string club_;
        private double results1_;
        private double results2_;
        private double sum;
        public Challenge(string fam, string club, double results1, double results2)
        {
            _fam_ = fam;
            club_ = club;
            results1_ = results1;
            results2_ = results2;
            sum = (results1_ + results2_);
        }
        public double Getresults1
        {
            get => results1_;
        }
        public double Getresults2
        {
            get => results2_;
        }

        public void Print() => Console.WriteLine("familiya: {0,10} club:{1,10}  rez:{2,10}", _fam_, club_, sum);
        static void Sum(double rez1, double rez2, double sum)
        {
            sum = rez1 + rez2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Challenge[] challenge = new Challenge[3];
            challenge[0] = new Challenge("ivanov", "medv", 8, 5);
            challenge[1] = new Challenge("sidorov", "top", 6, 4);
            challenge[2] = new Challenge("smirnov", "py", 9, 10);
            double[] summ = new double[3];
            for (int i = 0; i < challenge.Length; i++)
            {
                challenge[i].Print();
            }
        }
    }
}
