using System.Globalization;
using System.Security.Claims;

abstract class Vehicle
{
    private string brand;
    private string model;
    private int VIM;
    public int year { get; private set; }
    private int mileage;
    private string characteristic = null;
    public Vehicle(string _brand, string _model, int _year, int _mileage)
    {
        brand = _brand;
        model = _model;
        year = _year;
        mileage = _mileage;
        VIM = new Random().Next(100000, 999999);
    }
    public void Characteristic()
    {
        if (mileage / (2024 - year) > 500) characteristic = "рабочая";
        else if (mileage / (2024 - year) < 100) characteristic = "простаивающая";
        else characteristic = "праздничная";
    }
    public virtual void Print()
    {
        Console.Write("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}", brand, model, VIM, year, mileage, characteristic);
    }
}
class Car : Vehicle
{
    private string Class;
    public Car(string _brand, string _model, int _year, int _mileage, string _class) : base(_brand, _model, _year, _mileage)
    {
        Class = _class;
    }
    public override void Print() 
    {
        base.Print();
        Console.Write("{0,-15:s}", Class);
    }
}
class Truck : Vehicle
{
    private int wheels;
    public Truck(string _brand, string _model, int _year, int _mileage, int _wheels) : base(_brand, _model, _year, _mileage)
    {
        wheels = _wheels;
    }
    public override void Print()
    {
        base.Print();
        Console.Write("{0,-15:f0}", wheels);
    }
}
class Motorcycle : Vehicle
{
    public Motorcycle(string _brand, string _model, int _year, int _mileage) : base(_brand, _model, _year, _mileage) { }
}


class Program
{
    static void Sort(Vehicle[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            Vehicle k = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].year < k.year)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = k;
        }
    }

    static void Main()
    {
        Car[] cars =
        {
            new Car("Nissan", "X-Trail", 2020, 3000, "S"),
            new Car("Audi", "Q5", 2019, 2000, "A"),
            new Car("BMW", "X5", 2022, 600, "B"),
            new Car("Kia", "Rio", 2016, 5100, "C"),
            new Car("Hyundai", "Solaris", 2018, 550, "S")
        };
        Truck[] trucks =
        {
            new Truck("Nissan", "X-Trail", 2023, 3000, 4),
            new Truck("Audi", "Q5", 2011, 2000, 6),
            new Truck("BMW", "X5", 2015, 600, 4),
            new Truck("Kia", "Rio", 2010, 5100, 8),
            new Truck("Hyundai", "Solaris", 2019, 550, 3)
        };
        Motorcycle[] motorcycles =
        {
            new Motorcycle("Nissan", "X-Trail", 2023, 3000),
            new Motorcycle("Audi", "Q5", 2016, 2000),
            new Motorcycle("BMW", "X5", 2017, 600),
            new Motorcycle("Kia", "Rio", 2013, 5100),
            new Motorcycle("Hyundai", "Solaris", 2009, 550)
        };
        Sort(cars);
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}{6,-15:s}", "Марка", "Модель", "VIM", "Год выпуска", "Пробег", "Характеристика", "Класс");
        foreach (Car a in cars)
        {
            a.Characteristic();
            a.Print();
            Console.WriteLine();
        }
        Console.WriteLine();
        Sort(trucks);
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}{6,-15:f0}", "Марка", "Модель", "VIM", "Год выпуска", "Пробег", "Характеристика", "Количество колёс");
        foreach (Truck a in trucks)
        {
            a.Characteristic();
            a.Print();
            Console.WriteLine();
        }
        Console.WriteLine();
        Sort(motorcycles);
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}", "Марка", "Модель", "VIM", "Год выпуска", "Пробег", "Характеристика");
        foreach (Motorcycle a in motorcycles)
        {
            a.Characteristic();
            a.Print();
            Console.WriteLine();
        }
        Console.WriteLine();

        Vehicle[] array = new Vehicle[15];
        int i = 0;
        foreach (Car a in cars) array[i++] = a;
        foreach (Truck a in trucks) array[i++] = a;
        foreach (Motorcycle a in motorcycles) array[i++] = a;
        Sort(array);
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:s}{3,-15:s}{4,-15:s}{5,-15:s}{6,-15:s}", "Марка", "Модель", "VIM", "Год выпуска", "Пробег", "Характеристика", "Класс или количество колёс (если есть)");
        foreach (Vehicle a in array)
        {
            a.Characteristic();
            a.Print();
            Console.WriteLine();
        };
    }
}