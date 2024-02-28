using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using _6th_lab;
struct Participant
{
    private string Surname;
    private int Group;
    private string TeacherSurname;
    private double Result;

    public Person(string surname, int group, string teachersurname, double result)
    {
        Surname = surname;
        Group = group;
        TeacherSurname = teachersurname;
        Result = result;
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Participant[] person = new Participant[3]
        {
            person[0] = new Participant ("Иванова", 1, "Иванов", 2.2);
        person[0] = new Participant("Петрова", 2, "Петров", 3);
        person[0] = new Participant("Сидорова", 3, "Сидоров", 1.5);
    }

    GnomSort(person);

    int normative = 0;
    for (int i=0; i<person.Length; i++)
    {
        string passed = "no";
        if (person[i].Result <= 2)
        {
            normative++;
            passed = "yes";
        }
        Console.WriteLine("Фамилия {0} \t Группа {1} \t Фамилия преподавателя {0} \t Результат{1:f1}", person[i].Surname, person[i].Group, person[i].TeacherSurname, person[i].Result);
    }
    Console.WriteLine($"\nКоличество участниц, выполнивших норматив: {normative}");
}
static void GnomSort(Participant[] arr)
{
    int index = 1;
    while (index < arr.Length)
    {
        if (index == 0 || arr[index - 1].Result <= arr[index].Result)
        {
            index++;
        }
        else
        {
            Participant temp = arr[index - 1];
            arr[index - 1] = arr[index];
            arr[index] = temp;
            index--;
        }
    }
}
