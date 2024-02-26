using System;
using System.Collections.Generic;

class Answer
{
    public string Text { get; set; }
    public int Count { get; set; }

    public Answer(string text)
    {
        Text = text;
        Count = 0;
    }
}

class Question
{
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }

    public Question(string text)
    {
        Text = text;
        Answers = new List<Answer>();
    }

    public void AddAnswer(string answer)
    {
        Answer existingAnswer = Answers.Find(x => x.Text == answer);

        if (existingAnswer == null)
        {
            Answers.Add(new Answer(answer));
        }
        else
        {
            existingAnswer.Count++;
        }
    }

    public List<Answer> GetTopAnswers(int n)
    {
        Answers.Sort((a, b) => b.Count.CompareTo(a.Count));


        return Answers.GetRange(0, n);
    }
}

class Program
{
    static void Main(string[] args)
    {

        Question[] questions = new Question[]
        {
            new Question("����� �������� �� ���������� � ������� � ��������?"),
            new Question("����� ����� ��������� ������� ������� ������ �����?"),
            new Question("����� �������������� ������� ��� ������� �� ���������� � �������?")
        };


        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                string answer = Console.ReadLine();
                questions[j].AddAnswer(answer);
            }
        }

        Console.WriteLine("���������� ������");
        Console.WriteLine("---------------------");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("������: {0}", questions[i].Text);
            Console.WriteLine("---------------------");
            List<Answer> topAnswers = questions[i].GetTopAnswers(5);
            for (int j = 0; j < topAnswers.Count; j++)
            {
                double percentage = (double)topAnswers[j].Count / n * 100;
                Console.WriteLine("{0} ({1:F2}%)", topAnswers[j].Text, percentage);
            }
            Console.WriteLine();
        }
    }
}


