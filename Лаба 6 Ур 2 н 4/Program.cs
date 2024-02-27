
using System;

class Program
{
    static void Main(string[] args)
    {
        string[] group1Names = { "Иванов", "Петров", "Сидоров" };
        string[] group1Times = { "1:10:15", "1:12:30", "1:09:45" };

        string[] group2Names = { "Ильин", "Жуков", "Поморцев" };
        string[] group2Times = { "1:08:20", "1:11:05", "1:10:50" };


        int totalParticipants = group1Names.Length + group2Names.Length;
        string[] combinedNames = new string[totalParticipants];
        string[] combinedTimes = new string[totalParticipants];


        for (int i = 0; i < group1Names.Length; i++)
        {
            combinedNames[i] = group1Names[i];
            combinedTimes[i] = group1Times[i];
        }


        for (int i = 0; i < group2Names.Length; i++)
        {
            combinedNames[group1Names.Length + i] = group2Names[i];
            combinedTimes[group1Names.Length + i] = group2Times[i];
        }

        for (int i = 0; i < combinedTimes.Length - 1; i++)
        {
            for (int j = i + 1; j < combinedTimes.Length; j++)
            {
                TimeSpan time1 = TimeSpan.Parse(combinedTimes[i]);
                TimeSpan time2 = TimeSpan.Parse(combinedTimes[j]);

                if (time1 > time2)
                {
                    string tempName = combinedNames[i];
                    combinedNames[i] = combinedNames[j];
                    combinedNames[j] = tempName;

                    string tempTime = combinedTimes[i];
                    combinedTimes[i] = combinedTimes[j];
                    combinedTimes[j] = tempTime;
                }
            }
        }

        Console.WriteLine("Результаты гонок:");
        Console.WriteLine("{0, -10} {1, -15} {2}", "Место", "Фамилия", "Время");
        for (int i = 0; i < combinedNames.Length; i++)
        {
            Console.WriteLine("{0, -10} {1, -15} {2}", i + 1, combinedNames[i], combinedTimes[i]);
        }
    }
}
