// See https://aka.ms/new-console-template for more information

// 1

//    public struct Participant
//    {
//        private string surname;
//        private int group;
//        private string teachersurname;
//        private double result;

//        public Participant(string _surname, int _group, string _teachersurname, double _result)
//        {
//            surname = _surname;
//            group = _group;
//            teachersurname = _teachersurname;
//            result = _result;
//        }

//        public string Surname { get { return surname; } }
//        public int Group { get { return group; } }
//        public string TeacherSurname { get { return teachersurname; } }
//        public double Result { get { return result; } }

//        private static int k = 0;

//        public void Print()
//        {
//            Console.WriteLine("Surname {0} \t Group {1} \t Teacher's Surname {2} \t Result {3:f1}", Surname, Group, TeacherSurname, Result);
//            if (Result <= 2) k++;
//            Console.WriteLine($"{k} women passed the normative");
//        }
//    }
//public class Program
//{
//    public static void Main(string[] args)
//    {
//        Participant[] person = new Participant[]
//        {
//            new Participant("Ivanova", 1, "Ivanov", 2),
//            new Participant("Petrova", 2, "Petrov", 3),
//            new Participant("Sidorova", 3, "Sidorov", 1)
//        };

//        Sort(person);

//        for (int i = 0; i < person.Length; i++)
//        {
//            person[i].Print();
//        }
//    }

//    public static void Sort(Participant[] arr)
//    {
//        for (int i = 1; i < arr.Length; i++)
//        {
//            Participant key = arr[i];
//            int j = i - 1;

//            while (j >= 0 && arr[j].Result > key.Result)
//            {
//                arr[j + 1] = arr[j];
//                j = j - 1;
//            }

//            arr[j + 1] = key;
//        }
//    }
//}


// 2

//public struct Result
//{
//    private string surname;
//    private double[] results;

//    public Result(string surname, double[] results)
//    {
//        this.surname = surname;
//        this.results = results;
//    }

//    public double BestResult()
//    {
//        double bestResult = results[0];
//        for (int i = 1; i < results.Length; i++)
//        {
//            if (results[i] > bestResult)
//            {
//                bestResult = results[i];
//            }
//        }
//        return bestResult;
//    }
//    public void print()
//    {
//        Console.WriteLine($"Surname: {this.surname}");
//        double bestResult = results[0];
//        for (int i = 1; i < results.Length; i++)
//        {
//            if (results[i] > bestResult)
//            {
//                bestResult = results[i];
//            }
//        }
//        Console.WriteLine($"{"Best result:"} {bestResult}");
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Result[] jumpResults = new Result[3];
//        jumpResults[0] = new Result("Ivanov", new double[] { 5.6, 5.9, 6.1 });
//        jumpResults[1] = new Result("Petrov", new double[] { 5.8, 6.0, 6.2 });
//        jumpResults[2] = new Result("Sidorov", new double[] { 5.7, 6.0, 6.3 });

//        Console.WriteLine("Table of resuls:");

//        for (int i = 0; i < jumpResults.Length; i++)
//        {
//            jumpResults[i].print();
//        }

//    }
//}


// 3

struct FootballTeam
{
    private string name;
    private int Scored;
    private int Failed;
    private int points;

    public FootballTeam(string name)
    {
        this.name = name;
        Scored = 0;
        Failed = 0;
        points = 0;
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

    public static void Print( FootballTeam[] teams)
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

        Match(ref teams[0], ref teams[1]);
        Match(ref teams[0], ref teams[2]);
        Match(ref teams[1], ref teams[0]);
        Match(ref teams[1], ref teams[2]);

        Sort(teams);
        FootballTeam.Print(teams);
    }

    static void Match(ref FootballTeam team1, ref FootballTeam team2)
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



