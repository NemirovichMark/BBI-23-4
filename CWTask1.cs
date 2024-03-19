using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTask1
{
    struct Rectangle
    {
        private int Dlina;
        private int Shirina;
        public int Length { get { return Dlina; } }
        public int Weight { get { return Shirina; } }
        public Rectangle(int dlina, int shirina)
        {
            Dlina = dlina;
            Shirina = shirina;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle[] rectangle = new Rectangle[] { new Rectangle(3, 2), new Rectangle(2, 1), new Rectangle(1, 5) };
            Console.WriteLine("№ первого\t № второго\t Большая длина\t Большая ширина\t Большая площадь");

            Console.Write("0\t\t 1\t\t");
            Compare(rectangle[0], rectangle[1]);

            Console.Write("1\t\t 2\t\t");
            Compare(rectangle[1], rectangle[2]);

            Console.Write("0\t\t 2\t\t");
            Compare(rectangle[0], rectangle[2]);

        }
        public static int Plochad(Rectangle rectangle)
        {
            return rectangle.Length * rectangle.Weight;
        }
        public int Perimetr(Rectangle rectangle)
        {
            return 2*(rectangle.Length + rectangle.Weight);
        }
        static void Compare (Rectangle r1, Rectangle r2)
        {
            String maxlenght, maxweight, maxplochad; 
            if (r1.Length > r2.Length)
            {
                maxlenght = "Первый";
            }
            else
            {
                maxlenght = "Второй";
            }
            if (r1.Weight > r2.Weight)
            {
                maxweight = "Первый";
            }
            else
            {
                maxweight = "Второй";
            }
            if (Plochad(r1) > Plochad(r2))
            {
                maxplochad = "Первый";
            }
            else
            {
                maxplochad = "Второй";
            }
            Console.WriteLine(" {0}\t \t {1}\t \t {2}", maxlenght, maxweight, maxplochad);
        }
    }
}
