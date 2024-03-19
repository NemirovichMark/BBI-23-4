using System;

abstract class Animal
{
    public string Name { get; set; }
    public string DietType { get; set; }

    public abstract void MakeSound();

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Sound: ");
        MakeSound();
    }
}

class Giraffe : Animal
{
    public Giraffe()
    {
        Name = "Giraffe";
        DietType = "Herbivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Giraffe sound: *Giraffe noises*");
    }
}

class Pig : Animal
{
    public Pig()
    {
        Name = "Pig";
        DietType = "Omnivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Pig sound: *Oink oink*");
    }
}

class Elephant : Animal
{
    public Elephant()
    {
        Name = "Elephant";
        DietType = "Herbivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Elephant sound: *Trumpet*");
    }
}

class Lion : Animal
{
    public Lion()
    {
        Name = "Lion";
        DietType = "Carnivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Lion sound: *Roar*");
    }
}

class Tiger : Animal
{
    public Tiger()
    {
        Name = "Tiger";
        DietType = "Carnivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Tiger sound: *Roar*");
    }
}

class Monkey : Animal
{
    public Monkey()
    {
        Name = "Monkey";
        DietType = "Omnivore";
    }

    public override void MakeSound()
    {
        Console.WriteLine("Monkey sound: *Oo oo aa aa*");
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Giraffe(), new Giraffe(), new Giraffe(),
            new Pig(), new Pig(), new Pig(),
            new Elephant(), new Elephant(), new Elephant(),
            new Lion(), new Lion(), new Lion(),
            new Tiger(), new Tiger(), new Tiger(),
            new Monkey(), new Monkey(), new Monkey()
        };

        Console.WriteLine("----- Herbivores -----");
        DisplayAnimalsByDietType(animals, "Herbivore");

        Console.WriteLine("\n----- Carnivores -----");
        DisplayAnimalsByDietType(animals, "Carnivore");

        Console.WriteLine("\n----- Omnivores -----");
        DisplayAnimalsByDietType(animals, "Omnivore");
    }

    static void DisplayAnimalsByDietType(Animal[] animals, string dietType)
    {
        foreach (var animal in animals)
        {
            if (animal.DietType == dietType)
            {
                animal.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}
