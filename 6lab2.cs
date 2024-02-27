using System;
using System.Collections.Generic;

struct Diver
{
    private string _name;
    private List<Jump> _jumps;
    private double _totalScore;

    public Diver(string name)
    {
        _name = name;
        _jumps = new List<Jump>();
    }

    public string Name => _name;

    public void AddJump(Jump jump)
    {
        _jumps.Add(jump);
    }

    public double TotalScore
    {
        get
        {
            if (_totalScore == 0)
            {
                _totalScore = _jumps.Sum(jump => jump.GetScore());
            }
            return _totalScore;
        }
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

        Console.WriteLine("Results:");
        Console.WriteLine("---------------------");
        Console.WriteLine("| Place | Surname | Total |");
        Console.WriteLine("---------------------");
        foreach (Diver diver in divers)
        {
            Console.WriteLine(diver);
        }
        Console.WriteLine("---------------------");
    }
}
