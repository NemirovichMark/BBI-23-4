using System;

class SkiRace
{
    class Athlete
    {
        protected string lastName;
        protected double time;

        public Athlete(string lastName, double time)
        {
            this.lastName = lastName;
            this.time = time;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public double GetTime()
        {
            return time;
        }

        public virtual void Print()
        {
            Console.WriteLine("{0, -10} {1, -10}", GetLastName(), GetTime());
        }
    }

    class Skier : Athlete
    {
        public Skier(string lastName, double time) : base(lastName, time)
        {
        }
    }

    class SkierWoman : Athlete
    {
        public SkierWoman(string lastName, double time) : base(lastName, time)
        {
        }
    }

    static void Main(string[] args)
    {
        Athlete[] skierMenGroup1 = {
            new Skier("Иванов", 30.5),
            new Skier("Петров", 29.8),
            new Skier("Сидоров", 31.2),
        };

        Athlete[] skierMenGroup2 = {
            new Skier("Смирнов", 28.7),
            new Skier("Васильев", 30.1),
            new Skier("Николаев", 29.5),
        };

        Athlete[] skierWomenGroup1 = {
            new SkierWoman("Семенова", 28.7),
            new SkierWoman("Козлова", 30.1),
            new SkierWoman("Михайлова", 29.5),
        };

        Athlete[] skierWomenGroup2 = {
            new SkierWoman("Петрова", 27.5),
            new SkierWoman("Сидорова", 29.9),
            new SkierWoman("Иванова", 28.3),
        };

        SortResults(skierMenGroup1);
        SortResults(skierMenGroup2);
        SortResults(skierWomenGroup1);
        SortResults(skierWomenGroup2);

        Athlete[] combinedMenResults = new Athlete[skierMenGroup1.Length + skierMenGroup2.Length];
        CopyMas(skierMenGroup1, combinedMenResults, 0);
        CopyMas(skierMenGroup2, combinedMenResults, skierMenGroup1.Length);

        Athlete[] combinedWomenResults = new Athlete[skierWomenGroup1.Length + skierWomenGroup2.Length];
        CopyMas(skierWomenGroup1, combinedWomenResults, 0);
        CopyMas(skierWomenGroup2, combinedWomenResults, skierWomenGroup1.Length);// уже добавили вуменгруп1 поэтому начало с вуменгруп1

        //сортировка полученных групп
        SortResults(combinedMenResults);
        SortResults(combinedWomenResults);

        Console.WriteLine("Результаты гонок:");
        Console.WriteLine("Лыжники Группа 1:");
        PrintResults(skierMenGroup1);
        Console.WriteLine("Лыжники Группа 2:");
        PrintResults(skierMenGroup2);
        Console.WriteLine("Лыжницы Группа 1:");
        PrintResults(skierWomenGroup1);
        Console.WriteLine("Лыжницы Группа 2:");
        PrintResults(skierWomenGroup2);
        Console.WriteLine("Общие результаты лыжников:");
        PrintResults(combinedMenResults);
        Console.WriteLine("Общие результаты лыжниц:");
        PrintResults(combinedWomenResults);
    }
    
    //копирование из одного массива в другой
    static void CopyMas(Athlete[] source, Athlete[] destination, int start)
    {
        for (int i = 0; i < source.Length; i++)
        {
            destination[start + i] = source[i];
        }
    }

    static void SortResults(Athlete[] results)
    {
        for (int i = 0; i < results.Length - 1; i++)
        {
            for (int j = 0; j < results.Length - 1 - i; j++)
            {
                if (results[j].GetTime() > results[j + 1].GetTime())
                {
                    Athlete temp = results[j];
                    results[j] = results[j + 1];
                    results[j + 1] = temp;
                }
            }
        }
    }

    static void PrintResults(Athlete[] results)
    {
        Console.WriteLine("{0, -10} {1, -10}", "Фамилия:", "Время:");
        foreach (var result in results)
        {
            result.Print();
        }
        Console.WriteLine();
    }
}
