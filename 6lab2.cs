class Diver
{

    public string Name { get; set; }


    public List<Jump> Jumps { get; set; }

    public double TotalScore { get; set; }

    public Diver(string name)
    {
        Name = name;
        Jumps = new List<Jump>();
    }

    public void AddJump(Jump jump)
    {
        Jumps.Add(jump);
    }

    public void CalculateTotalScore()
    {
        TotalScore = 0;
        for (int i = 0; i < Jumps.Count; i++)
        {
            TotalScore += Jumps[i].GetScore();
        }
    }
}

class Jump
{
    public double Difficulty { get; set; }

    public List<double> Scores { get; set; }

    public Jump(double difficulty)
    {
        Difficulty = difficulty;
        Scores = new List<double>();
    }

    public void AddScore(double score)
    {
        Scores.Add(score);
    }

    public double GetScore()
    {
        Scores.Sort();

        double sum = 0;
        for (int i = 1; i < Scores.Count - 1; i++)
        {
            sum += Scores[i];
        }

        return sum * Difficulty;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Количество прыгунов:");
        int n = int.Parse(Console.ReadLine());

        List<Diver> divers = new List<Diver>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Фамилия");
            string name = Console.ReadLine();

            Diver diver = new Diver(name);

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("Коэффицент");

                double difficulty = double.Parse(Console.ReadLine());

                Jump jump = new Jump(difficulty);

\                for (int k = 0; k < 7; k++)
                {
                    Console.WriteLine("7 оценок по отдельности");

                    double score = double.Parse(Console.ReadLine());

                    jump.AddScore(score);
                }


                diver.AddJump(jump);
            }

            divers.Add(diver);
        }

        foreach (Diver diver in divers)
        {
            diver.CalculateTotalScore();
        }

        divers.Sort((a, b) => b.TotalScore.CompareTo(a.TotalScore));

        Console.WriteLine("Итоговая таблица");
        Console.WriteLine("---------------------");
        Console.WriteLine("| Место | Фамилия | Итоговая оценка |");
        Console.WriteLine("---------------------");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("| {0} | {1} | {2} |", i + 1, divers[i].Name, divers[i].TotalScore);
        }
        Console.WriteLine("---------------------");
    }
}



