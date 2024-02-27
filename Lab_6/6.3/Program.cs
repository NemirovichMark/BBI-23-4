using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    internal class Program
    {
        struct Info
        {
            public string Name;
            public double Mark;
            public Info(string name, double mark)
            {
                Name = name;
                Mark = mark;
            }
        }
        static void Main(string[] args)
        {
            Info[] group1 = new Info[5] { new Info("Павлов", 3.5), new Info("Попов", 3.9), new Info("Ли", 2.2), new Info("Ким", 3.2), new Info("Блоков", 2.5) };  //Ввод данных
            Info[] group2 = new Info[5] { new Info("Добров", 1.9), new Info("Злов", 3.8), new Info("Шойгу", 3.2), new Info("Фет", 2.7), new Info("Чехов", 3.1) };

            Console.WriteLine("Группа 1");
            Console.WriteLine();
            for (int i = 0; i < group1.Length; i++) //Вывод исходных данных группа 1
                Console.WriteLine("Фамилии: {0}\t Результаты: {1}", group1[i].Name, group1[i].Mark);
            Console.WriteLine();

            Console.WriteLine("Группа 2");
            Console.WriteLine();
            for (int i = 0; i < group2.Length; i++) //Вывод исходных данных группа 2
                Console.WriteLine("Фамилии: {0}\t Результаты: {1}", group2[i].Name, group2[i].Mark);
            Console.WriteLine();

            Sortirovka(group1); //Сортировка группы 1
            Sortirovka(group2); //Сортировка группы 2

            Info[] allgroup = new Info[group1.Length + group2.Length];  //Совмещение групп в одну
            for (int i = 0; i < group1.Length; i++)
                allgroup[i] = group1[i];
            for (int i = group1.Length; i < group1.Length + group2.Length; i++)
                allgroup[i] = group2[i - group1.Length];

            Sortirovka(allgroup); //Сортировка всех результатов

            Console.WriteLine("Все группы");  //Вывод всех результатов
            Console.WriteLine();
            for (int i = 0; i < allgroup.Length; i++)
                Console.WriteLine("Фамилии: {0}\t Результаты: {1}", allgroup[i].Name, allgroup[i].Mark);
        }
        static void Sortirovka(Info[] info)
        {
            for (int i = 0; i < info.Length - 1; i++)  //Сортировка пузырьком по убыванию
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[j].Mark > info[i].Mark)
                    {
                        Info pomoch = info[j];
                        info[j] = info[i];
                        info[i] = pomoch;
                    }
                }
            }
        }
    }
}
