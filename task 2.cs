using System;

abstract class Goods
{
    protected double _initialp;
    protected string _name;
    protected double _price;
    protected int _quantity;
    protected string _article;

    public double Price => _price;

    public abstract double Calculate();
    public abstract void Print();

    public static void tableh()
    {
        Console.WriteLine($"{"Название",10} {"Цена",10} {"Особенность",15} {"Количество",15} {"Артикул",10}");
    }

    public void Change(double newPrice)
    {
        _price = newPrice;
    }
}

class Product : Goods
{
    private DateTime _expiryd;

    public Product(double price, DateTime expiryd, string name, string article, int quantity)
    {
        _initialp = price;
        _price = price;
        _expiryd = expiryd;
        _name = name;
        _article = article;
        _quantity = quantity;
    }

    public override double Calculate()
    {
        return _price * (_expiryd.Month * 0.1 + 1);
    }

    public override void Print()
    {
        Console.WriteLine($"{_name,10} {_price,10:0.00} {_expiryd,15:d} {_quantity,10} {_article,15}");
    }
}

class Equipment : Goods
{
    private int _warrantyp;

    public Equipment(double price, int warrantyp, string name, string article, int quantity)
    {
        _initialp = price;
        _price = price;
        _warrantyp = warrantyp;
        _name = name;
        _article = article;
        _quantity = quantity;
    }

    public override double Calculate()
    {
        return _price * (_warrantyp * 0.05 + 1);
    }

    public override void Print()
    {
        Console.WriteLine($"{_name,10} {_price,10:0.00} {_warrantyp,10:d} {_quantity,15} {_article,15}");
    }
}

class Tool : Goods
{
    private string _qualityc;

    public Tool(double price, string qualityc, string name, string article, int quantity)
    {
        _initialp = price;
        _price = price;
        _qualityc = qualityc;
        _name = name;
        _article = article;
        _quantity = quantity;
    }

    public override double Calculate()
    {
        double mnog = _qualityc switch
        {
            "A" => 1.2,
            "B" => 1.1,
            _ => 1.0
        };

        return _price * mnog;
    }

    public override void Print()
    {
        Console.WriteLine($"{_name,10} {_price,10:0.00} {_qualityc,10:d} {_quantity,15} {_article,15}");
    }
}
class Program
{
    static void Main(string[] args)
    {

        Product[] products = new Product[5];
        products[0] = new Product(50, DateTime.Now.AddDays(10), "Ботинки", "3848", 90);
        products[1] = new Product(60, DateTime.Now.AddDays(20), "Кофта", "3836", 23);
        products[2] = new Product(70, DateTime.Now.AddDays(30), "Куртка", "2844", 34);
        products[3] = new Product(80, DateTime.Now.AddDays(40), "Валенки", "4536", 23);
        products[4] = new Product(90, DateTime.Now.AddDays(50), "Сапоги", "2738", 45);

        Equipment[] equipments = new Equipment[5];
        equipments[0] = new Equipment(230, 12, "Леденец", "3843", 90);
        equipments[1] = new Equipment(180, 18, "Конфета", "2839", 78);
        equipments[2] = new Equipment(450, 24, "Шоколад", "5868", 56);
        equipments[3] = new Equipment(392, 36, "Мороженое", "2938", 34);
        equipments[4] = new Equipment(956, 48, "Чупа-чупс", "4859", 12);

        Tool[] tools = new Tool[5];
        tools[0] = new Tool(120, "A", "Сыр", "4827", 3);
        tools[1] = new Tool(105, "B", "Молоко", "2838", 4);
        tools[2] = new Tool(110, "C", "Яйца", "2924", 5);
        tools[3] = new Tool(135, "A", "Кефир", "2939", 6);
        tools[4] = new Tool(150, "B", "Ряженка", "7096", 7);

        Sort(tools);
        Sort(equipments);
        Sort(products);

        Console.WriteLine("Одежда:");
        Goods.tableh();
   
        foreach (var product in products)
        {
            product.Print();
        }

        Console.WriteLine("\nСладости:");
        Goods.tableh();
      
        foreach (var equipment in equipments)
        {
            equipment.Print();
        }

        Console.WriteLine("\nМолочные продукты:");
        Goods.tableh();
     
        foreach (var tool in tools)
        {
            tool.Print();
        }

        foreach (var product in products)
        {
            product.Change(product.Calculate());
        }

        foreach (var equipment in equipments)
        {
            equipment.Change(equipment.Calculate());
        }

        foreach (var tool in tools)
        {
            tool.Change(tool.Calculate());
        }

        Goods[] goodsar = new Goods[15];

        for (int i = 0; i < products.Length; i++)
        {
            goodsar[i] = products[i];
        }
        for (int i = 0; i < equipments.Length; i++)
        {
            goodsar[i + products.Length] = equipments[i];
        }
        for (int i = 0; i < tools.Length; i++)
        {
            goodsar[i + products.Length + equipments.Length] = tools[i];
        }

        Sort(goodsar);

        Console.WriteLine("\nПосле сортировки:");
        Goods.tableh();

        foreach (var goods in goodsar)
        {
            goods.Print();
        }
    }
    static void Sort(Goods[] goods)
    {
        int i = 1;
        int j = 2;
        while (i < goods.Length)
        {
            if (goods[i - 1].Price <= goods[i].Price)
            {
                i = j;
                j++;
            }
            else
            {
                Goods temp = goods[i - 1];
                goods[i - 1] = goods[i];
                goods[i] = temp;
                i--;
                if (i == 0)
                {
                    i = j;
                    j++;
                }
            }
        }
    }
}


