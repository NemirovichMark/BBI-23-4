using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Lab_6th
{
    internal class CWTask1
    {
        struct Rectangle
        {
            private int _length = 0;
            private int _width = 0;
            private string _name = "";
            public int Length { get { return _length; } }
            public int Width { get { return _width; } }
            public string Name { get { return _name; } }
            public Rectangle(int length, int width, string name)
            {
                _length = length;
                _width = width;
                _name = name;
            }
            private int Perimeter()
            {
                return 2 * (_length + _width);
            }
            private int Square()
            {
                return _length * _width;
            }
            public void Compare(Rectangle other)
            {
                Console.WriteLine($"Сравним прямоугольники {_name} и {other.Name}");
                if (_length > other._length) { Console.WriteLine($"{_name} длиннее чем {other.Name}"); }
                else if (_length < other._length) { Console.WriteLine($"{other.Name} длиннее чем {_name}"); }
                else { Console.WriteLine($"{other.Name} и {_name} одинаковой длины"); }

                if (_width > other._width) { Console.WriteLine($"{_name} шире чем {other.Name}"); }
                else if (_width < other._width) { Console.WriteLine($"{other.Name} шире чем {_name}"); }
                else { Console.WriteLine($"{other.Name} и {_name} одинаковой ширины"); }

                if (Perimeter() > other.Perimeter()) { Console.WriteLine($"{_name} имеет больший периметр чем {other.Name}"); }
                else if (Perimeter() < other.Perimeter()) { Console.WriteLine($"{other.Name} имеет больший периметр чем {_name}"); }
                else { Console.WriteLine($"{other.Name} и {_name} имеют одинаковый периметр"); }

                if (Square() > other.Square()) { Console.WriteLine($"{_name} имеет большую площадь чем {other.Name}"); }
                else if (Square() < other.Square()) { Console.WriteLine($"{other.Name} имеет большую площадь чем {_name}"); }
                else { Console.WriteLine($"{other.Name} и {_name} имеют одинаковую площадь"); }
            }
        }
        static void Main(string[] args)
        {
            Rectangle Peta = new Rectangle(new Random().Next(1, 10), new Random().Next(1, 10), "Петя");
            Rectangle Vasa = new Rectangle(new Random().Next(1, 10), new Random().Next(1, 10), "Вася");
            Rectangle Sana = new Rectangle(new Random().Next(1, 10), new Random().Next(1, 10), "Саня");
            Peta.Compare(Vasa);
            Peta.Compare(Sana);
            Vasa.Compare(Sana);
        }
    }
}