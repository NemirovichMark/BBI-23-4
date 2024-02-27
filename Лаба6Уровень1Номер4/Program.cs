using System;

public struct People
{
    public string Name;
    public double FirstA;
    public double SecondA;

    public double GetBestResult()
    {
        return Math.Max(FirstA, SecondA);
    }
}

class Program
{
    static void Main(string[] args)
    {

        People[] Players = new People[3];


        for (int i = 0; i < Players.Length; i++)
        {
            Console.WriteLine($"Введите имя участника {i + 1}:");
            string name = Console.ReadLine();

            Console.WriteLine($"Введите результат первой попытки участника {name}:");
            double firstA = double.Parse(Console.ReadLine());

            Console.WriteLine($"Введите результат второй попытки участника {name}:");
            double secondA = double.Parse(Console.ReadLine());

            Players[i] = new People { Name = name, FirstA = firstA, SecondA = secondA };
        }


        for (int i = 0; i < Players.Length - 1; i++)
        {
            for (int j = i + 1; j < Players.Length; j++)
            {
                if (Players[j].GetBestResult() > Players[i].GetBestResult())
                {

                    People temp = Players[i];
                    Players[i] = Players[j];
                    Players[j] = temp;
                }
            }
        }


        Console.WriteLine("Результаты соревнований:");
        for (int i = 0; i < Players.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Players[i].Name}: {Players[i].GetBestResult()} м");
        }
    }
}
