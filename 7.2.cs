// using System;

// public class Competitor
// {
//     private string lastName;
//     private double[] styleScores;
//     private double jumpDistance;
//     private double totalScore;

//     // Конструктор класса
//     public Competitor(string lastName, double[] styleScores, double jumpDistance)
//     {
//         this.lastName = lastName;
//         this.styleScores = styleScores;
//         this.jumpDistance = jumpDistance;
//         this.totalScore = 0;
//         CalculateTotalScore();
//     }

//     // расчет общего балла участника
//     private void CalculateTotalScore()
//     {
//         const int NumJudges = 5;
//         const double BaseDistance = 120.0;
//         const double BaseScore = 60.0;
//         const double ScorePerMeter = 2.0; // за каждый метр превышения
//         const double PenaltyPerMeter = -2.0; // за каждый метр уменьшения

//         for (int i = 0; i < NumJudges; i++)
//         {
//             BubbleSort(styleScores);

//             double sum = 0;
//             for (int k = 1; k < styleScores.Length - 1; k++)
//             {
//                 sum += styleScores[k];
//             }

//             double distanceDifference = jumpDistance - BaseDistance;
//             double distanceScore = distanceDifference > 0
//                 ? BaseScore + distanceDifference * ScorePerMeter
//                 : BaseScore + distanceDifference * PenaltyPerMeter;

//             totalScore = sum + distanceScore;
//         }
//     }

//     private void BubbleSort(double[] mas)
//     {
//         for (int i = 0; i < mas.Length - 1; i++)
//         {
//             for (int j = 0; j < mas.Length - i - 1; j++)
//             {
//                 if (mas[j] > mas[j + 1])
//                 {
//                     double temp = mas[j];
//                     mas[j] = mas[j + 1];
//                     mas[j + 1] = temp;
//                 }
//             }
//         }
//     }

//     public string GetLastName()
//     {
//         return this.lastName;
//     }

//     public double GetTotalScore()
//     {
//         return this.totalScore;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Competitor[] competitors = new Competitor[5];
//         competitors[0] = new Competitor("Семенов", new double[] { 18.5, 17.5, 19.0, 20.0, 18.0 }, 122.0);
//         competitors[1] = new Competitor("Иванов", new double[] { 19.0, 18.0, 17.0, 16.5, 18.5 }, 118.0);
//         competitors[2] = new Competitor("Смирнов", new double[] { 20.0, 19.5, 19.0, 18.5, 20.0 }, 125.0);
//         competitors[3] = new Competitor("Галков", new double[] { 17.5, 17.0, 18.5, 19.0, 18.0 }, 121.5);
//         competitors[4] = new Competitor("Добров", new double[] { 19.5, 20.0, 19.0, 18.5, 19.5 }, 123.5);

//         // сортировка участников по общему баллу
//         for (int i = 0; i < competitors.Length - 1; i++)
//         {
//             for (int j = i + 1; j < competitors.Length; j++)
//             {
//                 if (competitors[j].GetTotalScore() > competitors[i].GetTotalScore())
//                 {
//                     var temp = competitors[i];
//                     competitors[i] = competitors[j];
//                     competitors[j] = temp;
//                 }
//             }
//         }

//         Console.WriteLine("Результаты:");
//         for (int i = 0; i < competitors.Length; i++)
//         {
//             Console.WriteLine($"{i + 1}. {competitors[i].GetLastName()}: {competitors[i].GetTotalScore()} очков");
//         }
//     }
// }
