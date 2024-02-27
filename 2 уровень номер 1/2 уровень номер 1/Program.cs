using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_уровень_номер_1
{ 
    internal class Program
    {
        struct table
        {
            private string name;
            private double firstexam;
            private double secondexam;
            private double thirdexam;
            private double fourthexam;
            private double sr;
            public double Firstexam
            {
                get
                {
                    return firstexam;
                }
                set
                {
                    firstexam = value;
                }
            }
            public double Secondexam
            {
                get
                {
                    return secondexam;
                }
                set
                {
                    secondexam = value;
                }
            }
            public double Thirdtexam
            {
                get
                {
                    return thirdexam;
                }
                set
                {
                    thirdexam = value;
                }
            }
            public double Fourthexam
            {
                get
                {
                    return fourthexam;
                }
                set
                {
                    fourthexam = value;
                }
            }
            public double SR
            {
                get
                {
                    return sr;
                }
                set
                {
                    sr = value;
                }
            }
            public table(string name_, double firstexam_, double secondexam_, double thirdexam_, double fourthexam_)
            {
                name = name_;
                firstexam = firstexam_;
                secondexam = secondexam_;
                thirdexam = thirdexam_;
                fourthexam = fourthexam_;
                sr = 0;
                if ((firstexam + secondexam + thirdexam + fourthexam) / 4 >= 4)
                {
                    sr = (firstexam + secondexam + thirdexam + fourthexam) / 4;
                }
            }
            public void Print()
            {
                if (sr >= 4)

                {
                    Console.WriteLine("{0},   {1}", name, sr);

                }
            }
        }
        static void Main(string[] args)
        {
            table[] results = new table[5];
            results[0] = new table("Cherep", 5, 2, 3, 5);
            results[1] = new table("Chufireva", 5, 5, 4, 4);
            results[2] = new table("Perminova", 5, 4, 4, 5);
            results[3] = new table("Katina", 4, 3, 3, 5);
            results[4] = new table("Ivanov", 2, 4, 3, 2);
            results = sort(results);

            for (int i = 0; i < results.Length; i++)

            { results[i].Print(); }

        }
        static table[] sort(table[] results)
        {
            for (int i = 0; i < results.Length - 1; i++)
            {

                for (int j = i; j < results.Length; j++)
                {
                    if (results[i].SR < results[j].SR)
                    {

                        table all = results[j];
                        results[j] = results[i];
                        results[i] = all;

                    }
                }
            }
            return results;
        }
    }
}
   
