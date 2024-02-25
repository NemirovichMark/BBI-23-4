// и в классе, и в структуре, есть поля и методы
// в классе больше вещей, которые можно хранить

//программа, позволяющая покупателю проверить наличие сумки в магазине и купить её.
class Bag
{
    private string _model;// Encapsulation 
    private int _size;// Encapsulation
    public bool InStock { get; private set; }// Abstraction + Encapsulation
    public int Price { get; private set; }// Abstraction + Encapsulation
    public Bag(string model, int size) // Abstraction + Encapsulation
    {
        _model = model;
        _size = size;
        InStock = true;
        Price = new Random().Next(10, 20) * _size;
    }
    public void Print() // Abstraction
    {
        if (InStock)
            Console.WriteLine(_model + " with " + _size + " size costs:" + Price);
    }

    public bool Purchase(bool payment) // Abstraction + Encapsulation
    {
        if (!InStock)
        {
            Console.WriteLine("Sold out"); 
            return false;
        }
        else if (!payment)
        {
            Console.WriteLine("Not enough money"); 
            return false;
        }
        else
        {
            Console.Write($"You bought a bag \"{_model}\"\n"); //\"- add a" into the string \n - jump
            InStock = false;
            return true;
        }
    }
}

class Program
{
    private struct Customer // Encapsulation (only Program knows about Customer)
    {
        public string Name { get; private set; } // Abstraction + Encapsulation 
        private int _money; // Encapsulation
        public Customer(string name) // Abstraction
        {
            Name = name;
            _money = new Random().Next(500, 1000);
        }
        public bool Pay(int price) // Abstraction + Encapsulation
        {
            if (_money > price)
            {
                _money -= price;
                return true;
            }
            else
                return false;
        }
    }

    static void Main()
    {
        Customer me = new Customer("Mark");
        Console.WriteLine(me.Name);

        Bag[] bags =
        {
            new Bag("A", 24),
            new Bag("A4", 28),
            new Bag("BiX", 21),
            new Bag("S7", 27)
        };

        foreach (Bag bag in bags) 
            bag.Print();
        foreach (Bag bag in bags)
            bag.Purchase(me.Pay(bag.Price));
        /* same:    if (me.Pay(bag.Price)) 
        *               bag.Purchase(true);      */
        Console.WriteLine("Rest bags:");
        foreach (Bag bag in bags) 
            bag.Print();
    }
}
