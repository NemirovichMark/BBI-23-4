using System;
namespace Lab_6t
{
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
        static void Main(string[] args)
        {
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
                    Student a = underachieversList[i];
                    underachieversList[i] = underachieversList[i + 1];
                    underachieversList[i + 1] = a;
                }
            }
            for (int i = 0; i < underachieversList.Length; i++) { Console.WriteLine($"Student N{i + 1}: {underachieversList[i].Misses} missed\n"); }


            Console.WriteLine("Level II");

        }
    }
}