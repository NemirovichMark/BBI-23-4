
// 4 zadanie(1) 
struct sorevnovania
{


    private string _Surname;
    private int _besttry;
    private int _firsttry;
    private int _secondtry;

    public int Besttry { get { return _besttry; } set { _besttry = value; } }
    public sorevnovania(int firsttry, int secondtry, string surname)
    {
        _firsttry = firsttry;
        _secondtry = secondtry;
        _besttry = 0;
        _Surname = surname;

        if (firsttry > secondtry)
        {
            _besttry = firsttry;

        }
        else if (secondtry >= firsttry) { _besttry = secondtry; }
    }


    public void Print() => Console.WriteLine($"{_besttry}, {_Surname}");


}

class Program
{

    static void Main()

    {


        sorevnovania[] everything = new sorevnovania[5];

        everything[0] = new sorevnovania(155, 176, "Ivanov");
        everything[1] = new sorevnovania(180, 187, "Petrov");
        everything[2] = new sorevnovania(181, 191, "Sidorov");
        everything[3] = new sorevnovania(165, 186, "Ivanov");
        everything[4] = new sorevnovania(175, 171, "Ivanov");










        everything = sort(everything);
        for (int i = 0; i < everything.Length; i++)
        {
            everything[i].Print();
        }

    }

    static sorevnovania[] sort(sorevnovania[] everything)
    {
        for (int i = 0; i < everything.Length; i++)
        {

            for (int j = i; j < everything.Length - 1; j++)
            {
                if (everything[i].Besttry < everything[j].Besttry)
                {

                    sorevnovania results = everything[j];
                    everything[j] = everything[i];
                    everything[i] = results;

                }
            }



        }
        return everything;



    }
}

