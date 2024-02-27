using System;
using System.Collections.Generic;

struct Jumper
{
    private string _surname;
    private string _team;
    private int _try1;
    private int _try2;
    private int _summa;

    public Jumper(string surname, string team, int try1, int try2)
    {
        _surname = surname;
        _team = team;
        _try1 = try1;
        _try2 = try2;
        _summa = try1 + try2;
    }

    public string Surname => _surname;
    public string Team => _team;
    public int Try1 => _try1;
    public int Try2 => _try2;
    public int Summa => _summa;

    public override string ToString()
    {
        return $"| {_surname} | {_team} | {_try1} | {_try2} | {_summa} |";
    }
}


static void Main(string[] args)
{
    List<Jumper> jumpers = new List<Jumper>();
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i < n; i++)
    {
        string[] input = Console.ReadLine().Split(' ');
        string surname = input[0];
        string team = input[1];
        int try1 = int.Parse(input[2]);
        int try2 = int.Parse(input[3]);
        jumpers.Add(new Jumper(surname, team, try1, try2));
    }

    jumpers.Sort((a, b) => b.Summa.CompareTo(a.Summa));

    Console.WriteLine("Results");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("| Surname | Team | Try 1 | Try 2 | Total |");
    Console.WriteLine("-----------------------------------------");
    foreach (Jumper jumper in jumpers)
    {
        Console.WriteLine(jumper);
    }
    Console.WriteLine("-----------------------------------------");
}

