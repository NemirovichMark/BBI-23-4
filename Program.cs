// See https://aka.ms/new-console-template for more information
using System;

struct Triangle
{
    public double A;
    public double B;
    public double C;

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public string Type()
    {
        if (A == B && B == C)
            return "равносторонний";
        else if (A == B || B == C || A == C)
            return "равнобедренный";
        else
            return "разносторонний";
    }

    public double Area()
    {
        double p = (A + B + C) / 2;
        double area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        return area;
    }

    public void Info()
    {
        Console.WriteLine($"Стороны: {A}, {B}, {C}");
        Console.WriteLine($"Тип: {Type()}");
        Console.WriteLine($"Площадь: {Area()}\n");
    }
}

class Program
{
    static void Main()
    {
        Triangle[] triangles = new Triangle[]
        {
            new Triangle(3, 4, 5),
            new Triangle(5, 5, 5),
            new Triangle(4, 4, 3),
        };

        SORT(triangles);

        foreach (var triangle in triangles)
        {
            triangle.Info();
        }
    }
    static void SORT(Triangle[] triangles)
    {
        int n = triangles.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (triangles[j].Area() < triangles[j + 1].Area())
                {
                    Triangle temp = triangles[j];
                    triangles[j] = triangles[j + 1];
                    triangles[j + 1] = temp;
                }
            }
        }
    }
}

