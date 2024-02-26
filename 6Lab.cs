using System;
using System.Collections.Generic;

class Jumper
{
  public string Фамилия { get; set; }
  public string Общество { get; set; }
  public int Попытка1 { get; set; }
  public int Попытка2 { get; set; }
  public int Сумма { get; set; }

  public Jumper(string фамилия, string общество, int попытка1, int попытка2)
  {
    Фамилия = фамилия;
    Общество = общество;
    Попытка1 = попытка1;
    Попытка2 = попытка2;
    Сумма = попытка1 + попытка2;
  }
}

class Program
{
  static void Main(string[] args)
  {
    // Ввод данных
    List<Jumper> jumpers = new List<Jumper>();
    int n = int.Parse(Console.ReadLine());
    for (int i = 0; i < n; i++)
    {
      string[] input = Console.ReadLine().Split(' ');
      string фамилия = input[0];
      string общество = input[1];
      int попытка1 = int.Parse(input[2]);
      int попытка2 = int.Parse(input[3]);
      jumpers.Add(new Jumper(фамилия, общество, попытка1, попытка2));
    }

    // Сортировка по сумме
    jumpers.Sort((a, b) => b.Сумма.CompareTo(a.Сумма));

    // Вывод таблицы
    Console.WriteLine("Протокол соревнований по прыжкам в длину");
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("| Место | Фамилия | Общество | Попытка 1 | Попытка 2 | Сумма |");
    Console.WriteLine("-----------------------------------------");
    for (int i = 0; i < n; i++)
    {
      Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} |",
                        i + 1, jumpers[i].Фамилия, jumpers[i].Общество,
                        jumpers[i].Попытка1, jumpers[i].Попытка2, jumpers[i].Сумма);
    }
    Console.WriteLine("-----------------------------------------");
  }
}
