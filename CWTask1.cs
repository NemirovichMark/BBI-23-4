CWTask1.cs
namespace _1_задача
{
    struct Contact
    {
        private static int nextId = 1;
        private readonly int id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string mail;

        public Contact(string firstName, string lastName, string phoneNumber, string mail)
        {
            this.id = nextId++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.mail = mail;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID: {id}\tИмя: {firstName}\tФамилия: {lastName}\tТелефон: {phoneNumber}\tmail: {mail}");
        }

        public static Contact[] SortByLastName(Contact[] contacts)
        {
            return contacts.OrderBy(c => c.lastName).ToArray();
        }

        public static Contact[] SortByFirstName(Contact[] contacts)
        {
            return contacts.OrderBy(c => c.firstName).ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Contact[] contacts = new Contact[]
            {
                new Contact("Михаил", "Иванов", "89653422134", "ivanov@mail.com"),
                new Contact("Петр", "Петров", "897654321", "petrov@mail.com"),
                new Contact("Анна", "Смрнова", "89674538890", "smirnova@mail.com"),
                new Contact("Екатерина", "Сидорова", "8975643322", "katesidorova@mail.com"),
                new Contact("Никита", "Рыбаков", "89746782212", "rubakov@mail.com")
            };
            Contact[] contactsSortedByLastName = Contact.SortByLastName(contacts);
            Console.WriteLine("Сортировка по фамилии:");
            foreach (var contact in contactsSortedByLastName)
            {
                contact.PrintInfo();
            }

            Console.WriteLine();

            Contact[] contactsSortedByFirstName = Contact.SortByFirstName(contacts);
            Console.WriteLine("Сортировка по имени:");
            foreach (var contact in contactsSortedByFirstName)
            {
                contact.PrintInfo();
            }
        }
    }
}
