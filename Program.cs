// See https://aka.ms/new-console-template for more information
using System;

abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
}

class Round : Shape
{
    private double Radius;

    public Round(double radius)
    {
        Radius = radius;
    }

    public override double Area()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public override double Perimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

class Square : Shape
{
    private double Side;

    public Square(double side)
    {
        Side = side;
    }

    public override double Area()
    {
        return Math.Pow(Side, 2);
    }

    public override double Perimeter()
    {
        return 4 * Side;
    }
}

class Triangle : Shape
{
    private double A;
    private double B;
    private double C;

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double Area()
    {
        double p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public override double Perimeter()
    {
        return A + B + C;
    }
}

class Program
{
    static void Info(Shape shape)
    {
        Console.WriteLine($"{shape.GetType().Name}\t{shape.Perimeter()}\t\t{shape.Area()}");
    }

    static void Main()
    {
        Shape[] rounds = new Shape[]
        {
            new Round(5), new Round(7), new Round(3), new Round(4), new Round(6)
        };
        Shape[] squares = new Shape[]
        {
           new Square(4), new Square(6), new Square(3), new Square(5), new Square(7)
        };
        Shape[] triangles = new Shape[]
        {
              new Triangle(3, 4, 5), new Triangle(5, 5, 5), new Triangle(4, 4, 3), new Triangle(5, 12, 13), new Triangle(7, 8, 10)
        };


        SortShapes(rounds);
        SortShapes(squares);
        SortShapes(triangles);

        Console.WriteLine("Фигура\t\tПериметр\tПлощадь");

        foreach (var round in rounds)
        {
            Info(round);
        }
        foreach (var square in squares)
        {
            Info(square);
        }
        foreach (var triangle in triangles)
        {
            Info(triangle);
        }
    }   
    static void SortShapes(Shape[] arr)
    {
       int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j].Area() < arr[j + 1].Area())
                {
                    Shape temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

