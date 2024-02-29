using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_lr_3_lvl_1
{
    struct Group
    {
        private string _groupa_, _potok_;
        private int hist_, engl_, math_, phys_, progr_;
        public Group(string group, string potok, int hist, int engl, int math, int phys, int progr)
        {
            _groupa_ = group;
            _potok_ = potok;
            hist_ = hist;
            engl_ = engl;
            math_ = math;
            phys_ = phys;
            progr_ = progr;
        }
        public string group { get => _groupa_; }
        public string potok { get => _potok_; }
        public int hist { get => hist_; }
        public int engl { get => engl_; }
        public int math { get => math_; }
        public int phys { get => phys_; }
        public int progr { get => progr_; }
        public void srresults(Group gr, ref double sred)
        {
            double summa = 0;
            double n = 5;
            summa = gr.hist + gr.engl + gr.math + gr.phys + gr.progr;
            sred = summa / n;
        }
        public void Print(Group gr, double sred)
        {
            Console.WriteLine("поток : {0, 10} группа{1, 10} среднее{2, 10} ", potok, group, sred);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] gr = new Group[5];
            gr[0] = new Group("1", "pp", 4, 5, 3, 4, 5);
            gr[1] = new Group("4", "ty", 5, 5, 4, 3, 4);
            gr[2] = new Group("2", "pp", 4, 4, 5, 5, 3);
            gr[3] = new Group("3", "pp", 4, 4, 3, 4, 4);
            gr[4] = new Group("1", "ww", 4, 3, 3, 5, 5);
            Group[] grp = new Group[3];
            double[] sred = new double[3];
            int k = 0;
            double sr = 0;
            for (int i = 0; i < gr.Length; i++)
            {
                string pp = "pp";
                if (gr[i].potok.Equals("pp"))
                {
                    grp[k] = gr[i];
                    gr[i].srresults(gr[i], ref sr);
                    sred[k] = sr;
                    k++;
                }
            }
            sort(grp, sred);
            for (int i = 0; i < grp.Length; i++)
            {
                grp[i].Print(grp[i], sred[i]);
            }
        }
        static void sort(Group[] gr, double[] sr)
        {
            for (int i = 0; gr.Length > i; i++)
            {
                for (int j = 0; j < gr.Length - 1 - i; j++)
                {
                    if (sr[j] < sr[j + 1])
                    {
                        double temp = sr[j];
                        sr[j] = sr[j + 1];
                        sr[j + 1] = temp;
                        Group g = gr[j];
                        gr[j] = gr[j + 1];
                        gr[j + 1] = g;
                    }
                }
            }
        }
    }
}
