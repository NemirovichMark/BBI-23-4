using System;

struct Program
{
    struct Participant
    {
        private string Name;
        private double?[] Jumps;
        private double BestJump; // приватное поле для хранения лучшего прыжка

        public Participant(string name, double?[] jumps)
        {
            Name = name;
            Jumps = jumps;
            BestJump = CalculateBestJump(); // вызов метода для рассчета лучшего прыжка 
        }

        private double CalculateBestJump()
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

        public double GetBestJump()
        {
            return BestJump;
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
                if (double.TryParse(input, out double result)) //преобразование в double
                {
                    jumps[j] = result;
                }
            }

            participants[i] = new Participant(name ?? "Unknown", jumps); // "Unknown", если имя участника не было введено
        }

        GnomeSort(participants, numParticipants); 

        // Выводим результаты
        Console.WriteLine("\nРезультаты соревнований по прыжкам в высоту (в порядке занятых мест):");
        for (int i = 0; i < numParticipants; i++)
        {
            Console.WriteLine($"{i + 1}. {participants[i].GetName()} - {participants[i].GetBestJump()}");
        }
    }

    static void GnomeSort(Participant[] array, int length)
    {
        int pos = 0;
        int pos_next = 1;
        while (pos < length - 1)
        {
            if (array[pos].GetBestJump() < array[pos + 1].GetBestJump())
            {
                Swap(ref array[pos], ref array[pos + 1]);
                if (pos > 0)
                    pos--;
            }
            else
            {
                pos = pos_next;
                pos_next ++;
            }
        }
    }

    static void Swap(ref Participant a, ref Participant b) //изменение мест самих участников, не значений
    {
        var temp = a;
        a = b;
        b = temp;
    }
}
