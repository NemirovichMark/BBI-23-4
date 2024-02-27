
//1.Студенты одной группы в сессию сдают четыре экзамена. Составить список
//студентов, средний балл которых по всем экзаменам не менее «4». Результаты
//вывести в виде таблицы с заголовком в порядке убывания среднего балла.

class Program
{
    struct tablica// структура
    {
        private string _name;
        private double _firstexam;
        private double _secondexam;
        private double _thirdexam;
        private double _fourthexam;
        private double _AVG;
        public double AVG { get { return _AVG; } set { _AVG = value; } }// свойство
        public tablica(string name, double firstexam, double secondexam, double thirdexam, double fourthexam)
        {
            _name = name;
            _firstexam = firstexam;
            _secondexam = secondexam;
            _thirdexam = thirdexam;
            _fourthexam = fourthexam;
            _AVG = 0;
            if ((firstexam + secondexam + thirdexam + fourthexam) / 4 >= 4)
            {
                _AVG = (firstexam + secondexam + thirdexam + fourthexam) / 4;
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
        results[0] = new tablica("Sidorov", 3, 4, 5, 2);
        results[1] = new tablica("Petrov", 2, 3, 4, 4);
        results[2] = new tablica("Ivanov", 5, 5, 4, 5);
        results[3] = new tablica("Kostin", 4, 4, 3, 5);
        results[4] = new tablica("Smislov", 4, 4, 4, 4);
        results = sort(results);

        Console.WriteLine("Фамилия" + "   Средний бал");
        for (int i = 0; i < results.Length; i++)

        { results[i].Print(); }
    }
    static tablica[] sort(tablica[] results)
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
        return results;
    }
}