using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1
{
    internal class Program
    {
        struct Info
        {
            private string Name;
            private string Society;
            private int FirstResult;
            private int SecondResult;
            public int Summ { get { return FirstResult + SecondResult; } } //публичное свойство
            public Info(string name, string society, int firstResult, int secondResult) //конструктор
            {
                Name = name;
                Society = society;
                FirstResult = firstResult;
                SecondResult = secondResult;
            }
            public void Print() => Console.WriteLine($"{Name}\t{Society}\t{Summ}");
        }
        static void Main(string[] args)
        {
            Info[] info = new Info[5];

            info[0] = new Info("Юрий", "ББИ-23-4", 125, 140);    //ввод данных
            info[1] = new Info("Евгений", "ББИ-23-3", 170, 130);
            info[2] = new Info("Дмитрий", "ББИ-23-2", 105, 150);
            info[3] = new Info("Алиса", "ББИ-23-1", 201, 102);
            info[4] = new Info("Пётр", "ББИ-23-4", 168, 172);

            for (int i = 0; i < info.Length - 1; i++)   //сортировка пузырьком по сумме результатов
            {
                for (int j = i + 1; j < info.Length; j++)
                {
                    if (info[i].Summ < info[j].Summ)
                    {
                        Info pomoch = info[j];
                        info[j] = info[i];
                        info[i] = pomoch;
                    }
                }
            }

            Console.WriteLine("Место\tИмя\tОбщество\tСумма результатов"); //заголовок таблицы
            for (int i = 0; i < info.Length; i++)  //Вывод таблицы
            {
                Console.Write($"{i + 1}\t");
                info[i].Print();
            }
        }
    }
}
