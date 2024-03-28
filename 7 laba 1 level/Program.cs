using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_laba_1_level
{

    public abstract class ParticipantOfCompetition 
                                                   
    {
        private string surname;
        private int group;
        private string surnameTeacher;
        private double result;

        public ParticipantOfCompetition()
        {

        }

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


        public abstract void Print(); 

        public abstract void PrintNormativeCount();
    }

    public class StoBeg : ParticipantOfCompetition 
    {
        private static int normativeCountStoBeg = 0; // статичная переменная, которая относится именно к классу ,а не объекту 
        public StoBeg() : base() { }

        public StoBeg(string _surname, int _group, string _surnameTeacher, double _result) : base(_surname, _group, _surnameTeacher, _result)
        {
        }
        public static int NormativeCountStoBeg { get { return normativeCountStoBeg; } set { normativeCountStoBeg = value; } }





        public override void Print()
        {
            Console.Write($"{Surname},{Group},{SurnameTeacher},{Result}");
            if (Result <= 100)
            {

                NormativeCountStoBeg++;
                Console.WriteLine("- норматив сдан ");
            }
            else
            {
                Console.WriteLine("-норматив не сдан");
            }
        }
        public override void PrintNormativeCount() // override переопределение (реализация будет другая) метода от родительского класса 
        {
            Console.WriteLine("Количсево человек, которые сдали норматив на 100 метров : " + NormativeCountStoBeg);

        }
    }

    public class PetsotBeg : ParticipantOfCompetition
    {
        private static int normativeCountPetsotBeg = 0;

        public PetsotBeg() : base()
        {
        }

        public PetsotBeg(string _surname, int _group, string _surnameTeacher, double _result) : base(_surname, _group, _surnameTeacher, _result)
        {
        }
        public static int NormativeCountPetsotBeg { get { return normativeCountPetsotBeg; } set { normativeCountPetsotBeg = value; } }

        public override void Print()
        {
            Console.Write($"{Surname},{Group},{SurnameTeacher},{Result}");
            if (Result <= 500)
            {
                NormativeCountPetsotBeg++;
                Console.WriteLine("- норматив сдан ");
            }
            else
            {
                Console.WriteLine("-норматив не сдан");
            }
        }
        public override void PrintNormativeCount()
        {
            Console.WriteLine("Количсево человек, которые сдали норматив на 500 метров :" + NormativeCountPetsotBeg);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ParticipantOfCompetition[] participants = new ParticipantOfCompetition[]
            {
            new PetsotBeg ("Перминова", 4, "Чехов", 500),
            new PetsotBeg("Захарова", 5, "Оксюморон", 350),
            new PetsotBeg("Иванова ", 2, "Пушкин", 760),
            new StoBeg("Вишнякова", 1, "Оксимирон", 50),
            new StoBeg("Перова", 10, "Янковский", 200)
            };
            Sort(participants);
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i].Print();
            }
            new PetsotBeg().PrintNormativeCount();//пустой объект без этого объекта не можем обратиться к методу
            new StoBeg().PrintNormativeCount();


        }
        public static void Sort(ParticipantOfCompetition[] participants)
        {
            for (int i = 0; i < participants.Length - 1; i++)
            {
                for (int j = 0; j < participants.Length - 1 - i; j++)
                {
                    if (participants[j].Result > participants[j + 1].Result)
                    {
                        var temp = participants[j];
                        participants[j] = participants[j + 1];
                        participants[j + 1] = temp;
                    }
                }
            }

        }
    }
}
