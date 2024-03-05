class Program
{
    struct Participant
    {
        private string Name;
        private double?[] Jumps;

        public Participant(string name, double?[] jumps)
        {
            Name = name;
            Jumps = jumps;
        }

        // определение лучшего прыжка каждого участника
        public double GetBestJump()
        {
            double bestJump = 0;
            foreach (var jump in Jumps)
            {
                if (jump.HasValue && jump.Value > bestJump) // проверка и возвращение значения если не null
                {
                    bestJump = jump.Value;
                }
            }
            return bestJump;
        }

        public string GetName()
        {
            return Name;
        }
    }

    static void Main(string[] args)
    {
        int numParticipants = 4;
        
        Participant[] participants = new Participant[numParticipants];//массив структур Participant

        for (int i = 0; i < numParticipants; i++)
        {
            Console.WriteLine($"Введите имя участника {i + 1}:");
            var name = Console.ReadLine();

            double?[] jumps = new double?[2];
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine($"Введите результат {j + 1}-й попытки для участника {name}:");
                string input = Console.ReadLine();
                if (double.TryParse(input, out double result))//преобразование в double
                {
                    jumps[j] = result;
                }
            }

            participants[i] = new Participant(name ?? "Unknown", jumps); // "Unknown", если имя участника не было введено
        }

        //лучший результат
        for (int i = 0; i < numParticipants - 1; i++)
        {
            for (int j = 0; j < numParticipants - 1 - i; j++)
            {
                if (participants[j].GetBestJump() < participants[j + 1].GetBestJump())
                {
                    // Обмен значениями
                    var temp = participants[j];
                    participants[j] = participants[j + 1];
                    participants[j + 1] = temp;
                }
            }
        }

        // Выводим результаты
        Console.WriteLine("\nРезультаты соревнований по прыжкам в высоту (в порядке занятых мест):");
        for (int i = 0; i < numParticipants; i++)
        {
            Console.WriteLine($"{i + 1}. {participants[i].GetName()} - {participants[i].GetBestJump()}");
        }
    }
}