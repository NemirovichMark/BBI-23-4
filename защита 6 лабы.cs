using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace уровень_1_номер_3
{
    struct survey
    {
        private string name;
        private int votes;
        private static int total = 0;

        public string Name
        {
            get { return name; }
        }

        public int Votes
        {
            get { return votes; }
        }

        public survey(string name_, int votes_)
        {
            name = name_;
            votes = votes_;
            total += votes;
        }

        public static void Percentage(survey[] answers)

        {
            foreach (survey answer in answers)
            {
                double percentage = ((double)answer.Votes / total) * 100;
                Console.WriteLine($"{answer.Name}: {percentage.ToString("0.00")}%");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            survey[] answers = new survey[]
            {
                new survey("Ivan", 150),
                new survey("Katya", 120),
                new survey("Lera", 135),
                new survey("Sergey", 140),
                new survey("Kolya", 120)
            };

            int a = 0;
            int b = 1;
            while (a < answers.Length)
            {
                if (a == 0 || answers[a].Votes >= answers[a - 1].Votes)
                {
                    a = b;
                    b++;
                }
                else
                {
                    survey temp = answers[a];
                    answers[a] = answers[a - 1];
                    answers[a - 1] = temp;
                    a--;
                }
            }

            survey.Percentage(answers); // вызываем метод для вывода процентов голосов
        }
    }
}

//namespace _2_уровень_
//{
//    class Program
//    {
//        struct table
//        {
//            private string name;
//            private double[] exams;
//            private double sr;

//            public double SR
//            {
//                get { return sr; }
//                set { sr = value; }
//            }

//            public table(string name_, double[] exams_)
//            {
//                name = name_;
//                exams = exams_;
//                sr = 0;
//                sr = SR_();
//            }

//            private double SR_()
//            {
//                double total = 0;
//                foreach (double exam in exams)
//                {
//                    total += exam;
//                }
//                return total / exams.Length;
//            }

//            public void Print()
//            {
//                if (sr >= 4)
//                {
//                    Console.WriteLine("{0},   {1}", name, sr);
//                }
//            }
//        }

//        static void Main()
//        {
//            table[] results = new table[5];
//            results[0] = new table("Cherep", new double[] { 5, 2, 3, 5 });
//            results[1] = new table("Chufireva", new double[] { 5, 5, 4, 4 });
//            results[2] = new table("Perminova", new double[] { 2, 4, 4, 5 });
//            results[3] = new table("Katina", new double[] { 4, 3, 3, 5 });
//            results[4] = new table("Ivanov", new double[] { 5, 4, 3, 2 });

//            results = SortResults(results);

//            Console.WriteLine("Фамилия   Средний балл");
//            foreach (table result in results)
//            {
//                result.Print();
//            }
//        }

//        static table[] SortResults(table[] results)
//        {
//            for (int i = 0; i < results.Length - 1; i++)
//            {
//                for (int j = i; j < results.Length; j++)
//                {
//                    if (results[i].SR < results[j].SR)
//                    {
//                        table temp = results[j];
//                        results[j] = results[i];
//                        results[i] = temp;
//                    }
//                }
//            }

//            return results;
//        }
//    }
//}

