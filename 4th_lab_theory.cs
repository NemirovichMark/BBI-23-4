using System;

namespace _4th_Lab
{
    class Theory
    {
        const int ROWS = 3;
        const int COLUMNS = 3;
        const int AMOUNT = ROWS * COLUMNS;
        static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i % COLUMNS == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{array[i],5}");
            }
        }
        static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5}");
                }
            }
        }
        static void Main(string[] args)
        {
            #region Difference between array and matrix
            // Init array with random and show it as a matrix
            int[] array = new int[AMOUNT];
            Random randomizer = new Random();
            Console.Write("Your array as a matrix:");
            for (int i = 0; i < AMOUNT; i++)
            {
                array[i] = randomizer.Next(0, 100);
                if (i % COLUMNS == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($"{array[i],5}");
            }

            // Init array with random and show it as a matrix
            int[,] matrix = new int[ROWS, COLUMNS];
            Console.Write("\n\nYour matrix:");
            for (int i = 0; i < ROWS; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < COLUMNS; j++)
                {
                    matrix[i, j] = randomizer.Next(0, 100);
                    Console.Write($"{matrix[i, j],5}");
                }
            }

            // What is solution better, how do you think? So, if you would use better variant, I will accept. But on the exam you would HAVE TO use it as a matrix[,].
            #endregion

            // Below are presented different algorithms of ascending sorting
            // Example made for int matrix. For an array it is much easier. You HAVE to solve it as an array. Not as a matrix. But the princip is common.

            // For swop I will use a Tuple. You can read what is it here: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
            (int value, int row, int column) min;

            #region Selection sort
            // Find the min element in the matrix and place it at the begin. Repeat excluding 1st element. And so on.
            for (int count = 0; count < ROWS * COLUMNS; count++)
            {
                min = (Int32.MaxValue, count / COLUMNS, count % COLUMNS);
                for (int i = count / COLUMNS; i < ROWS; i++)
                {
                    for (int j = 0; j < COLUMNS; j++)
                    {
                        if (i == count / COLUMNS && j < count % COLUMNS)
                            continue;
                        if (matrix[i, j] < min.value)
                        {
                            min = (matrix[i, j], i, j);
                        }
                    }
                }
                var temp = matrix[count / COLUMNS, count % COLUMNS];
                matrix[count / COLUMNS, count % COLUMNS] = min.value;
                matrix[min.row, min.column] = temp;
            }
            Console.WriteLine("\n\nSelectionSort:");
            ShowMatrix(matrix); // Method for display

            // I won't accept work with such method. It has O(n^3) difficulty

            #endregion

            #region Bubble sort
            // Comapair element and the next one. Swap, if next less than current. Max will rise to the end.
            for (int count = 0; count < ROWS * COLUMNS; count++)
            {
                for (int i = 0 / COLUMNS; i < ROWS; i++)
                {
                    for (int j = 0; j < COLUMNS; j++)
                    {
                        if (i == count / COLUMNS && j < count % COLUMNS)
                            continue;
                        if (i == ROWS - 1 && j == COLUMNS - 1)
                            break;
                        var next = matrix[i + (j + 1) / COLUMNS, (j + 1) % COLUMNS];
                        if (matrix[i, j] > next)
                        {
                            matrix[i + (j + 1) / COLUMNS, (j + 1) % COLUMNS] = matrix[i, j];
                            matrix[i, j] = next;
                        }
                    }
                }
            }
            Console.WriteLine("\n\nBubbleSort:");
            ShowMatrix(matrix); // Method for display

            // I won't accept work with such method. It has O(n^3) difficulty

            #endregion

            // Next algorithms too hard make with matrix and no sence to do it. Previous methods don't use at practice even with arrays.
            #region Coctail sort
            int left = 0;
            int right = ROWS * COLUMNS;
            int swop = 0;
            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    var row = i / COLUMNS;
                    var column = i % COLUMNS;
                    var nextRow = row + (column + 1) / COLUMNS;
                    var nextColumn = (column + 1) % COLUMNS;
                    if (nextRow == ROWS)
                        break;
                    if (matrix[row, column] > matrix[nextRow, nextColumn])
                    {
                        var temp = matrix[nextRow, nextColumn];
                        matrix[nextRow, nextColumn] = matrix[row, column];
                        matrix[row, column] = temp;
                        swop++;
                    }
                }
                right--;

                if (swop == 0)
                {
                    break; // if no swops were done, than all sorted
                }
                swop = 0;
                for (int i = right; i > left; i--)
                {
                    var row = i / COLUMNS;
                    var column = i % COLUMNS;
                    var nextRow = row - (COLUMNS - column) / COLUMNS;
                    var nextColumn = (i - 1) % COLUMNS;
                    if (nextRow < 0)
                        break;
                    if (matrix[row, column] < matrix[nextRow, nextColumn])
                    {
                        var temp = matrix[nextRow, nextColumn];
                        matrix[nextRow, nextColumn] = matrix[row, column];
                        matrix[row, column] = temp;
                        swop++;
                    }
                }
                left++;
                if (swop == 0)
                {
                    break; // if no swops were done, than all sorted
                }
            }
            Console.WriteLine("\n\nCoctailSort:");
            ShowMatrix(matrix); // Method for display

            // I will accept work with such method (or selected and bubble for arrays). But in the class I will ask you to solve task using faster algorithm
            #endregion

            // Next algorithms would required on the defend!!! (also it is realized for array, not matrix)

            #region Gnome sort
            var element = 1;
            var pointer = 2;
            while (element < array.Length)
            {
                if (element == 0 || array[element] >= array[element - 1])
                {
                    element = pointer;
                    pointer++;
                }
                else
                {
                    var temp = array[element - 1];
                    array[element - 1] = array[element];
                    array[element] = temp;
                    element--;
                }
            }
            Console.WriteLine("\n\nGnomeSort:");
            ShowArray(array); // Method for display
            // It is upgraded version of bubble sort
            #endregion

            #region Insert sort
            for (int i = 1; i < array.Length; i++)
            {
                var remembered = array[i];
                var j = i;
                while (j > 0 && array[j - 1] > remembered)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = remembered;
            }
            Console.WriteLine("\n\nInsertSort:");
            ShowArray(array); // Method for display

            // It is very good algorithm for partically-sorted arrays O(nlog(n)) - where log(n) on the base = 2
            #endregion

            #region Shell sort
            var step = array.Length / 2;

            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= step) && array[j - step] > array[j])
                    {
                        var temp = array[j - step];
                        array[j - step] = array[j];
                        array[j] = temp;
                        j -= step;
                    }
                }
                step /= 2;
            }
            Console.WriteLine("\n\nShellSort:");
            ShowArray(array); // Method for display

            #endregion
            
            // There is another faster methods, but they are for advanced programists. You can learn them further if you want to work in that sphere.
        }
    }
}
