// See https://aka.ms/new-console-template for more information

public class Program
{
    public struct Participant
    {
        private string surname;
        private int group;
        private string teachersurname;
        private double result;

        public Participant(string _surname, int _group, string _teachersurname, double _result)
        {
            surname = _surname;
            group = _group;
            teachersurname = _teachersurname;
            result = _result;
        }

        public string Surname { get { return surname; } }
        public int Group { get { return group; } }
        public string TeacherSurname { get { return teachersurname; } }
        public double Result { get { return result; } }

    }

    public static void Main(string[] args)
    {
        Participant[] person = new Participant[]
        {
            new Participant("Ivanova", 1, "Ivanov", 2),
            new Participant("Petrova", 2, "Petrov", 3),
            new Participant("Sidorova", 3, "Sidorov", 1) };

        for (int j = 0; j < person.Length - 1; j++)
        {
            if (person[j].Result > person[j + 1].Result)
            {
                var temp = person[j];
                person[j] = person[j + 1];
                person[j] = temp;
            }
        }

        int normative = 0;
        for (int i = 0; i < person.Length; i++)
        {
            string passed = "no";
            if (person[i].Result <= 2)
            {
                normative++;
                passed = "yes";
            }

            Console.WriteLine("Surname {0} \t Group {1} \t Teacher's Surname {0} \t Result{1:f1}", person[i].Surname, person[i].Group, person[i].TeacherSurname, person[i].Result);
        }
        Console.WriteLine($" {normative} women passed the normative");
    }
}
