using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР6_3_3
{
    struct Potok
    {
        private string _group, _potok;
        private int _russian, _matanalys, _angem, _phisics, _programm;
        public Potok(string group, string potok, int russian, int matanalys, int angem, int phisics, int programm)
        {
            _group = group;
            _potok = potok;
            _russian = russian;
            _matanalys = matanalys;
            _angem = angem;
            _phisics = phisics;
            _programm = programm;
        }
        public string group { get { return _group; } }
        public string potok { get { return _potok; } }

        public int russian { get { return _russian; } }

        public int matanalys { get { return _matanalys; } }

        public int angem { get { return _angem; } }

        public int phisics { get { return _phisics; } }

        public int programm { get { return _programm; } }

        public void sredn_rezult(Potok groupi, ref double sredn)
        {
            double summ = 0, n = 5;
            summ = groupi.russian + groupi.matanalys + groupi.angem + groupi.phisics + groupi._programm;
            sredn = summ / n;
        }
        public void Print(Potok groupi, double sredn)
        {
            Console.WriteLine("Поток {0, 10} Группа {1, 10} Среднее значение {2, 10}", potok, group, sredn);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Potok[] groupi = new Potok[5];
            groupi[0] = new Potok("1", "numb1", 5, 2, 5, 4, 3);
            groupi[1] = new Potok("2", "numb2", 4, 3, 3, 5, 3);
            groupi[2] = new Potok("4", "numb1", 3, 2, 1, 4, 3);
            groupi[3] = new Potok("1", "numb1", 5, 4, 5, 3, 3);
            groupi[4] = new Potok("3", "numb4", 5, 3, 5, 4, 4);
            Potok[] groupinumb1 = new Potok[3];
            double[] sredn = new double[3];
            int k = 0;
            double sred = 0;
            for (int i = 0; i < groupi.Length; i++)
            {
                string numb1 = "numb1";
                if (groupi[i].potok.Equals("numb1"))
                {
                    groupinumb1[k] = groupi[i];
                    groupi[i].sredn_rezult(groupi[i], ref sred);
                    sredn[k] = sred; k++;

                }
            }
            sort(groupinumb1, sredn);
            for (int i = 0; i < groupinumb1.Length; i++)
            {
                groupinumb1[i].Print(groupinumb1[i], sredn[i]);
            }
        }
        static void sort(Potok[] groupi, double[] sred)
        {
            for (int i = 0; i < groupi.Length; i++)
            {
                for (int j = 0; j < groupi.Length - 1 - i; j++)
                {
                    if (sred[j] < sred[j + 1])
                    {
                        double temp = sred[j];
                        sred[j] = sred[j + 1];
                        sred[j + 1] = temp;
                        Potok h = groupi[j];
                        groupi[j] = groupi[j + 1];
                        groupi[j + 1] = h;
                    }
                }
            }
        }
    }
}
