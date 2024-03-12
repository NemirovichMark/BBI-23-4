using System;

namespace Lab_6th
{
    internal class Program
    {
        
        abstract class Student
        {
            protected int mark;
            protected int misses;
            public int Mark { get { return mark; } }
            public int Misses { get { return misses; } }
            public Student(int Mark, int Misses)
            {
                mark = Mark;
                misses = Misses;
            }
            public virtual void write() { }
        }
        class InformaticStudent : Student
        {
            public InformaticStudent(int mark, int misses) : base(mark, misses) { }
            public override void write()
            {
                if (mark <= 2) { Console.WriteLine($"Пропустил {misses} по Информатике"); }
            }
        }
        class MathStudent : Student
        {
            public MathStudent(int mark, int misses) : base(mark, misses) { }
            public override void write()
            {
                if (mark <= 2) { Console.WriteLine($"Пропустил {misses} по Математике"); }
            }
        }
        static void Main(string[] args)
        {
            void QuickSort(Student[] array, int leftIndex, int rightIndex)
            {
                int i = leftIndex;
                int j = rightIndex;
                int pivot = array[leftIndex].Misses;
                while (i <= j)
                {
                    while (array[i].Misses < pivot)
                    {
                        i++;
                    }

                    while (array[j].Misses > pivot)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        Student temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i++;
                        j--;
                    }
                }

                if (leftIndex < j)
                    QuickSort(array, leftIndex, j);
                if (i < rightIndex)
                    QuickSort(array, i, rightIndex);
            }
            int Number = 20;
            MathStudent[] MathList = new MathStudent[Number];
            InformaticStudent[] InfList = new InformaticStudent[Number];
            int[] studentsMarksList = new int[Number];
            for (int i = 0; i < studentsMarksList.Length; i++) 
            {
                MathList[i] = new MathStudent(new Random().Next(0, 5), new Random().Next(0, 20));
                InfList[i] = new InformaticStudent(new Random().Next(0, 5), new Random().Next(0, 20));
            }
            QuickSort(InfList, 0, InfList.Length - 1);
            QuickSort(MathList, 0, MathList.Length - 1);
            Console.WriteLine("Список неуспевающих по Информатике");
            for (int i = 0;i < InfList.Length; i++)
            {
                InfList[i].write();
            }
            Console.WriteLine("Список неуспевающих по Математике");
            for (int i = 0; i < MathList.Length; i++)
            {
                MathList[i].write();
            }
            Console.ReadKey();
        }
    }
}