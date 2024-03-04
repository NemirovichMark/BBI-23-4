using System;
using System.Collections.Generic;

abstract class Country
{
    public abstract string Name { get; }
    protected List<string> Answers { get; private set; }

    public Country()
    {
        Answers = new List<string>();
    }

    public void AddAnswer(string answer)
    {
        Answers.Add(answer);
    }

    public List<string> GetTopAnswers(int n)
    {
        Dictionary<string, int> answerCounts = new Dictionary<string, int>();

        foreach (string answer in Answers)
        {
            if (!answerCounts.ContainsKey(answer))
            {
                answerCounts[answer] = 1;
            }
            else
            {
                answerCounts[answer]++;
            }
        }

        var sortedAnswers = answerCounts.OrderByDescending(x => x.Value).Take(n);
        return sortedAnswers.Select(x => x.Key).ToList();
    }

    public double GetPercentage(string answer)
    {
        int count = Answers.Count;
        int answerCount = Answers.FindAll(x => x == answer).Count;
        return (double)answerCount / count * 100;
    }
}

class Russia : Country
{
    public override string Name => "Russia";
}

class Japan : Country
{
    public override string Name => "Japan";
}

class Program
{
    static void Main(string[] args)
    {
        Russia russia = new Russia();
        Japan japan = new Japan();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Enter answers for Question {i + 1}:");
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine($"Enter answer for {j == 0 ? "Russia" : "Japan"}:");
                string answer = Console.ReadLine();
                if (j == 0)
                    russia.AddAnswer(answer);
                else
                    japan.AddAnswer(answer);
            }
        }

        Console.WriteLine("Results:");
        Console.WriteLine("---------------------");

        Console.WriteLine("Russia:");
        PrintCountryResults(russia);

        Console.WriteLine("Japan:");
        PrintCountryResults(japan);

        Console.WriteLine("Both countries:");
        PrintCombinedResults(russia, japan);
    }

    static void PrintCountryResults(Country country)
    {
        List<string> topAnswers = country.GetTopAnswers(5);
        foreach (string answer in topAnswers)
        {
            double percentage = country.GetPercentage(answer);
            Console.WriteLine($"{answer}: {percentage:F2}%");
        }
        Console.WriteLine();
    }

    static void PrintCombinedResults(Russia russia, Japan japan)
    {
        var combinedAnswers = new HashSet<string>(russia.Answers);
        combinedAnswers.UnionWith(japan.Answers);

        foreach (string answer in combinedAnswers)
        {
            double russiaPercentage = russia.GetPercentage(answer);
            double japanPercentage = japan.GetPercentage(answer);
            double combinedPercentage = (russiaPercentage + japanPercentage) / 2;

            Console.WriteLine($"{answer}: Russia - {russiaPercentage:F2}%, Japan - {japanPercentage:F2}%, Combined - {combinedPercentage:F2}%");
        }
        Console.WriteLine();
    }
}

