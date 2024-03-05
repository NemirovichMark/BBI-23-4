//1.Результаты сессии содержат оценки 5 экзаменов по каждой группе. Определить
//средний балл для трех групп студентов одного потока и выдать список групп в
//порядке убывания среднего бала. Результаты вывести в виде таблицы с
//заголовком.
struct Student
{
    private double[] _1ekz = new double[5];
    private double _AVG;
    private string _name;
    public double AVG { get { return _AVG; } }
    public Student(string name, double[] ekz)
    {
        _name = name;
        _1ekz = ekz;
        double sum = 0;
        for (int i = 0; i < _1ekz.Length; i++)
        {
            sum += _1ekz[i];
        }
        _AVG = sum / 5;
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
        results1[0] = new Student("Sidorov", new double[] { 3, 4, 5, 5, 5 });
        results1[1] = new Student("Ivanov", new double[] { 4, 3, 5, 3, 4 });
        results1[2] = new Student("Petrov", new double[] { 5, 4, 5, 5, 3 });
        results1[3] = new Student("Kozlov", new double[] { 3, 3, 3, 5, 5 });
        results1[4] = new Student("Clinton", new double[] { 4, 4, 5, 5, 5 });
        double sum1 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum1 += results1[i].AVG / 5;
        }
        Student[] results2 = new Student[5];
        results2[0] = new Student("Trump", new double[] { 3, 5, 5, 5, 5 });
        results2[1] = new Student("Oblyakov", new double[] { 4, 3, 3, 3, 4 });
        results2[2] = new Student("Serzjov", new double[] { 5, 5, 2, 5, 4 });
        results2[3] = new Student("Lubov", new double[] { 3, 3, 3, 3, 5 });
        results2[4] = new Student("Krapivin", new double[] { 5, 5, 5, 5, 5 });


        double sum2 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum2 += results2[i].AVG / 5;
        }
        Student[] results3 = new Student[5];
        results3[0] = new Student("Joe", new double[] { 3, 4, 2, 5, 2 });
        results3[1] = new Student("Kotov", new double[] { 4, 3, 3, 3, 4 });
        results3[2] = new Student("Molokov", new double[] { 3, 5, 3, 5, 4 });
        results3[3] = new Student("Nepomnishii", new double[] { 3, 3, 3, 3, 5 });
        results3[4] = new Student("Testov", new double[] { 4, 2, 4, 3, 4 });
        double sum3 = 0;
        for (int i = 0; i < 5; i++)
        {
            sum3 += results3[i].AVG / 5;
        }
        Group avgs = new Group(sum1, sum2, sum3);
        avgs.Print();

    }

}
