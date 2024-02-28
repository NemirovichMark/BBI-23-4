class FootballTeam
{
    private string name;
    private int Scored;
    private int Failed;
    private int points;

    public FootballTeam(string name)
    {
        this.name = name;
    }

    public string Name { get { return name; } set { name = value; } }

    public void Result(int scored, int conceded)
    {
        Scored += scored;
        Failed += conceded;
        if (scored > conceded)
            points += 3;
        else if (scored == conceded)
            points += 1;
    }

    public int Points { get { return points; } }
    public int Difference { get { return Scored - Failed; } }

    public static void print (FootballTeam[] teams)
    {
        Console.WriteLine("Place | Team   | Points");
        for (int i = 0; i < teams.Length; i++)
        {
            Console.WriteLine("{0,5} | {1,-6} | {2}", i + 1, teams[i].Name, teams[i].Points);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FootballTeam[] teams = new FootballTeam[]
        {
            new FootballTeam("team1"),
            new FootballTeam("team2"),
            new FootballTeam("team3")
        };

        Match(teams[0], teams[1]);
        Match(teams[0], teams[2]);
        Match(teams[1], teams[0]);
        Match(teams[1], teams[2]);
        Sort(teams);

        FootballTeam.print(teams);
    }

    static void Match(FootballTeam team1, FootballTeam team2)
    {
        Random random = new Random();
        int scored = random.Next(0, 5);
        int conceded = random.Next(0, 5);

        team1.Result(scored, conceded);
        team2.Result(conceded, scored);
    }

    static void Sort(FootballTeam[] teams)
    {
        int n = teams.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (teams[j].Points < teams[j + 1].Points ||
                    (teams[j].Points == teams[j + 1].Points && teams[j].Difference < teams[j + 1].Difference))
                {
                    FootballTeam temp = teams[j];
                    teams[j] = teams[j + 1];
                    teams[j + 1] = temp;
                }
            }
        }
    }
}
