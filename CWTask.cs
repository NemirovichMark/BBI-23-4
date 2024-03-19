using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



struct Goods
{
    public string Name;
    public string Description;
    public double Price;
    public string Article;

    public Goods(string name, double price)
    {
        Name = name;
        Description = $"Для товара {name} описание не задано.";
        Price = price;
        Article = Guid.NewGuid().ToString();
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Стоимость: {Price}");
        Console.WriteLine($"Артикул: {Article}");
    }

    public void ChangeDescription(string newDescription)
    {
        if (newDescription.Length >= 20 && newDescription.Length <= 200)
        {
            Description = newDescription;
            Console.WriteLine("Описание успешно изменено.");
        }
        else
        {
            Console.WriteLine("Ошибка: Описание должно быть не короче 20 символов и не длиннее 200 символов.");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Goods[] goodsArray = new Goods[5];

        goodsArray[0] = new Goods("Товар1", 100);
        goodsArray[1] = new Goods("Товар2", 50);
        goodsArray[2] = new Goods("Товар3", 200);
        goodsArray[3] = new Goods("Товар4", 150);
        goodsArray[4] = new Goods("Товар5", 120);

        
        goodsArray[0].ChangeDescription("Это описание для товара 1.");
        goodsArray[2].ChangeDescription("Это описание для товара 3.");
        goodsArray[4].ChangeDescription("Это описание для товара 5.");

       
        Array.Sort(goodsArray, (x, y) => x.Price.CompareTo(y.Price));

        
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("| Название | Описание | Стоимость | Артикул |");
        Console.WriteLine("--------------------------------------------------");

        foreach (var goods in goodsArray)
        {
            Console.WriteLine($"| {goods.Name,-8} | {goods.Description,-8} | {goods.Price,-9} | {goods.Article,-8} |");
        }

        Console.WriteLine("--------------------------------------------------");
    }
}
