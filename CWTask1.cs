public abstract class Shape
{
    public abstract double Volume{ get; }
    public abstract void PrintInfo();
}

public class Sphere : Shape
{
    public double Radius{ get; }

        public Sphere(double radius)
    {
        Radius = radius;
    }

    public override double Volume = > 4 / 3 * Math.PI * Math.Pow(Radius, 3);

    public override void PrintInfo()
    {
        Console.WriteLine($"Sphere, Radius: {Radius}, Volume: {Volume}");
    }
}

public class Cube : Shape
{
    public double SideLength{ get; }

        public Cube(double sideLength)
    {
        SideLength = sideLength;
    }

    public override double Volume = > Math.Pow(SideLength, 3);

    public override void PrintInfo()
    {
        Console.WriteLine($"Cube, Side Length: {SideLength}, Volume: {Volume}");
    }
}

public class Cylinder : Shape
{
    public double Radius{ get; }
    public double Height{ get; }

        public Cylinder(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    public override double Volume = > Math.PI * Math.Pow(Radius, 2) * Height;

    public override void PrintInfo()
    {
        Console.WriteLine($"Cylinder, Radius: {Radius}, Height: {Height}, Volume: {Volume}");
    }
}

public class Program
{
    public static void Main()
    {
        var spheres = new[]
            {
                new Sphere(1),
                    new Sphere(2),
                    new Sphere(3),
                    new Sphere(4),
                    new Sphere(5)
            };

        var cubes = new[]
            {
                new Cube(1),
