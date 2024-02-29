// Номер 3
// Радиокомпания провела опрос слушателей по вопросу: «Кого вы считаете
// человеком года?». Определить пять наиболее часто встречающихся ответов и их
// долей (в процентах от общего количества ответов).
struct Person
{
    private string _name;
    private int _calls;
    public double prop {get; private set;}
    public Person(string name, int calls, int count)
    {
        _name = name;
        _calls = calls;
        prop = (double) _calls * 100 / count;
    }
    public void Print()
    {
        Console.WriteLine("{0:f0} был выбран {1:f0} раз(а), доля от всех выбранных: {2:f3}%", _name, _calls, prop);
    }
}
class Program
{
    static void Main()
    { 
        string[] names = ["Petya", "Vanya", "Ruslan", "Vova", "Fedor", "Petya", "Petya", "Ruslan", "Fedor", "Sergei", "Max", "Max", "Petya"];
        string[] NamesSorted = new string[names.Length];  // массив с уникальными именами
        int[] NamesCalls = new int[names.Length]; // массив с количеством повторений этих имен
        int last = 0; 
        for (int i = 0; i < names.Length; i++)  // сортировка элементов в массиве по количеству повторяющихся элементов
        {
            if (InArray(names[i], NamesSorted) == -1)
            {
                NamesSorted[last] = names[i];
                NamesCalls[last] += 1;
                last++;
            }
            else NamesCalls[InArray(names[i], NamesSorted)] += 1;
        }

        int InArray(string name, string[] names)  // метод, позволяющий узнать, есть ли элемент в массиве
        {
            for (int i = 0; i < last; i++) if (names[i] == name)
                    return i;
            return -1;
        }

        Person[] people = new Person[NamesSorted.Length];
        for (int i = 0; i < NamesSorted.Length; i++) people[i] = new Person(NamesSorted[i], NamesCalls[i], names.Length); // преобразую полученные два массива в структуру

        static void Swap(Person[] array, int i, int j)
        {
            Person temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void GnomeSort(Person[] inArray) // гномья сортировка для структур
        {
            int i = 1;
            int j = 2;
            while (i < inArray.Length)
            {
                if (inArray[i - 1].prop < inArray[i].prop)
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    Swap(inArray, i - 1, i);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
        }

        GnomeSort(people);

        for (int i = people.Length - 1; i > people.Length - 6; i--)
        {
            people[i].Print();
        }
    }
}