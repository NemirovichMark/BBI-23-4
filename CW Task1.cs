using System;
using System.Linq;

struct Goods
{
    public string Name;
    public string About;
    public double Price;
    public int Article;


    public Goods(string name, double price, int article)
    {
        Name = name;
        Price = price;
        About = $"Для товара {name} описание не задано";
        Random rnd = new Random(); // не стал использовать
        int value = rnd.Next(); // не стал использовать
        Article = article;
    }

    public void Information()
    {
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {About}");
        Console.WriteLine($"Цена: {Price}");
        Console.WriteLine($"Артикул: {Article}");
    }

    public void ChangeAbout(string newAbout)
    {
        if (newAbout.Length < 20 || newAbout.Length > 200)
        {
            Console.WriteLine("Описание вашего товара должно содержать не менее 20 и не более 200 символов!");
        }
        else
        {
            About = newAbout;
            Console.WriteLine("Описание изменено.");
        }
    }
}

class Program
{
    static void Main()
    {
        Goods[] goodsArray = new Goods[5];
        goodsArray[0] = new Goods("Товар 1", 10.0, 3526374);
        goodsArray[1] = new Goods("Товар 2", 90.0, 1587618);
        goodsArray[2] = new Goods("Товар 3", 29.0, 9185676);
        goodsArray[3] = new Goods("Товар 4", 23.0, 1270506);
        goodsArray[4] = new Goods("Товар 5", 48.0, 8915773);

        // Изменение описания для первых трех товаров
        goodsArray[0].ChangeAbout("Это новое описание Товара 1");
        goodsArray[1].ChangeAbout("Это новое описание Товара 2");
        goodsArray[2].ChangeAbout("Это новое описание Товара 3");

        // Сортировка по возрастанию цены
        Array.Sort(goodsArray, (x, y) => x.Price.CompareTo(y.Price));

        // Вывод в виде таблицы
        Console.WriteLine("Название\tОписание\tЦена\tАртикул");
        foreach (var goods in goodsArray)
        {
            Console.WriteLine($"{goods.Name}\t{goods.About}\t{goods.Price}\t{goods.Article}");
        }
    }
}
