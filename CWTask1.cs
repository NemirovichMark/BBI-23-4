using System;

struct SimpleDate
{
    public int Day { get; }
    public int Month { get; }
    public int Year { get; }

    public SimpleDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public bool IsLeapYear()
    {
        if ((Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0)
            return true;
        else
            return false;
    }

    public void DisplayDate()
    {
        Console.WriteLine($"{Day:D2}.{Month:D2}.{Year:D4}");
    }
}

class Program
{
    static void Main()
    {
        SimpleDate[] dates = new SimpleDate[10];
        dates[0] = new SimpleDate(1, 1, 2022);
        dates[1] = new SimpleDate(15, 3, 2023);
        dates[2] = new SimpleDate(28, 2, 2024);
        dates[3] = new SimpleDate(10, 7, 2020);
        dates[4] = new SimpleDate(5, 9, 2021);
        dates[5] = new SimpleDate(12, 12, 2019);
        dates[6] = new SimpleDate(4, 4, 2025);
        dates[7] = new SimpleDate(22, 6, 2026);
        dates[8] = new SimpleDate(8, 11, 2027);
        dates[9] = new SimpleDate(19, 10, 2028);

        Console.WriteLine("----- Dates Info -----");
        Console.WriteLine("Day    Month    Year    Leap Year?");
        Array.Sort(dates, (date1, date2) => date1.Year != date2.Year ? date1.Year.CompareTo(date2.Year) : (date1.Month != date2.Month ? date1.Month.CompareTo(date2.Month) : date1.Day.CompareTo(date2.Day)));
        foreach (var date in dates)
        {
            Console.Write($"{date.Day:D2}      {date.Month:D2}       {date.Year:D4}      ");
            Console.WriteLine(date.IsLeapYear() ? "Yes" : "No");
        }
    }
}
