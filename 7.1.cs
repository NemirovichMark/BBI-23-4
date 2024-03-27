// using System;

// class Program
// {
//     class Participant
//     {
//         public string Name { get; private set; }
//         public double?[] Jumps { get; private set; }
//         public double BestJump { get; private set; }
//         public bool Disqualified { get; private set; }

//         public Participant(string name, double?[] jumps)
//         {
//             Name = name;
//             Jumps = jumps;
//             BestJump = CalculateBestJump();
//             Disqualified = false;
//         }

//         private double CalculateBestJump()
//         {
//             double bestJump = 0;
//             foreach (var jump in Jumps)
//             {
//                 if (jump.HasValue && jump.Value > bestJump)
//                 {
//                     bestJump = jump.Value;
//                 }
//             }
//             return bestJump;
//         }

//         public void Disqualify()
//         {
//             Disqualified = true;
//         }
//     }

//     static void Main(string[] args)
//     {
//         int numParticipants = 5;
        
//         Participant[] participants = new Participant[numParticipants];

//         for (int i = 0; i < numParticipants; i++)
//         {
//             Console.WriteLine($"Введите имя участника {i + 1}:");
//             var name = Console.ReadLine();

//             double?[] jumps = new double?[2];
//             for (int j = 0; j < 2; j++)
//             {
//                 Console.WriteLine($"Введите результат {j + 1}-й попытки:");
//                 string input = Console.ReadLine();
//                 if (double.TryParse(input, out double result))
//                 {
//                     jumps[j] = result;
//                 }
//             }

//             participants[i] = new Participant(name ?? "Unknown", jumps);
//         }

//         GnomeSort(participants, numParticipants); 

//         //participants[1].Disqualify(); //дисквалификация

//         Console.WriteLine("\nРезультаты соревнований по прыжкам в высоту (в порядке занятых мест):");
//         int place = 1;
//         for (int i = 0; i < numParticipants; i++)
//         {
//             if (!participants[i].Disqualified)
//             {
//                 Console.WriteLine($"{place}. {participants[i].Name} - {participants[i].BestJump}");
//                 place++;
//             }
//         }
//     }

//     static void GnomeSort(Participant[] array, int length)
//     {
//         int pos = 0;
//         int pos_next = 1;
//         while (pos < length - 1)
//         {
//             if (array[pos].BestJump < array[pos + 1].BestJump)
//             {
//                 Swap(ref array[pos], ref array[pos + 1]);
//                 if (pos > 0)
//                     pos--;
//             }
//             else
//             {
//                 pos = pos_next;
//                 pos_next++;
//             }
//         }
//     }

//     static void Swap(ref Participant a, ref Participant b)
//     {
//         var temp = a;
//         a = b;
//         b = temp;
//     }
// }
