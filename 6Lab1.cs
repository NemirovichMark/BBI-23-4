using System;
using System.Collections.Generic;

class Jumper
{
    public string Surname { get; set; }
    public string Team { get; set; }
    public int Try1 { get; set; }
    public int Try2 { get; set; }
    public int Summa { get; set; }

    public Jumper(string surname, string team, int try1, int try2)
    {
        Surname = surname;
        Team = team;
        Try1 = try1;
        Try2 = try2;
        Summa = try1 + try2;
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

        jumpers.Sort((a, b) => b.Summa.CompareTo(a.Summa));

        Console.WriteLine("Протокол соревнований по прыжкам в длину");
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("| Место | Фамилия | Общество | Попытка 1 | Попытка 2 | Сумма |");
        Console.WriteLine("-----------------------------------------");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} |",
                              i + 1, jumpers[i].Surname, jumpers[i].Team,
                              jumpers[i].Try1, jumpers[i].Try2, jumpers[i].Summa);
        }
        Console.WriteLine("-----------------------------------------");
    }
}
