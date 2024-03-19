
namespace ConsoleApp1
{
    public struct Book
    {
        private string name;
        private int ISBN;
        private string author;
        private int year;
        private static int count = 1;

        public Book(string name, string author, int year)
        {
            this.name = name;
            ISBN = count;
            this.author = author;
            this.year = year;
            count++;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Isbn
        {
            get { return ISBN; }
            private set { ISBN = value; }
        }

        public string Author
        {
            get { return author; }
            private set { author = value; }
        }

        public int Year
        {
            get { return year; }
            private set { year = value; }
        }

        public static int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public void printInfo()
        {
            Console.WriteLine(ISBN + ", " + name + ", " + author + ", " + year);
        }

        public static void printInfoWithName(Book[] books, string name)
        {
            for (int i = 0; i < books.Length; i++)
            {

                if (books[i].author.Equals(name))
                {
                    Console.WriteLine(books[i].ISBN + ", " + books[i].name + ", " + books[i].author + ", " + books[i].year);
                }
            }
        }

        public static void printInfoWithAge(Book[] books, int vek)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].year > (vek - 1) * 100 && books[i].year < vek * 100)
                {
                    Console.WriteLine(books[i].ISBN + ", " + books[i].name + ", " + books[i].author + ", " + books[i].year);
                }
            }
        }
    }

    public class CWTask1
    {
        public static void Main(string[] args)
        {
            Book[] books =
            {   new Book("Стурктуры и алгоритмы", "Лафоре", 2020),
        new Book("Маленькие женщины", "Олкотт", 1868),
                    new Book("Руководство С#", "Иванов", 2021),
                    new Book("Руководство С+", "Эккель", 2023),
                    new Book("Интерфейсы", "Перов", 2019),
                    new Book("Геометрия и графика", "Лестенко", 2018),
                    new Book("Визуальное программирование", "Енин", 2022),
                    new Book("Трансляторы языков программирования", "Устиновкий", 2023),
                    new Book("Компьютерный практикум", "Скобеев", 2017),
                    new Book("Высшая математика", "Иванов", 2020)
                };

            Console.WriteLine("Вывод книг с автором Иванов:");
            Book.printInfoWithName(books, "Иванов");

            Console.WriteLine();

            Console.WriteLine("Вывод книг, написанных в 21 веке:");
            Book.printInfoWithAge(books, 21);

        }
    }
}
