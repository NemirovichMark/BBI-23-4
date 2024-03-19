using System;

public struct Dot
{
    public int X{ get; }
    public int Y{ get; }
    public int Z{ get; }

        public Dot(int[] point)
    {
        X = point[0];
        Y = point[1];
        Z = point[2];
    }
}

public struct Vector
{
    public Dot Start{ get; }
    public Dot End{ get; }

        public Vector(int[, ] matrix)
    {
        Start = new Dot(new[] { matrix[0, 0], matrix[0, 1], matrix[0, 2] });
        End = new Dot(new[] { matrix[1, 0], matrix[1, 1], matrix[1, 2] });
    }

    public double Length()
    {
        return Math.Sqrt(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2) + Math.Pow(End.Z - Start.Z, 2));
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Start: ({Start.X}, {Start.Y}, {Start.Z})");
        Console.WriteLine($"End: ({End.X}, {End.Y}, {End.Z})");
        Console.WriteLine($"Length: {Length()}");
    }
}

class Program
{
    static void Main()
    {
        var vectors = new[]
            {
                new Vector(new [, ] { { {1, 1, 1}, { 2, 2, 2 } }}),
                    new Vector(new [, ] { { {3, 3, 3}, { 4, 4, 4 } }}),
                    new Vector(new [, ] { { {5, 5, 5}, { 6, 6, 6 } }}),
                    new Vector(new [, ] { { {7, 7, 7}, { 8, 8, 8 } }}),
                    
