using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_уровень_3_номер
{
    struct survey
    {
        public string name;
        public int votes;
    }

    class Program
    {
        static void Main()
        {
            survey[] answers = new survey[5];
            answers[0].name = "Ivan"; answers[0].votes = 150;
            answers[1].name = "Katya"; answers[1].votes = 120;
            answers[2].name = "Masha"; answers[2].votes = 100;
            answers[3].name = "Jenya"; answers[3].votes = 90;
            answers[4].name = "Kolya"; answers[4].votes = 80;

            for (int i = 0; i < answers.Length - 1; i++)
            {
                for (int j = 0; j < answers.Length - 1 - i; j++)
                {
                    if (answers[j].votes < answers[j + 1].votes)
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
                total += answer.votes;
            }

            for (int i = 0; i < answers.Length; i++)
            {
                double percentage = ((double)answers[i].votes / total) * 100;
                Console.WriteLine($"{answers[i].name}: {percentage.ToString("0.00")}%");
            }
        }
    }
}



