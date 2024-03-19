struct Contact
{
    private static int _number;
    private int _number1;
    private string _name;
    private string _surname;
    private double _numberphone;
    private string _email;
    public Contact(string surname, string name, double numberphone, string email)
    {
        _name = name;
        _surname = surname;
        _numberphone = numberphone;
        _email = email;
        _number++;
        _number1 = _number;
    }
    public void Print()
    { Console.WriteLine("{0,20},{1,20},{2,20},{3,20},{4,20}", _surname, _name, _numberphone, _email, _number1); }
    class Program
    {
        static void Main()
        {
            Contact[] person = new Contact[5];
            person[0] = new Contact("Podzemelniy", "Alex", 80000000000, "Podz@mail.ru");
            person[1] = new Contact("Ragozin", "Artyom", 80000000001, "Ragozin@mail.ru");
            person[2] = new Contact("Davidenko", "Artyom", 80000000002, "Davidenko@mail.ru");
            person[3] = new Contact("Zhelonkinh", "Valia", 80000000003, "Zhelonkinh@mail.ru");
            person[4] = new Contact("Perminova", "Milena", 80000000004, "Perminova@mail.ru");        
            Console.WriteLine("{0,20},{1,20},{2,20},{3,20},{4,20}","Фамилия", "Имя", "Номер телефона", "Почта", "Порядковый номер");
            for (int i = 0; i < person.Length; i++)
            { person[i].Print(); }
        }
    }
}
