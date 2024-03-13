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
            public int Summ { get { return FirstResult + SecondResult; } } 
            public Info(string name, string society, int firstResult, int secondResult) 
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




using System; 
 
namespace SkiJumpCompetition 
{ 
    // External structure to store competitor information 
    public struct Competitor 
    { 
        private string lastName; 
        private double[] styleScores; // массив оценок за стиль прыжка 
        private double jumpDistance; 
        private double totalScore; 
 
        public Competitor(string lastName, double[] styleScores, double jumpDistance) 
        { 
            this.lastName = lastName; 
            this.styleScores = styleScores; 
            this.jumpDistance = jumpDistance; 
            this.totalScore = 0; 
            CalculateTotalScore(); 
        } 
 
        public string GetLastName() 
        { 
            return this.lastName; 
        } 
 
        public double GetTotalScore() 
        { 
            return this.totalScore; 
        } 
 
        private void CalculateTotalScore() 
        { 
            const int NumJudges = 5; 
            const double BaseDistance = 120.0; 
            const double BaseScore = 60.0; 
            const double ScorePerMeter = 2.0; // за каждый метр превышения 
            const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения 
 
            for (int i = 0; i < NumJudges; i++) 
            { 
                // Сортируем оценки судей по возрастанию 
                BubbleSort(styleScores); 
 
                // Отбрасываем наименьшую, наибольшую оценки и суммируем остальные 
                double sum = 0; 
                for (int k = 1; k < styleScores.Length - 1; k++) 
                { 
                    sum += styleScores[k]; 
                } 
 
                double distanceDifference = jumpDistance - BaseDistance; 
                double distanceScore = distanceDifference > 0 
                    ? BaseScore + distanceDifference * ScorePerMeter // больше нуля 
                    : BaseScore + distanceDifference * PenaltyPerMeter; // меньше нуля 
 
                totalScore = sum + distanceScore; 
            } 
        } 
 
        static void BubbleSort(double[] arr) 
        { 
            for (int i = 0; i < arr.Length - 1; i++) 
            { 
                for (int j = 0; j < arr.Length - i - 1; j++) 
                { 
                    if (arr[j] > arr[j + 1]) 
                    { 
                        double temp = arr[j]; 
                        arr[j] = arr[j + 1]; 
                        arr[j + 1] = temp; 
                    } 
                } 
            } 
        } 
    } 
 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            // участники, StyleScores по 20-балльной шкале 
            Competitor[] competitors = new Competitor[5]; 
            competitors[0] = new Competitor("Семенов", new double[] { 18.5, 17.5, 19.0, 20.0, 18.0 }, 122.0); 
            competitors[1] = new Competitor("Иванов", new double[] { 19.0, 18.0, 17.0, 16.5, 18.5 }, 118.0); 
            competitors[2] = new Competitor("Смирнов", new double[] { 20.0, 19.5, 19.0, 18.5, 20.0 }, 125.0); 
            competitors[3] = new Competitor("Галков", new double[] { 17.5, 17.0, 18.5, 19.0, 18.0 }, 121.5); 
            competitors[4] = new Competitor("Добров", new double[] { 19.5, 20.0, 19.0, 18.5, 19.5 }, 123.5); 
 
            // сортировка по результатам 
            for (int i = 0; i < competitors.Length - 1; i++) 
            { 
                for (int j = i + 1; j < competitors.Length; j++) 
                { 
                    if (competitors[j].GetTotalScore() > competitors[i].GetTotalScore()) 
                    { 
                        var temp = competitors[i]; 
                        competitors[i] = competitors[j]; 
                        competitors[j] = temp; 
                    } 
                } 
            } 
 
            Console.WriteLine("Результаты:"); 
            for (int i = 0; i < competitors.Length; i++) 
            { 
                Console.WriteLine($"{i + 1}. {competitors[i].GetLastName()}: {competitors[i].GetTotalScore()} очков"); 
            } 
        } 
    } 
}







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
