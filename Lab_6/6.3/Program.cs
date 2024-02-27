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
            private string Name;
            private double Mark;
            public double Ocenka { get { return Mark; } } //Публичное свойство
            public Info(string name, double mark)
            {
                Name = name;
                Mark = mark;
            }
            public void Print() => Console.WriteLine("{0}\t {1}", Name, Mark);
        }
        static void Main(string[] args)
        {
            Info[] group1 = new Info[5] { new Info("Павлов", 3.5), new Info("Попов", 3.9), new Info("Ли", 2.2), new Info("Ким", 3.2), new Info("Блоков", 2.5) };  //Ввод данных
            Info[] group2 = new Info[5] { new Info("Добров", 1.9), new Info("Злов", 3.8), new Info("Шойгу", 3.2), new Info("Фет", 2.7), new Info("Чехов", 3.1) };

            Sortirovka(group1); //Сортировка группы 1
            Console.WriteLine("Группа 1");
            Console.WriteLine("Фамилии\t Резульаты");
            for (int i = 0; i < group1.Length; i++) //Вывод отсортированных данных группы 1
                group1[i].Print();
            Console.WriteLine();

            Sortirovka(group2); //Сортировка группы 2
            Console.WriteLine("Группа 2");
            Console.WriteLine("Фамилии\t Резульаты");
            for (int i = 0; i < group2.Length; i++) //Вывод отсортированных данных группы 2
                group2[i].Print();
            Console.WriteLine();

            Info[] allgroup = new Info[group1.Length + group2.Length];  //Создание объединенной таблицы
            allgroup = Combination(group1, group2); //Объединение двух групп в одну

            Console.WriteLine("Все группы");  //Вывод всех результатов
            Console.WriteLine("Фамилии\t Резульаты");
            for (int i = 0; i < allgroup.Length; i++)
                allgroup[i].Print();
        }
        static void Sortirovka(Info[] info)
        {
            for (int i = 0; i < info.Length - 1; i++)  //Сортировка пузырьком по убыванию
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[j].Ocenka > info[i].Ocenka)
                    {
                        Info pomoch = info[j];
                        info[j] = info[i];
                        info[i] = pomoch;
                    }
                }
            }
        }
        static Info[] Combination(Info[] info1, Info[] info2)  //Соединение двух групп в одну
        {
            Info[] comb = new Info[info1.Length + info2.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < info1.Length && j < info2.Length)  //Пока одна из групп не будет полностью в объединённой таблице
            {
                if (info1[i].Ocenka > info2[j].Ocenka) //Наибольшее значение ставится наверх таблицы
                {
                    comb[k] = info1[i];
                    i++;
                    k++;
                }
                else
                {
                    comb[k] = info2[j];
                    j++;
                    k++;
                }
            }
            if (i == info1.Length && k < comb.Length)  //Оставшиеся элементы загоняются в таблицу без сравнения
            {
                for (int a = j; k < comb.Length; a++)
                {
                    comb[k] = info2[a];
                    k++;
                }
            }
            if (j == info2.Length && k < comb.Length)
            {
                for (int a = i; k < comb.Length; a++)
                {
                    comb[k] = info1[a];
                    k++;
                }
            }
            return comb;
        }
    }
}
