// Задача 2.9
// Результаты соревнований фигуристов по одному из видов многоборья
// представлены оценками семи судей в баллах (от 0,0 до 6,0). По результатам оценок
// судьи определяется место каждого участника у этого судьи. Места участников
// определяются далее по сумме мест, которые каждый участник занял у всех судей.
// Составить программу, определяющую по исходной таблице оценок фамилии и
// сумму мест участников в порядке занятых ими мест.

class Program
{
    struct Participant
    {
        private string name;
        public double[] scores {get; private set;}
        private int[] JudgesPlaces;
        public int TotalScore {get; private set;}
        public Participant(string _name, double[] _scores)
        {
            name = _name;
            scores = _scores;
            JudgesPlaces = new int[7];
        }
        public void Print()
        {
            Console.Write(name + " занял следующие места у судей: ");
            foreach (int place in JudgesPlaces) Console.Write(place + " ");
            Console.WriteLine(TotalScore);
        }
        public void NewPlace(int _place, int i)
        {
            if (i < JudgesPlaces.Length)
            {
                JudgesPlaces[i] = _place;
                TotalScore += _place;
            }
        }
        public void Final(int i)
        {
            Console.WriteLine(name + " занял " + i + " место с суммой мест " + TotalScore);
        }
    }

    static void Sort(Participant[] a, int index)
    {
        for(int i=1; i < a.Length; i++)
            {
                Participant k = a[i];
                int j = i - 1;

                while(j>=0 && a[j].scores[index] < k.scores[index])
                {
                    a[j + 1] = a[j];
                    a[j] = k;
                    j--;
                }
            }
    }


    static void ShellSort(Participant[] array, int index)
        {
            //расстояние между элементами, которые сравниваются
            int d = array.Length / 2;
            while (d >= 1)
            {
                for (int i=d; i < array.Length; i++)
                {
                    Participant k = array[i];
                    int j = i - d;

                    while(j>=0 && array[j].scores[index] < k.scores[index])
                    {
                        array[j + d] = array[j];
                        j -= d;
                    }
                array[j + d] = k;
                }
                d = d / 2;
            }
        }

    
    static void Main()
    {
        Participant[] participants =
        {
            new Participant("Валентин", [1, 1.5, 4, 2, 6, 5.8, 1.3]),
            new Participant("Артём", [3, 3.2, 5.5, 1.2, 3.5, 1, 5]),
            new Participant("Олег", [5, 5.4, 6, 5.3, 2.4, 5, 3]),
            new Participant("Игорь", [1.1, 2, 4.1, 3, 5.5, 4, 4.7]),
            new Participant("Ольга", [4, 4.5, 5, 3.4, 2, 5.3, 3,9])
        };
        
        for (int i = 0; i < 7; i++)
        {
            ShellSort(participants, i);
            for (int j = 0; j < participants.Length; j++)
            {
                participants[j].NewPlace(j + 1, i);
            }
        }

        for(int i=1; i < participants.Length; i++)
            {
                Participant k = participants[i];
                int j = i - 1;

                while(j>=0 && participants[j].TotalScore > k.TotalScore)
                {
                    participants[j + 1] = participants[j];
                    participants[j] = k;
                    j--;
                }
            }

        for (int i = 0; i < participants.Length; i++)
        {
            participants[i].Final(i + 1);
        }

    }
}