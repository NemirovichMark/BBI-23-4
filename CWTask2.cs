using System;
using System.Collections.Generic;


public abstract class Watching
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsWatched { get; set; }

    public Watching(string name)
    {
        Name = name;
        Description = $"No description for {Name}";
        IsWatched = false;
    }
}

public class Movie : Watching
{
    public int AgeRating { get; set; }
    public int Duration { get; set; }

    public Movie(string name, int ageRating, int duration) : base(name)
    {
        AgeRating = ageRating;
        Duration = duration;
    }
}
public class Series : Watching
{
    public int TotalSeasons { get; set; }

    public Series(string name, int totalSeasons) : base(name)
    {
        TotalSeasons = totalSeasons;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Watching> watchList = new List<Watching>
        {
            new Movie("Inception", 12, 148),
            new Movie("The Dark Knight", 14, 152),
            new Movie("Interstellar", 12, 169),
            new Movie("Avatar", 12, 162),
            new Movie("The Shawshank Redemption", 16, 142)
        };
        int mviews = 0;
        foreach (Watching item in watchList)
        {
            if ((item is Movie movie) && (mviews<3))
            {
                movie.IsWatched = true;
                mviews++;
            }
        }

        watchList.Add(new Series("Game of Thrones", 50));
        watchList.Add(new Series("Breaking Bad", 55));
        watchList.Add(new Series("Friends", 40));

        int sviews = 0;
        foreach (Watching item in watchList)
        {
            if ((sviews<2)&&(item is Series series) )
            {
                sviews=sviews+1;
                series.IsWatched = true;
                
            }
        }

        watchList = watchList.OrderBy(x => x.Name).ToList();

        Console.WriteLine("Name\t\t\tDescription\t\t\t\t\t\tIs Watched");
        

        foreach (Watching item in watchList)
        {
            if (item.IsWatched)
            {
                Console.WriteLine($"{item.Name}\t\t{item.Description}\t\t\t\t\t{item.IsWatched}");
            }
        }
    }
}
