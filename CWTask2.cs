namespace ConsoleApp1
{

    public abstract class Book
    {
        private string name;
        private int ISBN;
        private string author;
        private int year;
        private int price;
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
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public virtual int PriceInfo()
        {
            return 100;
        }


        public static int Count
        {
            get { return count; }
            private set { count = value; }
        }

        public void printInfo()
        {
            Console.WriteLine(ISBN + ", " + name + ", " + author + ", " + year + ", " + price);
        }

        public static void printInfoWithName(Book[] books, string name)
        {
            for (int i = 0; i < books.Length; i++)
            {

                if (books[i].author.Equals(name))
                {
                    Console.WriteLine(books[i].ISBN + ", " + books[i].name + ", " + books[i].author + ", " + books[i].year + ", " + books[i].price);
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


    public class PaperBook : Book
    {
        private bool isHardCover;
        public PaperBook(string name, string author, int year, bool isHardCover) : base(name, author, year)
        {
            this.isHardCover = isHardCover;
            if (Year > 2000)
            {
                Price = 600;
            }
            else Price = 300;
        }
        public bool IsHardCover
        {
            get { return isHardCover; }
            private set { isHardCover = value; }
        }


        public override int PriceInfo()
        {
            if (Year > 2000)
            {
                return 600;
            }
            else return 300;
        }
    }

    public class ElectronicBook : Book
    {
        private string format;
        public ElectronicBook(string name, string author, int year, string format) : base(name, author, year)
        {
            this.format = format;
            if (Year > 2000)
            {
                Price = 600 / 2;
            }
            else Price = 300 / 2;
        }

        public override int PriceInfo()
        {
            if (Year > 2000)
            {
                return 600 / 2;
            }
            else return 300 / 2;
        }
    }

    public class AudioBook : Book
    {
        private bool isStudioRecording;
        public AudioBook(string name, string author, int year, bool isStudioRecording) : base(name, author, year)
        {
            this.isStudioRecording = isStudioRecording;
            if (Year > 2000)
            {
                Price = 600 / 3;
            }
            else Price = 300 / 3;
        }
        public bool IsStudioRecording
        {
            get { return isStudioRecording; }
            private set { isStudioRecording = value; }
        }


        public override int PriceInfo()
        {
            if (Year > 2000)
            {
                return 600 / 3;
            }
            else return 300 / 3;
        }
    }


    public class CWTask1
    {
        public static void Main(string[] args)
        {
            PaperBook[] bookP =
            {
                new PaperBook("Маленькие женщины", "Олкотт", 1990, true),
                new PaperBook("Интерфейсы", "Перов", 2010, true),
                new PaperBook("Маленькие женщины", "Олкотт", 1868, true),
                new PaperBook("Интерфейсы", "Перов", 2019, true),
                new PaperBook("Геометрия и графика", "Лестенко", 2018, false),

            };

            ElectronicBook[] bookE =
            {
                new ElectronicBook("Компьютерный практикум", "Скобеев", 2017, ".pdf"),
                new ElectronicBook("Стурктуры и алгоритмы", "Лафоре", 2020, ".pdf"),

                new ElectronicBook("Визуальное программирование", "Иванов", 2022, ".epub"),
                new ElectronicBook("Визуальное программирование", "Енин", 2022, ".epub"),
                new ElectronicBook("Визуальное программирование", "Иванов", 2022, "."),
            };

            AudioBook[] bookA =
            {

                new AudioBook("Геометрия и компьютерная графика", "Лестенко", 2021, true),
                new AudioBook("Помогите", "Малин", 2023, true),
                new AudioBook("Язык программирования", "Варион", 2020, true),
                new AudioBook("Компьютерный практикум", "Скобеев", 2017, false),
                new AudioBook("Высшая математика", "Иванов", 2020, true)
            };


            Console.WriteLine("Сортировка по цене печатных книг");
            SortArray(bookP);
            for (int i = 0; i < bookP.Length; i++)
            {
                bookP[i].printInfo();
            }

            Console.WriteLine("Сортировка по цене аудио книг");
            SortArray(bookA);
            for (int i = 0; i < bookA.Length; i++)
            {
                bookP[i].printInfo();
            }

            Console.WriteLine("Сортировка по цене электронных книг");
            SortArray(bookE);
            for (int i = 0; i < bookE.Length; i++)
            {
                bookP[i].printInfo();
            }

        }



        public static void SortArray(Book[] books)
        {
            for (int i = 0; i < books.Length - 1; i++)
            {
                for (int j = 0; j < books.Length - i - 1; j++)
                {
                    if (books[j].PriceInfo() > books[j + 1].PriceInfo())
                    {
                        var temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
        }
    }
}
