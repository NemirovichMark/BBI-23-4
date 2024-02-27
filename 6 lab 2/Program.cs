using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lab_2
{
    struct Participant
    {
        private string _surn;
        private double _rez;
        public Participant(string surn, double rez)
        {
            _surn = surn;
            _rez = rez;
        }
        public string name
        {
            get => _surn;
            private set => _surn = value;
        }
        public double rez
        {
            get => _rez;
            private set => _rez = value;
        }
        public void Print() => Console.WriteLine("Фамилия:{0, 10} Результат:{1,10}", name, rez);

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество участников:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите колчество сыгранных партий:");
            int ngames = int.Parse(Console.ReadLine());
            Participant[] partis = new Participant[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите фамилию {i + 1} участника:");
                string name = Console.ReadLine();
                double z = 0;
                for (int j = 0; j < ngames; j++)
                {
                    Console.WriteLine($"Введите результат {j + 1} игры {i + 1} участника:");
                    double a = double.Parse(Console.ReadLine());
                    z += a;
                }
                partis[i] = new Participant(name, z);
            }
            Sort(partis);
            for (int i = 0; i < n; i++)
            {
                partis[i].Print();
            }
        }
        static void Sort(Participant[] partis)
        {
            for (int i = 0; i < partis.Length; i++)
            {
                for (int j = 0; j < partis.Length - 1 - i; j++)
                {
                    if (partis[j].rez < partis[j + 1].rez)
                    {
                        Participant temp = partis[j];
                        partis[j] = partis[j + 1];
                        partis[j + 1] = temp;
                    }
                }
            }
        }
    }
}
