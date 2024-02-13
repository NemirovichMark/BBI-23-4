struct sorevnovania
{

    
    private string _Surname;
    private int _besttry;
    private int _firsttry;
    private int _secondtry;
    public int Firsttry { get { return _firsttry; } set { _firsttry = value; } }
    public int Secondtry { get { return _secondtry; } set { _secondtry = value; } }

    public int Besttry { get { return _besttry; } set { _besttry = value; } }
    public sorevnovania (int firsttry, int secondtry, int besttry, string surname)
    {
        _firsttry = firsttry;
        _secondtry = secondtry;
        _besttry = besttry;
        _Surname = surname;
        if (firsttry>secondtry)
        {
            besttry = firsttry;

        }
        else if (secondtry>=firsttry) { besttry = secondtry; }
    }
    
    
    public void Print() => Console.WriteLine($"{_firsttry}, {_secondtry},{_besttry}, {_Surname}");
    //void Besttry(int besttry)
    //{
    //    for (int i = 0; i < 3; i++)
    //    {
    //        if (Firsttry>Secondtry){besttry = Firsttry;}
    //        else if ( Secondtry >= Firsttry) { besttry = Secondtry; }
    //        return;
    //    }

    //}
    

}

class Program
{

    static void Main()
    {
        sorevnovania[] everything = new sorevnovania[3];

        everything[0] = new sorevnovania(155, 176, 0,  "Ivanov");
        everything[1] = new sorevnovania(180, 187, 0, "Petrov");
        everything[2] = new sorevnovania(181, 191, 0, "Sidorov");
          void Besttry(int besttry)
        {
            for (int i =0; i<everything.Length; i++)
            {
                Console.WriteLine(everything[i].Besttry); 
            }

        }
      



    }
    
    
    
}
