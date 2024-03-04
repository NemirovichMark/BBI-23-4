using System;
using System.Collections.Generic;
using System.Linq;

abstract class Diving
{
    public abstract string DisciplineName { get; }
    protected List<double> JudgeScores { get; private set; }

    public Diving()
    {
        JudgeScores = new List<double>();
    }

    public void AddJudgeScore(double score)
    {
        JudgeScores.Add(score);
    }

    public double CalculateTotalScore(double difficultyCoefficient)
    {
        JudgeScores.Sort();
        JudgeScores.RemoveAt(0);
        JudgeScores.RemoveAt(JudgeScores.Count - 1);
        double sum = JudgeScores.Sum();
        return sum * difficultyCoefficient;
    }
}

class Diving3m : Diving
{
    public override string DisciplineName => "Diving from 3m";

    public Diving3m() : base()
    {
    }
}

class Diving5m : Diving
{
    public override string DisciplineName => "Diving from 5m";

    public Diving5m() : base()
    {
    }
}

class Diver
{
    private string _name;
    private List<Diving> _dives;

    public Diver(string name)
    {
        _name = name;
        _dives = new List<Diving>();
    }

    public string Name => _name;

    public void AddDive(Diving dive)
    {
        _dives.Add(dive);
    }

    public double TotalScore
    {
        get
        {
            double total = 0;
            foreach (var dive in _dives)
            {
                total += dive.CalculateTotalScore(GetDifficultyCoefficient(dive));
            }
            return total;
        }
    }

    private double GetDifficultyCoefficient(Diving dive)
    {

        return dive is Diving3m ? 2.5 : 3.5;
    }

    public override string ToString()
    {
        return $"| {_name} | {TotalScore:F2} |";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Diver> divers = new List<Diver>();

        // Example 
        Diver diver1 = new Diver("John");
        diver1.AddDive(new Diving3m());
        diver1.AddDive(new Diving3m());
        diver1.AddDive(new Diving5m());
        diver1.AddDive(new Diving5m());

        Diver diver2 = new Diver("Alice");
        diver2.AddDive(new Diving5m());
        diver2.AddDive(new Diving5m());
        diver2.AddDive(new Diving3m());
        diver2.AddDive(new Diving3m());

        divers.Add(diver1);
        divers.Add(diver2);

        Console.WriteLine("Results:");
        Console.WriteLine("---------------------");

        foreach (Diver diver in divers)
        {
            Console.WriteLine($"{diver.Name}'s dives:");
            Console.WriteLine(diver.TotalScore);
            Console.WriteLine("---------------------");
        }
    }
}
