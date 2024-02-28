using System;

class SkiRace
{
    struct CompetitorResult
    {
        public string LastName;
        public double Time;
    }

    static void Main(string[] args)
    {
        CompetitorResult[] group1Results = {
            new CompetitorResult { LastName = "Иванов", Time = 30.5 },
            new CompetitorResult { LastName = "Петров", Time = 29.8 },
            new CompetitorResult { LastName = "Сидоров", Time = 31.2 },
        };

        CompetitorResult[] group2Results = {
            new CompetitorResult { LastName = "Семенов", Time = 28.7 },
            new CompetitorResult { LastName = "Козлов", Time = 30.1 },
            new CompetitorResult { LastName = "Михайлов", Time = 29.5 },
        };

        // сортировка результатов в каждой группе по времени (по возрастанию)
        SortResults(group1Results);
        SortResults(group2Results);

        // объединение результатов групп
        CompetitorResult[] combinedResults = FullResults(group1Results, group2Results);

        // результаты в виде таблицы
        Console.WriteLine("Результаты гонок:");
        Console.WriteLine("Группа 1:");
        PrintResults(group1Results);
        Console.WriteLine("Группа 2:");
        PrintResults(group2Results);
        Console.WriteLine("Общие результаты:");
        PrintResults(combinedResults);
    }

    // сортировка по возрастанию
    static void SortResults(CompetitorResult[] results)
    {
        for (int i = 0; i < results.Length - 1; i++)
        {
            for (int j = 0; j < results.Length - 1 - i; j++)
            {
                if (results[j].Time > results[j + 1].Time)
                {
                    CompetitorResult temp = results[j];
                    results[j] = results[j + 1];
                    results[j + 1] = temp;
                }
            }
        }
    }

    // объединение результатов двух групп
    static CompetitorResult[] FullResults(CompetitorResult[] results1, CompetitorResult[] results2)
    {
        int totalLength = results1.Length + results2.Length;
        CompetitorResult[] combinedResults = new CompetitorResult[totalLength];

        int index = 0;
        foreach (var result in results1)
        {
            combinedResults[index] = result;
            index++;
        }
        foreach (var result in results2)
        {
            combinedResults[index] = result;
            index++;
        }

        // сортируем объединенные результаты
        SortResults(combinedResults);

        return combinedResults;
    }

    // вывод результатов в виде таблицы
    static void PrintResults(CompetitorResult[] results)
    {
        Console.WriteLine("{0, -10} {1, -10}", "Фамилия", "Время");
        foreach (var result in results)
        {
            Console.WriteLine("{0, -10} {1, -10}", result.LastName, result.Time);
        }
        Console.WriteLine();
    }
}
