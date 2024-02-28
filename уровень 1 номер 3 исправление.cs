using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace уровень_1_номер_3
{
    struct survey
    {
        private string name;
        private int votes;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Votes
        {
            get
            {
                return votes;
            }
        }
    
        public survey(string name_, int votes_)
        {
            name = name_;
            votes = votes_;
        }
    }

    class Program
    {
        static void Main()
        {
            survey[] answers = new survey[]
            {
            new survey("Ivan", 150),
            new survey("Katya", 120),
            new survey("Lera", 135),
            new survey("Sergey", 140),
            new survey("Kolya", 120)
            };

            for (int i = 0; i < answers.Length - 1; i++)
            {
                for (int j = 0; j < answers.Length - 1 - i; j++)
                {
                    if (answers[j].Votes < answers[j + 1].Votes)
                    {
                        survey temp = answers[j + 1];
                        answers[j + 1] = answers[j];
                        answers[j] = temp;
                    }
                }
            }

            int total = 0;

            foreach (survey answer in answers)
            {
                total += answer.Votes;
            }

            for (int i = 0; i < answers.Length; i++)
            {
                double percentage = ((double)answers[i].Votes / total) * 100;
                Console.WriteLine($"{answers[i].Name}: {percentage.ToString("0.00")}%");
            }
        }
    }
}
