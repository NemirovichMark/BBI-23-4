using System;
using System.Collections.Generic;

struct Answer
{
    private string _text;
    public int _counts;

    public string Text => _text;
    public int Count => _counts;

    public Answer(string text)
    {
        _text = text;
        _counts = 0;
    }
}

struct Question
{
    private string _text;
    private List<Answer> _answers;

    public string Text => _text;
    public List<Answer> Answers => _answers;

    public Question(string text)
    {
        _text = text;
        _answers = new List<Answer>();
    }

    public void AddAnswer(string answer)
    {
        Answer existingAnswer = _answers.Find(x => x.Text == answer);

        if (existingAnswer.Equals(default(Answer)))
        {
            _answers.Add(new Answer(answer));
        }
        else
        {
            existingAnswer._counts++;
        }
    }

    public List<Answer> GetTopAnswers(int n)
    {
        _answers.Sort((a, b) => b.Count.CompareTo(a.Count));
        return _answers.GetRange(0, n);
    }

}


class Program
{
    static void Main(string[] args)
    {

        Question[] questions = new Question[]
        {
            new Question("Quest1"),
            new Question("Quest2"),
            new Question("Quest3")
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

        Console.WriteLine("Results");
        Console.WriteLine("---------------------");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Question: {0}", questions[i].Text);
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