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
                Console.WriteLine($"Пропустил {misses} по Информатике");
            }
        }
        class MathStudent : Student
        {
            public MathStudent(int mark, int misses) : base(mark, misses) { }
            public override void write()
            {
                Console.WriteLine($"Пропустил {misses} по Математике");
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
            int InfnumberOfUnderachievers = 0;
            int MathnumberOfUnderachievers = 0;
            int[] studentsMarksList = new int[Number];
            for (int i = 0; i < studentsMarksList.Length; i++) { studentsMarksList[i] = new Random().Next(0, 5); InfList[i] = new InformaticStudent(studentsMarksList[i], new Random().Next(0, 20)); if (studentsMarksList[i] <= 2) InfnumberOfUnderachievers++; }
            for (int i = 0; i < studentsMarksList.Length; i++) { studentsMarksList[i] = new Random().Next(0, 5); MathList[i] = new MathStudent(studentsMarksList[i], new Random().Next(0, 20)); if (studentsMarksList[i] <= 2) MathnumberOfUnderachievers++; }
            InformaticStudent[] InfUnderachievers = new InformaticStudent[InfnumberOfUnderachievers];
            MathStudent[] MathUnderachievers = new MathStudent[MathnumberOfUnderachievers];
            int Index = 0;
            for (int i = 0; i < Number; i++)
            {
                
                if (InfList[i].Mark <= 2)
                {
                    InfUnderachievers[Index] = InfList[i];
                    Index++;
                }
            }
            Index = 0;
            for (int i = 0; i < Number; i++)
            {

                if (MathList[i].Mark <= 2)
                {
                    MathUnderachievers[Index] = MathList[i];
                    Index++;
                }
            }
            QuickSort(InfUnderachievers, 0, InfUnderachievers.Length - 1);
            QuickSort(MathUnderachievers, 0, MathUnderachievers.Length - 1);
            Console.WriteLine("Список неуспевающих по Информатике");
            for (int i = 0;i < InfUnderachievers.Length; i++)
            {
                InfUnderachievers[i].write();
            }
            Console.WriteLine("Список неуспевающих по Математике");
            for (int i = 0; i < MathUnderachievers.Length; i++)
            {
                MathUnderachievers[i].write();
            }
            Console.ReadKey();
        }
    }
}