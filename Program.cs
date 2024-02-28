// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

public struct Result
{
    private string surname;
    private double[] results;

    public Result(string surname, double[] results)
    {
        this.surname = surname;
        this.results = results;
    }

    public double BestResult()
    {
        double bestResult = results[0];
        for (int i = 1; i < results.Length; i++)
        {
            if (results[i] > bestResult)
            {
                bestResult = results[i];
            }
        }
        return bestResult;
    }
    public void print(Result[] jumpResults)
    {
        Console.WriteLine($"Surname: {this.surname}");
        double bestResult = results[0];
        for (int i = 1; i < results.Length; i++)
        {
            if (results[i] > bestResult)
            {
                bestResult = results[i];
            }
        }
        Console.WriteLine($"{"Best result:"} {bestResult}");
    }
}

public class Program
{
    public static void Main()
    {
        Result[] jumpResults = new Result[3];
        jumpResults[0] = new Result("Ivanov", new double[] { 5.6, 5.9, 6.1 });
        jumpResults[1] = new Result("Petrov", new double[] { 5.8, 6.0, 6.2 });
        jumpResults[2] = new Result("Sidorov", new double[] { 5.7, 6.0, 6.3 });

        Console.WriteLine("Table of resuls:");

        for (int i = 0; i < jumpResults.Length; i++)
        {
            jumpResults[i].print(jumpResults);
        }
        
    }
}
