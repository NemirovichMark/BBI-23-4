using System;
using System.Collections.Generic;

class Jumper
{
    public string Surname { get; private set; }
    public string Team { get; private set; }
    public int Try1 { get; private set; }
    public int Try2 { get; private set; }
    public int Summa { get; private set; }
    public bool Disqualified { get; private set; }

    public Jumper(string surname, string team, int try1, int try2)
    {
        Surname = surname;
        Team = team;
        Try1 = try1;
        Try2 = try2;
        Summa = try1 + try2;
        Disqualified = false;
    }

    public void Disqualify()
    {
        Disqualified = true;
    }

    public override string ToString()
    {
        return $"| {Surname} | {Team} | {Try1} | {Try2} | {Summa} |";
    }
}

class Program
{
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

        // Custom sorting function from previous task
        static void GSort(List<Jumper> jumpers)
        {
            int i = 0;
            while (i < jumpers.Count)
            {
                if (i == 0 || jumpers[i].Summa >= jumpers[i - 1].Summa)
                {
                    i++;
                }
                else
                {
                    Jumper temp = jumpers[i];
                    jumpers[i] = jumpers[i - 1];
                    jumpers[i - 1] = temp;
                    i--;
                }
            }
        }

        GSort(jumpers);

        Console.WriteLine("Results");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("| Surname | Team | Try 1 | Try 2 | Total |");
        Console.WriteLine("-----------------------------------------");
        foreach (Jumper jumper in jumpers)
        {
            if (!jumper.Disqualified)
                Console.WriteLine(jumper);
        }
        Console.WriteLine("-----------------------------------------");
    }
}
