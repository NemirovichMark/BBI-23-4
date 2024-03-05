// Задача 3.6
// Японская радиокомпания провела опрос радиослушателей по трем вопросам:
// а). Какое животное Вы связываете с Японией и японцами?
// б). Какая черта характера присуща японцам больше всего?
// в). Какой неодушевленный предмет или понятие Вы связываете с Японией?
// Большинство опрошенных прислали ответы на все или часть вопросов.
// Составить программу получения первых пяти наиболее часто встречающихся
// ответов по каждому вопросу и доли (в %) каждого такого ответа.
// Предусмотреть необходимость сжатия столбца ответов в случае отсутствия
// ответов на некоторые вопросы.

class Program
{
    struct Answer
    {
        private string answer;
        private int calls;
        public double prop {get; private set;}

        public Answer(string _answer, int _calls, int count)
        {
            answer = _answer;
            calls = _calls;
            prop = (double) calls * 100 / count;
        }
        public void Print()
        {
            Console.WriteLine(" Ответ '{0}' был выбран {1} раз(а), доля от всех ответов: {2:f1}%", answer, calls, prop);
        }
    }

    static void SortMatrix(Answer[,] a)
        {
            for (int k = 0; k < a.GetLength(0); k++)
                for (int i = 1; i < a.GetLength(1); i++)
                    {
                        Answer q = a[k, i];
                        int j = i - 1;

                        while(j >= 0 && a[k, j].prop < q.prop)
                        {
                            a[k, j + 1] = a[k, j];
                            j--;
                        }
                        a[k, j + 1] = q;
                    }
        }
    static void Main()
    {
        string[,] answers = // каждый столбец - ответы одного опрошенного на все три вопроса
        {
            { "Панда",   "Панда",   "-",              "Лошадь", "Панда",        "Собака",    "Собака",   "Игуана", "Голубь",       "-" },
            { "Доброта", "Доброта", "Чистоплотность", "-",      "Аккуратность", "Честность", "Гордость", "-",      "Аккуратность", "Гордость" },
            { "Мир",     "Красота", "-",              "Страна", "Мир",          "Аниме",     "Роллы",    "Роллы",  "Роллы",        "-" }
        };
        Answer[,] total = new Answer[3, answers.GetLength(1)];
        int last, count;
        for (int k = 0; k < 3; k++)
        {
            string[] AnswersSorted = new string[answers.GetLength(1)];  
            int[] AnswersCalls = new int[answers.GetLength(1)]; 
            last = 0; count = 0;
            for (int i = 0; i < answers.GetLength(1); i++)  
                if (answers[k,i] != "-")
                {
                    if (InArray(answers[k,i], AnswersSorted) == -1)
                    {
                        AnswersSorted[last] = answers[k,i];
                        AnswersCalls[last] += 1;
                        last++;
                    }
                    else AnswersCalls[InArray(answers[k,i], AnswersSorted)] += 1;
                    count++;
                }
            for (int i = 0; i < AnswersSorted.Length; i++) total[k, i] = new Answer(AnswersSorted[i], AnswersCalls[i], count);
        }

        int InArray(string answer, string[] answers)  // метод, позволяющий узнать, есть ли элемент в массиве
        {
            for (int i = 0; i < last; i++) if (answers[i] == answer)
                    return i;
            return -1;
        }

        SortMatrix(total);

        for (int k = 0; k < 3; k++)
        {
            Console.WriteLine("5 наиболее часто встречающихся ответов на {0} вопрос:", k + 1);
            for (int i = 0; i < 5; i++) total[k,i].Print();
            Console.WriteLine();
        }
    }
}