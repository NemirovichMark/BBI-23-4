
//1.Студенты одной группы в сессию сдают четыре экзамена. Составить список
//студентов, средний балл которых по всем экзаменам не менее «4». Результаты
//вывести в виде таблицы с заголовком в порядке убывания среднего балла.

class Program
{
    struct tablica// структура
    {
        private string _name;
        private double[] _1ekz = new double[4];
        private double _AVG;
        public double AVG { get { return _AVG; } }// свойство
        public tablica(string name, double[] ekz)
        {
            _name = name;
            _1ekz = ekz;

            _AVG = 0;
            double sum = 0;
            for (int i = 0; i < _1ekz.Length; i++)
            {
                sum += _1ekz[i];
                if ((sum) / 4 >= 4)
                {
                    _AVG = sum / 4;
                }
            }
        }
        public void Print()
        {
            if (_AVG >= 4)
            {
                Console.WriteLine("{0},   {1}", _name, _AVG);
            }
        }
    }
    static void Main()
    {
        tablica[] results = new tablica[5];
        results[0] = new tablica("Sidorov", new double[] { 3, 4, 5, 2 });
        results[1] = new tablica("Petrov", new double[] { 2, 3, 4, 4 });
        results[2] = new tablica("Ivanov", new double[] { 5, 5, 4, 5 });
        results[3] = new tablica("Kostin", new double[] { 4, 4, 3, 5 });
        results[4] = new tablica("Smislov", new double[] { 4, 4, 4, 4 });
        sort(results);

        Console.WriteLine("Фамилия" + "   Средний бал");
        for (int i = 0; i < results.Length; i++)

        { results[i].Print(); }
    }
    static void sort(tablica[] results)
    {
        for (int i = 0; i < results.Length - 1; i++)
        {

            for (int j = i; j < results.Length; j++)
            {
                if (results[i].AVG < results[j].AVG)
                {
                    tablica all = results[j];
                    results[j] = results[i];
                    results[i] = all;
                }
            }
        }

    }
}