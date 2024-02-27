//1.Результаты сессии содержат оценки 5 экзаменов по каждой группе. Определить
//средний балл для трех групп студентов одного потока и выдать список групп в
//порядке убывания среднего бала. Результаты вывести в виде таблицы с
//заголовком.
struct Student
{
    private double _1ekz;
    private double _2ekz;
    private double _3ekz;
    private double _4ekz;
    private double _5ekz;
    private double _AVG;
    private string _name;
    public double First { get { return _1ekz; } set { _1ekz = value; } }
    public double Second { get { return _2ekz; } set { _2ekz = value; } }
    public double Third { get { return _3ekz; } set { _3ekz = value; } }
    public double Fourth { get { return _4ekz; } set { _4ekz = value; } }
    public double Fifth { get { return _5ekz; } set { _5ekz = value; } }
    public double AVG { get { return _AVG; } set { _AVG = value; } }
    public Student(string name, double first, double second, double third, double fourth, double fifth)
    {
        _name = name;
        _1ekz = first;
        _2ekz = second;
        _3ekz = third;
        _4ekz = fourth;
        _5ekz = fifth;
        _AVG = 0;
    }
}
struct Group
{
    private double _bigavg1;
    private double _bigavg2;
    private double _bigavg3;
    private double[] _ALLAVG;
    public Group(double bigavg1, double bigavg2, double bigavg3)
    {
        _bigavg1 = bigavg1;
        _bigavg2 = bigavg2;
        _bigavg3 = bigavg3;
        _ALLAVG = new double[3] { bigavg1, bigavg2, bigavg3 };
        for (int i = 0; i < 2; i++)
        {
            double a = 0;
            for (int j = i; j < 3; j++)
            {
                if (_ALLAVG[j] > _ALLAVG[i])
                {
                    a = _ALLAVG[j];
                    _ALLAVG[j] = _ALLAVG[i];
                    _ALLAVG[i] = a;
                }
            }
        }
    }
    public void Print()
    {
        Console.Write("1 СР " + "2 СР" + " 3 СР");
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("{0,3:f} ", _ALLAVG[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        Student[] results1 = new Student[5];
        results1[0] = new Student("Sidorov", 3, 4, 5, 5, 5);
        results1[1] = new Student("Ivanov", 4, 3, 5, 3, 4);
        results1[2] = new Student("Petrov", 5, 4, 5, 5, 3);
        results1[3] = new Student("Kozlov", 3, 3, 3, 5, 5);
        results1[4] = new Student("Clinton", 4, 4, 5, 5, 5);
        for (int i = 0; i < results1.Length; i++)
        {
            results1[i].AVG += (results1[i].First + results1[i].Second + results1[i].Third + results1[i].Fourth + results1[i].Fifth) / 5;
        }
        double sum1 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum1 += results1[i].AVG / 5;
        }
        Student[] results2 = new Student[5];
        results2[0] = new Student("Trump", 3, 5, 5, 5, 5);
        results2[1] = new Student("Oblyakov", 4, 3, 3, 3, 4);
        results2[2] = new Student("Serzjov", 5, 5, 2, 5, 4);
        results2[3] = new Student("Lubov", 3, 3, 3, 3, 5);
        results2[4] = new Student("Krapivin", 5, 5, 5, 5, 5);
        for (int i = 0; i < results1.Length; i++)
        { results2[i].AVG += (results2[i].First + results2[i].Second + results2[i].Third + results2[i].Fourth + results2[i].Fifth) / 5; }
        double sum2 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum2 += results2[i].AVG / 5;
        }
        Student[] results3 = new Student[5];
        results3[0] = new Student("Joe", 3, 4, 2, 5, 2);
        results3[1] = new Student("Kotov", 4, 3, 3, 3, 4);
        results3[2] = new Student("Molokov", 3, 5, 3, 5, 4);
        results3[3] = new Student("Nepomnishii", 3, 3, 3, 3, 5);
        results3[4] = new Student("Testov", 4, 2, 4, 3, 4);
        for (int i = 0; i < results1.Length; i++)
        {
            results3[i].AVG += (results3[i].First + results3[i].Second + results3[i].Third + results3[i].Fourth + results3[i].Fifth) / 5;
        }
        double sum3 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum3 += results3[i].AVG / 5;
        }
        Group avgs = new Group(sum1, sum2, sum3);
        avgs.Print();

    }

}
