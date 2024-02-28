using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_уровень_4_задача
{
    struct Result
    {
        public string surname;
        public int result;
        public Result(string surname_, int result_)
        {
            surname = surname_;
            result = result_;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Result[] group1 = new Result[]
            {
            new Result("Иванов", 150),
            new Result("Петров", 160),
            new Result("Сидоров", 140)
            };

            Result[] group2 = new Result[]
            {
            new Result("Смирнов", 155),
            new Result("Козлов", 145),
            new Result("Морозов", 165)
            };

            BubbleSort(group1);
            BubbleSort(group2);

            Result[] all = new Result[group1.Length + group2.Length];
            Array.Copy(group1, all, group1.Length);
            Array.Copy(group2, 0, all, group1.Length, group2.Length);

            BubbleSort(all);

            Console.WriteLine("Фамилия   Результат");
            foreach (Result result in all)
            {
                Console.WriteLine(result.surname + "   " + result.result);
            }
        }

        static void BubbleSort(Result[] results)
        {
            int n = results.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (results[j].result > results[j + 1].result)
                    {
                        // Обмен элементов
                        Result temp = results[j];
                        results[j] = results[j + 1];
                        results[j + 1] = temp;
                    }
                }
            }
        }
    }
}
