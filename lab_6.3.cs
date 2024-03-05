// using System;

// class SkiRace
// {
//     struct CompetitorResult
//     {
//         private string LastName;
//         private double Time;

//         public CompetitorResult(string lastName, double time)
//         {
//             LastName = lastName;
//             Time = time;
//         }

//         public string GetLastName()
//         {
//             return LastName;
//         }

//         public double GetTime()
//         {
//             return Time;
//         }

//         public void Print()
//         {
//             Console.WriteLine("{0, -10} {1, -10}", GetLastName(), GetTime());
//         }
//     }

//     static void Main(string[] args)
//     {
//         CompetitorResult[] group1Results = {
//             new CompetitorResult("Иванов", 30.5),
//             new CompetitorResult("Петров", 29.8),
//             new CompetitorResult("Сидоров", 31.2),
//         };

//         CompetitorResult[] group2Results = {
//             new CompetitorResult("Семенов", 28.7),
//             new CompetitorResult("Козлов", 30.1),
//             new CompetitorResult("Михайлов", 29.5),
//         };

//         SortResults(group1Results);
//         SortResults(group2Results);

//         CompetitorResult[] combinedResults = FullResults(group1Results, group2Results);

//         Console.WriteLine("Результаты гонок:");
//         Console.WriteLine("Группа 1:");
//         PrintResults(group1Results);
//         Console.WriteLine("Группа 2:");
//         PrintResults(group2Results);
//         Console.WriteLine("Общие результаты:");
//         PrintResults(combinedResults);
//     }

//     static void SortResults(CompetitorResult[] results)
//     {
//         for (int i = 0; i < results.Length - 1; i++)
//         {
//             for (int j = 0; j < results.Length - 1 - i; j++)
//             {
//                 if (results[j].GetTime() > results[j + 1].GetTime())
//                 {
//                     CompetitorResult temp = results[j];
//                     results[j] = results[j + 1];
//                     results[j + 1] = temp;
//                 }
//             }
//         }
//     }

//     static CompetitorResult[] FullResults(CompetitorResult[] results1, CompetitorResult[] results2)
//     {
//         int totalLength = results1.Length + results2.Length;
//         CompetitorResult[] combinedResults = new CompetitorResult[totalLength];

//         int index = 0;
//         foreach (var result in results1)
//         {
//             combinedResults[index] = result;
//             index++;
//         }
//         foreach (var result in results2)
//         {
//             combinedResults[index] = result;
//             index++;
//         }

//         SortResults(combinedResults);

//         return combinedResults;
//     }

//     static void PrintResults(CompetitorResult[] results)
//     {
//         Console.WriteLine("{0, -10} {1, -10}", "Фамилия", "Время");
//         foreach (var result in results)
//         {
//             result.Print();
//         }
//         Console.WriteLine();
//     }
// }
