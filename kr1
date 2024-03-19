using System;

struct Book
{
    public string Title;
    public int ISBN;
    public string Author;
    public int Year;

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Year: {Year}\n");
    }
}

class Program
{
    static void Main()
    {
        Book[] books = new Book[10];

        books[0] = new Book { Title = "Book1", ISBN = 111, Author = "Author1", Year = 2000 };
        books[1] = new Book { Title = "Book2", ISBN = 222, Author = "Author2", Year = 2010 };
        books[2] = new Book { Title = "Book3", ISBN = 333, Author = "Author1", Year = 2020 };
        books[3] = new Book { Title = "Book4", ISBN = 444, Author = "Author3", Year = 2005 };
        books[4] = new Book { Title = "Book5", ISBN = 555, Author = "Author2", Year = 1998 };
        books[5] = new Book { Title = "Book6", ISBN = 666, Author = "Author4", Year = 2015 };
        books[6] = new Book { Title = "Book7", ISBN = 777, Author = "Author3", Year = 2008 };
        books[7] = new Book { Title = "Book8", ISBN = 888, Author = "Author1", Year = 2012 };
        books[8] = new Book { Title = "Book9", ISBN = 999, Author = "Author5", Year = 2003 };
        books[9] = new Book { Title = "Book10", ISBN = 1010, Author = "Author2", Year = 2018 };

        foreach (var book in books)
        {
            book.DisplayInfo();
        }

        Console.Write("Введите имя автора для поиска книг: ");
        string authorToSearch = Console.ReadLine();
        Console.WriteLine($"Книги автора {authorToSearch}:");
        foreach (var book in books)
        {
            if (book.Author == authorToSearch)
            {
                book.DisplayInfo();
            }
        }

        Console.Write("Введите век для поиска книг (например, 20 для XX века): ");
        int centuryToSearch = int.Parse(Console.ReadLine());
        Console.WriteLine($"Книги из века {centuryToSearch}:");
        foreach (var book in books)
        {
            if (book.Year / 100 == centuryToSearch)
            {
                book.DisplayInfo();
            }
        }
    }
}
