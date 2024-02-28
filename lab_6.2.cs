// using System;

// namespace SkiJumpCompetition
// {
//     // External structure to store competitor information
//     public struct Competitor
//     {
//         public string LastName;
//         public double[] StyleScores; // массив оценок за стиль прыжка
//         public double JumpDistance;
//         public double TotalScore;
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             const int NumJudges = 5;
//             const double BaseDistance = 120.0;
//             const double BaseScore = 60.0;
//             const double ScorePerMeter = 2.0; // за каждый метр превышения
//             const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

//             // участники, StyleScores по 20-балльной шкале
//             Competitor[] competitors = new Competitor[5];
//             competitors[0] = new Competitor { LastName = "Семенов", StyleScores = new double[] { 18.5, 17.5, 19.0, 20.0, 18.0 }, JumpDistance = 122.0 };
//             competitors[1] = new Competitor { LastName = "Иванов", StyleScores = new double[] { 19.0, 18.0, 17.0, 16.5, 18.5 }, JumpDistance = 118.0 };
//             competitors[2] = new Competitor { LastName = "Смирнов", StyleScores = new double[] { 20.0, 19.5, 19.0, 18.5, 20.0 }, JumpDistance = 125.0 };
//             competitors[3] = new Competitor { LastName = "Галков", StyleScores = new double[] { 17.5, 17.0, 18.5, 19.0, 18.0 }, JumpDistance = 121.5 };
//             competitors[4] = new Competitor { LastName = "Добров", StyleScores = new double[] { 19.5, 20.0, 19.0, 18.5, 19.5 }, JumpDistance = 123.5 };

//             // общие результаты
//             for (int i = 0; i < NumJudges; i++)
//             {
//                 for (int j = 0; j < competitors.Length; j++)
//                 {
//                     // Сортируем оценки судей по возрастанию
//                     Array.Sort(competitors[j].StyleScores);

//                     // Отбрасываем наименьшую, наибольшую оценки и суммируем остальные
//                     double sum = 0;
//                     for (int k = 1; k < competitors[j].StyleScores.Length - 1; k++)
//                     {
//                         sum += competitors[j].StyleScores[k];
//                     }

//                     double distanceDifference = competitors[j].JumpDistance - BaseDistance;
//                     double distanceScore = distanceDifference > 0
//                         ? BaseScore + distanceDifference * ScorePerMeter // больше нуля
//                         : BaseScore + distanceDifference * PenaltyPerMeter; // меньше нуля

//                     competitors[j].TotalScore = sum + distanceScore;
//                 }
//             }

//             // сортировка по результатам
//             for (int i = 0; i < NumJudges - 1; i++)
//             {
//                 for (int j = i + 1; j < NumJudges; j++)
//                 {
//                     if (competitors[j].TotalScore > competitors[i].TotalScore)
//                     {
//                         var temp = competitors[i];
//                         competitors[i] = competitors[j];
//                         competitors[j] = temp;
//                     }
//                 }
//             }

//             Console.WriteLine("Результаты:");
//             for (int i = 0; i < competitors.Length; i++)
//             {
//                 Console.WriteLine($"{i + 1}. {competitors[i].LastName}: {competitors[i].TotalScore} очков");
//             }
//         }
//     }
// }
