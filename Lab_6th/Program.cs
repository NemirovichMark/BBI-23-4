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
        public int Points { get { return _points; } private set { _points += value; } }
        public string Surname { get { return _surname; } }
        public Person (string surname) { _surname = surname; CalculateJumpPoints(); CalculateJuryPoints(); }
        public void Write()
        {
            Console.WriteLine($"Учасник {_surname}, Счёт: {_points}");
        }
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
            public int Mark { get { return _mark; } }
            public int Misses { get { return _misses; } }
            
            public Student(int mark, int misses)
            {
                _mark = mark;
                _misses = misses;
            }
        }

        struct Command
        {
            private int _points;
            private int _difference;
            private string _name;
            public int Points { get { return _points; } private set { _points = value; } }
            public int Difference { get { return _difference; } private set { _difference = value; } }
            public void Win()
            {
                Points += 3;
            }
            public void Tie()
            {
                Points++;
            }
            public void AddDifference(int a)
            {
                Difference += a;
            }
            public Command(string name)
            {
                _name = name;
                _points = 0;
                _difference = 0;
            }
            public void Write(int n)
            {
                Console.WriteLine($"{n} Место заняла команда {_name}, их счёт: {_points}; Разница: {_difference}");
            }
        }
        static void Main(string[] args)
        {
            void ShellSort(Person[] array)
            {
                int size = array.Length;
                for (int interval = size / 2; interval > 0; interval /= 2)
                {
                    for (int i = interval; i < size; i++)
                    {
                        Person currentKey = array[i];
                        int k = i;
                        while (k >= interval && array[k - interval].Points < currentKey.Points)
                        {
                            array[k] = array[k - interval];
                            k -= interval;
                        }
                        array[k] = currentKey;
                    }
                }
            }

            void InsertionSort(Person[] person)
            {
                int n = person.Length;
                Person key = new Person();
                for (int i = 1; i < n; i++)
                {
                    key = person[i];
                    bool flag = true;
                    for (int j = i; j > 0 && flag; j--)
                    {
                        if (person[j - 1].Points < key.Points)
                        {
                            person[j] = person[j - 1];
                            if (j == 1) { person[0] = key; }
                        }
                        else
                        {
                            person[j] = key;
                            flag = false;
                        }
                    }
                }
            }

            void GnomeSort(Command[] commands)
            {
                int n = commands.Length;
                int i = 1;
                int j = 2;
                while (i < n)
                {
                    if (commands[i].Points < commands[i - 1].Points | (commands[i].Points == commands[i - 1].Points & commands[i].Difference <= commands[i - 1].Difference)) { i = j; j += 1; }
                    else { Command a = commands[i]; commands[i] = commands[i - 1]; commands[i - 1] = a; i--; if (i == 0) { i = j; j += 1; } }
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
            for (int m = 0; m < underachieversList.Length; m++)
            {
                for (int i = 0; i < underachieversList.Length - 1; i++)
                {
                    if (underachieversList[i].Misses > underachieversList[i + 1].Misses)
                    {
                        Student att = underachieversList[i];
                        underachieversList[i] = underachieversList[i + 1];
                        underachieversList[i + 1] = att;
                    }
                }
            }
                
            for (int i = 0; i < underachieversList.Length; i++) { Console.WriteLine($"Student N{i + 1}: {underachieversList[i].Misses} missed\n"); }


            Console.WriteLine("Level II");
            Person[] Competitors = new Person[Surnames.Length];
            for (int i = 0; i < Surnames.Length; i++)
            {
                Competitors[i] = new Person(Surnames[i]);
            }
            ShellSort(Competitors);
            for (int i = 0; i < Competitors.Length; i++)
            {
                Competitors[i].Write();
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
                if (MatchesResults[i] == MatchesResults[i + 1]) { CommandsList[MatchesCommandsId[i]].Tie(); CommandsList[MatchesCommandsId[i + 1]].Tie(); }
                else if (MatchesResults[i] > MatchesResults[i + 1]) { CommandsList[MatchesCommandsId[i]].Win(); }
                else { CommandsList[MatchesCommandsId[i + 1]].Win(); }
                CommandsList[MatchesCommandsId[i]].AddDifference(Math.Abs(MatchesResults[i] - MatchesResults[i + 1]));
                CommandsList[MatchesCommandsId[i + 1]].AddDifference(Math.Abs(MatchesResults[i] - MatchesResults[i + 1]));
            }
            GnomeSort(CommandsList);
            for (int i = 0; i < CommandsList.Length; i++) { CommandsList[i].Write(i + 1); }
            Console.ReadKey();
        }
    }

}