using System;
using System.Linq;

struct Employee
{
    public string Name;
    public int EmployeeId;
    public int Age;
    public int HiringYear;
    public double Salary;

    public Employee(string name, int age, int hiringYear, double salary, int employeeId)
    {
        Name = name;
        Age = age;
        HiringYear = hiringYear;
        Salary = salary;
        EmployeeId = employeeId;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Табельный номер: {EmployeeId}");
        Console.WriteLine($"Имя: {Name}");
        Console.WriteLine($"Возраст: {Age}");
        Console.WriteLine($"Год приема: {HiringYear}");
        Console.WriteLine($"Зарплата: {Salary}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Employee[] employees = new Employee[5];
        employees[0] = new Employee("Иванов", 30, 2022, 50000, 1);
        employees[1] = new Employee("Петров", 25, 2021, 45000, 2);
        employees[2] = new Employee("Сидоров", 35, 2019, 60000, 3);
        employees[3] = new Employee("Козлов", 28, 2023, 48000, 4);
        employees[4] = new Employee("Петрова", 32, 2020, 55000, 5);

        var employeesAfter2020 = employees.Where(e => e.HiringYear > 2020).OrderBy(e => e.Name);

        Console.WriteLine("Сотрудники, устроенные после 2020:");
        foreach (var employee in employeesAfter2020)
        {
            employee.PrintInfo();
        }
    }
}
