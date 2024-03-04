using System;

namespace _3rd_Lab
{
    class Theory
    {
        static void Main(string[] args)
        {
            #region Collections Theory
            /* Array - static (restricted) massive of data in the memory. If we want to extend it, we should create a new array and copy existing data there.
             * access to each number of array have static time that don't depend on size of array. So get arr[10] and arr[25426] consume equal time.
             * use it when you have determinative amount of elements.
             * 
             *
             *
             * These more suitable collections available if you add System.Collections.Generic library
             *
             *
             * Stack<type of data> - pile of elements (like a books on the table or plates in the sink) 
             * that lay one over another and you can add new one to the top, look at the uppest one or take it
             * 
             * Queue<type of data> - like in the shop or on escalator in the subway. You can add to the end, look the first element or take the first element.
             * 
             * ArrayList - is a non-generic collection of objects whose size increases dynamically. It is the same as Array except that its size increases dynamically.
             * It is a common array for different types. You can keep there int, double, string etc in one array.
             *
             * List<type of data> - a collection of strongly typed objects that can be accessed by index and having methods for sorting, searching, and modifying list. 
             * It is the generic version of the ArrayList/ Use it when you don't know the limit of your array and ought to add or remove elements sometimes (linked array)
             * the PC create an array and when you want to add new element, it create a new array and copy all existing elements there.
             *
             * LinkedList<type of data> - array with a reference to the next and previous element (twice-linked array)
             * 
             * Dictionary<type of key, type of data> - pair key-value. You can add new key, find key, get value by key, set value by key. 
             * Very fast access (as simple array), but more flexible
             * 
             */
            #endregion

            #region Arrays

            //Dimensions:
            int[] oneDimension = new int[1000000]; // row with a 1 million if zeros
            double[] oneDimensionInitializedArray; // undefined array
            int[,] twoDimension = new int[1000, 1000]; // matrix 1000 x 1000, filled by zeros
            string[,,] threeDimension = new string[5, 10, 255]; 
            // 5 rows, 10 columns and 255 elements in the column. Each element can contain a string (so it 4-th dimension array actually)

            int[][] notSquarMatrix = new int[15][]; // array where each element contain an array (different or equal lengths) -> [ [0,1,2,3,4] , [10,25] , [8] ];

            //and so on

            // Access to element:

            threeDimension[threeDimension.Length-1, 0, threeDimension.GetLength(2)-1] = "I am the latest element here!"; 
            // do not forget that start with 0 and end with Length-1!


            double[] shortExample = new double[4] { 1.2, 0.154564, -454, 0 }; // will be crated a new massive with 4 elements

            // Use arrays for limited length. Otherwise - List.
            // For fast search - Dictionary
            // Efficient simple solutions usually realizing by Stack and Queue
            // LinkedList is used seldom

            #endregion
                
            #region Tuples

            //It is linked links to several variables in the fixed order:
            (string name, int age, double height) student = ("Vasiliy", 20, 1.89);
            (int[] marks, int average) table = ({1,2,3,4,5}, 3);.
                
            string Name = student.name; // or student.Item1
            
            var tuple = (count:5, sum:10);
            Console.WriteLine(tuple.count); // 5
            Console.WriteLine(tuple.sum); // 10
            
            // It is the simpliest structure of data (not an array!)
            #endregion
           
            #region Enum

            //It is order of integers (Int 8 / 16 / 32 / 64) where you create a list of names and each name get the value (increment by 1 of previous):              
            enum Marks
            {
                Bad = 2,
                Nice, // auto-incremented to 3
                Good, // 4 ...
                Excellent // not coma at the end!
            }
            
            enum Classes
            {
                Math = 1,
                PhysicalCulture = 3, // Jump over
                History = 4,
                Dinner = 2 // Instead Informatics
            }
            
            int myAvgMark = (int)Marks.Bad + (int)Marks.Excellent; // cast to int!
            Console.WriteLine((Classes)10); // expancion to enum values
            
            public enum Season
            {
                Spring,
                Summer,
                Autumn,
                Winter
            }
            
            Season a = Season.Autumn;
            Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

            var b = (Season)1;
            Console.WriteLine(b);  // output: Summer

            var c = (Season)4;
            Console.WriteLine(c);  // output: 4
            
            // More informative than variables, more flexible than constans, more strict than string, more effective than dictionary :) cool thing!
            #endregion       
        }
    }
}
