using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Lab_6th
{
    struct Person
    {
        private int _points = 0;
        private string _surname = "";
        public int Points { get { return _points; } set { _points += value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public Person (string surname) { _surname = surname; CalculateJumpPoints(); CalculateJuryPoints(); }
        void CalculateJuryPoints()
        {
            Random random = new Random();
            int max = 0;
            int min = 21;
            for (int i = 0; i < 5; i++)
            {
                int point = random.Next(0, 20);
                if (point < min) min = point;
                if (point > max) max = point;
                Points = point;
            }
            Points = -1 * (min + max);
        }
        void CalculateJumpPoints()
        {
            Random random = new Random();
            int jump = random.Next(100, 140);
            Points = (jump - 120) * 2;
        }
    }
    internal class Program
    {
        struct Student
        {
            private int _mark;
            private int _misses;
            public int Mark { get { return _mark; } set { _mark = value; } }
            public int Misses { get { return _misses; } set { _misses = value; } }
            public Student(int mark, int misses)
            {
                _mark = mark;
                _misses = misses;
            }
        }

        struct Command
        {
            private int _points = 0;
            private int _difference = 0;
            private string _name = "";
            public string Name { get { return _name; } set { _name = value; } }
            public int Points { get { return _points; } set { _points += value; } }
            public int Difference { get { return _difference; } set { _difference += value; } }
            public Command(string name)
            {
                _name = name;
                _points = 0;
                _difference = 0;
            }
        }
        static void Main(string[] args)
        {
            void InsertionSort (Person[] person)
            {
                int n = person.Length;
                for (int i = 1; i < n; i++)
                {
                    for (int j = i; j > 0 && person[j - 1].Points < person[j].Points; j--)
                    {
                        Person a = person[j - 1];
                        person[j - 1] = person[j];
                        person[j] = a;
                    }
                }
            }

            void GnomeSort(Command[] commands)
            {
                int n = commands.Length;
                int i = 1;
                while (i < n)
                {
                    if (commands[i].Points < commands[i - 1].Points | (commands[i].Points == commands[i - 1].Points & commands[i].Difference <= commands[i - 1].Difference)) { i++; }
                    else { Command a = commands[i]; commands[i] = commands[i - 1]; commands[i - 1] = a; i--; if (i == 0) { i = 2; } }
                }
            }
            int Maxx(int[] a)
            {
                int n = a.Length;
                int k = 0;
                int max = 0;
                for (int i = 0; i < n; i++) { if (a[i] > max) { k = i; max = a[i]; } }
                return k;
            }

            int Minn(int[] a)
            {
                int n = a.Length;
                int k = 0;
                int min = 30;
                for (int i = 0; i < n; i++) { if (a[i] < min) { k = i; min = a[i]; } }
                return k;
            }
            string[] Surnames = { "Хвойный", "Вертюк", "Пенаст", "Гаврилов", "Тернюк" };
            string[] Names = { "Алмаз", "Изумруд", "Рубин", "Топаз", "Яшма" };

            Console.WriteLine("Level I");
            Random random = new Random();
            int[] studentsMissesList = new int[8];
            for (int i = 0; i < studentsMissesList.Length; i++) { studentsMissesList[i] = random.Next(0, 14); }
            int[] studentsMarksList = new int[8];
            int numberOfUnderachievers = 0;
            for (int i = 0; i < studentsMarksList.Length; i++) { studentsMarksList[i] = random.Next(0, 5); if (studentsMarksList[i] == 2) numberOfUnderachievers++; }
            Student[] underachieversList = new Student[numberOfUnderachievers];
            Student[] studentsList = new Student[8];
            int Index = 0;
            for (int i = 0; i < studentsList.Length; i++)
            {
                studentsList[i] = new Student(studentsMarksList[i], studentsMissesList[i]);
                if (studentsList[i].Mark == 2)
                {
                    underachieversList[Index] = studentsList[i];
                    Index++;
                }
            }
            for (int i = 0; i < underachieversList.Length - 1; i++)
            {
                if (underachieversList[i].Misses > underachieversList[i + 1].Misses)
                {
                    Student att = underachieversList[i];
                    underachieversList[i] = underachieversList[i + 1];
                    underachieversList[i + 1] = att;
                }
            }
            for (int i = 0; i < underachieversList.Length; i++) { Console.WriteLine($"Student N{i + 1}: {underachieversList[i].Misses} missed\n"); }


            Console.WriteLine("Level II");
            Person[] Competitors = new Person[Surnames.Length];
            for (int i = 0; i < Surnames.Length; i++)
            {
                Competitors[i] = new Person(Surnames[i]);
            }
            InsertionSort(Competitors);
            for (int i = 0;i < Competitors.Length; i++)
            {
                Console.WriteLine($"Учасник {Competitors[i].Surname}, Счёт: {Competitors[i].Points}");
            }


            Console.WriteLine("Level III");
            int[] MatchesResults = new int[30];
            string[] MatchesCommands = new string[30];
            int[] MatchesCommandsId = new int[30];
            for (int i = 0; i < 30; i++) { MatchesResults[i] = random.Next(0, 5); }
            int a = random.Next(0, 4);
            MatchesCommands[0] = Names[a];
            MatchesCommandsId[0] = a;
            for (int i = 1; i < 30; i++)
            {
                if (i % 2 == 1) { int n = random.Next(0, 4); while (n == a) { n = random.Next(0, 4); } MatchesCommands[i] = Names[n]; MatchesCommandsId[i] = n; }
                else { a = random.Next(0, 4); MatchesCommands[i] = Names[a]; MatchesCommandsId[i] = a; }
            }
            Command[] CommandsList = new Command[Names.Length];
            for (int i = 0; i < Names.Length; i++)
            {
                CommandsList[i] = new Command(Names[i]);
            }
            for (int i = 0; i < 30; i += 2)
            {
                if (MatchesResults[i] == MatchesResults[i + 1]) { CommandsList[MatchesCommandsId[i]].Points = 1; CommandsList[MatchesCommandsId[i + 1]].Points = 1; }
                else if (MatchesResults[i] > MatchesResults[i + 1]) { CommandsList[MatchesCommandsId[i]].Points = 3; }
                else { CommandsList[MatchesCommandsId[i + 1]].Points = 3; }
                CommandsList[MatchesCommandsId[i]].Difference = Math.Abs(MatchesResults[i] - MatchesResults[i + 1]);
                CommandsList[MatchesCommandsId[i + 1]].Difference = Math.Abs(MatchesResults[i] - MatchesResults[i + 1]);
            }
            GnomeSort(CommandsList);
            for (int i = 0;i < CommandsList.Length;i++) { Console.WriteLine($"{i + 1} Место заняла команда {CommandsList[i].Name}, их счёт: {CommandsList[i].Points}; Разница: {CommandsList[i].Difference}"); }
            Console.ReadKey();
        }
    }

}