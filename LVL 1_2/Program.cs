using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVL_1_2
{
    internal class Program
    {
        public struct ParticipantOfCompetition
        {
            private string surname;
            private int group;
            private string surnameTeacher;
            private double result;
            private static int normativeCount = 0;

            public ParticipantOfCompetition(string _surname, int _group, string _surnameTeacher, double _result)
            {
                surname = _surname;
                group = _group;
                surnameTeacher = _surnameTeacher;
                result = _result;
            }
            public string Surname { get { return surname; } }
            public int Group { get { return group; } }
            public string SurnameTeacher { get { return surnameTeacher; } }
            public double Result { get { return result; } }

            public void Print(int norm)
            {
                Console.Write($"{surname},{group},{surnameTeacher},{result}");

                if (Result <= norm)
                {
                    normativeCount++;
                    Console.WriteLine("- норматив сдан ");

                }
                else
                {
                    Console.WriteLine("-норматив не сдан");
                    Console.WriteLine($"Выполнили норматив : {normativeCount} женщины ");
                }
            }

        }
        static void Main(string[] args)
        {

            ParticipantOfCompetition[] participants = new ParticipantOfCompetition[]
                {
            new ParticipantOfCompetition("Перминова", 4, "Чехов", 500),
            new ParticipantOfCompetition("Захарова", 5, "Оксюморон", 650),
            new ParticipantOfCompetition("Иванова ", 2, "Пушкин", 760),
            new ParticipantOfCompetition("Вишнякова", 1, "Оксимирон", 350),
            new ParticipantOfCompetition("Перова", 10, "Янковский", 200)};

            Sort(participants);


            //int normativeCount = 0;
            //for (int i = 0; i < participants.Length; i++)
            //{
            //    string passNormative = "No"; // не сдал норматив
            //    if (participants[i].Result <= 500)
            //    {
            //        normativeCount++;
            //        passNormative = "Yes";
            //    }


            //}
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i].Print(500);

                //Console.WriteLine($"Выполнили норматив : {normativeCount} женщины ");
            }



        }
        public static void Sort(ParticipantOfCompetition[] participants)
        {
            for (int i = 0; i < participants.Length - 1; i++)
            {
                for (int j = 0; j < participants.Length - 1 - i; j++)
                {
                    if (participants[j].Result > participants[j + 1].Result)
                    {
                        var temp = participants[j]; // var - тип определяет компилятор 
                        participants[j] = participants[j + 1];
                        participants[j + 1] = temp;
                    }
                }
            }

        }
    }
}



