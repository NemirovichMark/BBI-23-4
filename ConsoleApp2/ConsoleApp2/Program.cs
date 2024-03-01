using System.Linq;
using static System.Console;
using static System.String;

namespace ConsoleApp1
{
    class Program
    {
        struct chalSge
        {
            public string P;
            public double[] S;
        }
        static void Main(string[] args)
        {
            Write("Укажите количество участников: ");
            int H = int.Parse(ReadLine());
            double[] T = new double[3];
            chalSge[] U = new chalSge[H];

            for (int R = 0; R < H; R++)
            {
                Write($"Фамилия {R + 1} участника: ");
                U[R].P = ReadLine();
                U[R].S = T;
                for (int Z = 0; Z < 3; Z++)
                {
                    Write($"{Z + 1} результат {R + 1} участника: ");
                    U[R].S[Z] = double.Parse(ReadLine());
                }
                U[R].S = U[R].S.OrderByDescending(A => A).ToArray();
                Clear();
            }
            for (int R = 0; R < H; R++)
                WriteLine($"Фамилия: {U[R].P}; Результаты: {Join(", ", U[R].S.Select(A => A.ToString()))}");
        }
    }
}