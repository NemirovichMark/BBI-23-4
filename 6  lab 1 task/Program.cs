using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6__lab_1_task
{
    class Program
    {
        public struct Challenge
        {
            public string Name, club;
            public int[] results;
            public int sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Колличество участников: ");
            int n = int.Parse(Console.ReadLine());
            Challenge[] ch = new Challenge[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Фам {i + 1} участника: ");
                ch[i].Name = Console.ReadLine();
                Console.Write($"Клуб {i + 1} участника: ");
                ch[i].club = Console.ReadLine();
                ch[i].results = new int[2];
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{j + 1} результат {i + 1} участника: ");
                    ch[i].results[j] = int.Parse(Console.ReadLine());
                }
                ch[i].sum = ch[i].results.Sum();
            }
            Console.WriteLine("Место\tФам\tКлуб\tСумма результатов");
            for (int i = 0; i < n; i++)
                Console.WriteLine($"{i + 1}\t{ch[i].Name}\t{ch[i].club}\t{ch[i].sum}");
            Console.ReadLine();
        }
    }
}
