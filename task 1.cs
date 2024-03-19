using System;

struct Goods

{
    private string name;
    private string article;
    private double price;
    private int kolvo;

    public Goods(string name_, string article_, double price_, int kolvo_)
    {
        name = name_;
        article = article_;
        price = price_;
        kolvo = kolvo_;
    }

    public void Print()
    {
        Console.WriteLine($"Название: {name}\tАртикул: {article}\tЦена: {price}\tКол-во: {kolvo}");
    }

    public static void tableh()
    {
        Console.WriteLine($"{"Название",10} {"Артикул",10} {"Цена",10} {"Кол-во",10}");
    }

    public static void tabler(Goods item)
    {
        Console.WriteLine($"{item.name,10} {item.article,10} {item.price,10} {item.kolvo,10}");
    }

    public static void Sort(Goods[] goods)
    {
        for (int i = 0; i < goods.Length - 1; i++)
        {
            for (int j = 0; j < goods.Length - 1 - i; j++)
            {
                if (goods[j].price > goods[j + 1].price)
                {
                    exch(ref goods[j], ref goods[j + 1]);
                }
            }
        }
    }

    private static void exch(ref Goods a, ref Goods b)
    {
        Goods temp = a;
        a = b;
        b = temp;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Goods[] goods = new Goods[]
        {
            new Goods("Футболка", "0403", 3000, 20),
            new Goods("Кроссовки", "3993", 3400, 40),
            new Goods("Шорты", "9292", 2000, 25),
            new Goods("Джинсы", "5784", 1500, 10),
            new Goods("Пиджак", "3829", 5600, 30)
        };
        Goods.Sort(goods);
        Goods.tableh();
        foreach (var item in goods)
        {
            Goods.tabler(item);
        }
    }
}



