using System;

struct Series
{
    public string _name;
    public int _episodeLen;
    public string _descr;
    public bool _viewed;

    public Series(string name, int episodeLen)
    {
        _name = name;
        _episodeLen = episodeLen;
        _descr = "No description";
        _viewed = false;
    }

    public void AddDescr(string descr)
    {
        if ((descr.Length > 20) && (descr.Length < 200))
        {
            _descr = descr;
        }
        else
        {
            _descr="Wrong description";
        }
    }

    public void Watch()
    {
        _viewed = true;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {_name} Length: {_episodeLen} Description: {_descr} Viewed: {_viewed}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Series[] series = new Series[]
        {
            new Series("Breaking Bad", 55),
            new Series("The Sopranos", 60),
            new Series("The Wire", 45),
            new Series("Rick and Morty", 20),
            new Series("Better call saul", 50)
        };


        Array.Sort(series, (x, y) => string.Compare(x._name, y._name));

        foreach (Series i in series)
        {
            i.AddDescr("Its the best show of all time");
            i.Watch();
        }
        foreach (Series s in series)
        {
            s.PrintInfo();
        }
    }
}
