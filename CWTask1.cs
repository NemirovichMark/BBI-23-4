using System.Globalization;

struct Car
{
    private string brand;
    private string model;
    private int VIM;
    private int year;
    public int mileage { get; private set; }
    private string characteristic = null;
    public Car(string _brand, string _model, int _year, int _mileage)
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
    public void Print()
    {
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}", brand, model, VIM, year, mileage, characteristic);
    }
}

class Program
{
    static void Sort(Car[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            Car k = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].mileage < k.mileage)
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
            new Car("Nissan", "X-Trail", 2020, 3000),
            new Car("Audi", "Q5", 2019, 2000),
            new Car("BMW", "X5", 2022, 600),
            new Car("Kia", "Rio", 2016, 5100),
            new Car("Hyundai", "Solaris", 2018, 550)
        };
        Sort(cars);
        Console.WriteLine("{0,-15:s}{1,-15:s}{2,-15:f0}{3,-15:f0}{4,-15:f0}{5,-15:s}", "Марка", "Модель", "VIM", "Год выпуска", "Пробег", "Характеристика");
        foreach (Car a in cars)
        {
            a.Characteristic();
            a.Print();
        }
    }
}