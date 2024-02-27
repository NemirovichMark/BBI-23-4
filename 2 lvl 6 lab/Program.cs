using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lvl_6_lab
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
            set => _surn = value;
        }
        public double rez
        {
            get => _rez;
            set => _rez = value;
        }

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
                partis[i].name = Console.ReadLine();
                partis[i].rez = 0;
                for (int j = 0; j < ngames; j++)
                {
                    Console.WriteLine($"Введите результат {j + 1} игры {i + 1} участника:");
                    double a = double.Parse(Console.ReadLine());
                    partis[i].rez += a;
                }
            }
            Sort(partis);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Фамилия:{0, 10} Результат:{1,10}", partis[i].name, partis[i].rez);
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
