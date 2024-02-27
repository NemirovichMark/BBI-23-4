using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_lv_6_lab
{

    struct Group
    {
        private string _group, _potok;
        private int _matem, _physics, _prog, _analis, _system;
        public Group(string group, string potok, int matem, int physics, int prog, int analis, int system)
        {
            _group = group;
            _potok = potok;
            _matem = matem;
            _physics = physics;
            _prog = prog;
            _analis = analis;
            _system = system;
        }
        public string group { get => _group; set => _group = value; }
        public string potok { get => _potok; set => _potok = value; }
        public int matem { get => _matem; set => _matem = value; }
        public int physics { get => _physics; set => _physics = value; }
        public int prog { get => _prog; set => _prog = value; }
        public int analis { get => _analis; set => _analis = value; }
        public int system { get => _system; set => _system = value; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] grops = new Group[5];
            grops[0] = new Group("3", "BBI", 5, 3, 3, 2, 5);
            grops[1] = new Group("1", "IVT", 5, 5, 3, 4, 2);
            grops[2] = new Group("4", "BBI", 5, 4, 4, 5, 5);
            grops[3] = new Group("1", "PM", 2, 4, 3, 4, 5);
            grops[4] = new Group("2", "BBI", 2, 5, 2, 5, 3);
            Group[] gropsBBI = new Group[3];
            double[] sred = new double[3];
            int k = 0;//number of element in sred
            double sr = 0;
            for (int i = 0; i < grops.Length; i++)
            {
                string BBI = "BBI";
                if (grops[i].potok.Equals(BBI))
                {
                    gropsBBI[k] = grops[i];
                    sred_rez(grops[i], ref sr); sred[k] = sr; k++;
                }
            }
            sort(gropsBBI, sred);
            for (int i = 0; i < gropsBBI.Length; i++)
            {
                Console.WriteLine("Potok:{0, 10} Group:{1, 10} sredni_rez:{2, 10}", gropsBBI[i].potok, gropsBBI[i].group, sred[i]);
            }
        }
        static void sred_rez(Group grops, ref double sr)
        {
            double sum = 0, n = 5;
            sum = grops.physics + grops.prog + grops.system + grops.matem + grops.analis;
            sr = sum / n;
        }
        static void sort(Group[] grops, double[] sr)
        {
            for (int i = 0; i < grops.Length; i++)
            {
                for (int j = 0; j < grops.Length - 1 - i; j++)
                {
                    if (sr[j] < sr[j + 1])
                    {
                        double temp = sr[i];
                        sr[i] = sr[j];
                        sr[j] = temp;
                        Group g = grops[i];
                        grops[i] = grops[j];
                        grops[j] = g;
                    }
                }
            }
        }
    }
}
