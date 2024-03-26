using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lr_1_ur
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

        public void Print() => Console.WriteLine("familiya: {0,-10} club: {1,-10} rez: {2,-10}", _fam_, club_, sum);

        public static void InsertionSort(Challenge[] arr, int n)
        {
            for (int i = 1; i < n; i++)
            {
                Challenge key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].sum > key.sum)
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
            Challenge[] challenge = new Challenge[5];
            challenge[0] = new Challenge("ivanov", "medv", 8, 5);
            challenge[1] = new Challenge("sidorov", "top", 6, 4);
            challenge[2] = new Challenge("smirnov", "py", 9, 10);
            challenge[3] = new Challenge("dorov", "top", 16, 4);
            challenge[4] = new Challenge("mirnov", "py", 19, 10);

            Challenge.InsertionSort(challenge, 5);

            for (int i = 0; i < 5; i++)
            {
                challenge[i].Print();
            }
        }
    }
}
