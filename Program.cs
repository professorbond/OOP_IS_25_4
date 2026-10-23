using System;

//zadanie 2.

public interface ITaskble
{
    void Display();
}

public class DevelTask : ITaskble
{
    public string Title{get;set;}
    public int Hours{get;set;}

    public DevelTask(string title, int hrs)
    {
        Title = title;
        Hours = hrs;
    }

    public void Display()
    {
        Console.WriteLine($"{Title}: {Hours} hours");
    }

    public static DevelTask operator +(DevelTask a, DevelTask b)
    {
        return new DevelTask("plus vremya", a.Hours - b.Hours);
    }

}

public class DisgnTask : ITaskble
{
    public string Title{get;set;}
    public int Hours{get;set;}

    public DisgnTask(string title, int hours)
    {
        Title = title;
        Hours = hours;
    }

    public void Display()
    {
        Console.WriteLine($"{Title}: {Hours}");
    }

    public static DisgnTask operator >(DisgnTask a, DisgnTask b)
    {
        return new DisgnTask("bolshe v ", a.Hours / b.Hours);
    }
    public static DisgnTask operator <(DisgnTask a, DisgnTask b)
    {
        return new DisgnTask("menshe v  ",b.Hours / a.Hours);
    }
}


public class TaskProcessor
{
    public static void Process(ITaskble task)
    {
        task.Display();
    }
}

//zadanie 1.

public class Uchet
{
    public void Uchteno()
    {
        Console.WriteLine("uchteno");
    }
}

public class Korobka
{
    public string Name { get; set; }

    public Korobka(string name)
    {
        Name = name;
    }
}

public class Kurer
{
    public string Name { get; set; }

    public Kurer(string name)
    {
        Name = name;
    }

    public void DeliverKorobka(Korobka korobka)
    {
        Console.WriteLine("Dostavlena");
    }
}

public class Kladover
{
    public string Name { get; set; }

    public Kladover(string name)
    {
        Name = name;
    }

    public void Skladivat(Sklad sklad)
    {
        Console.WriteLine("skladivaet");
    }
}
// esli klad eto Treasure to kladovshik eto kto?

public class Sklad
{
    public int Number { get; set; }
    private Uchet _Uchet;
    public List<Korobka> korobkas { get; set; } = new List<Korobka>();

    public Sklad(int number)
    {
        Number = number;
        _Uchet = new Uchet(); // kompozisia
    }

    public void AddKorobka(Korobka korobka)
    {
        korobkas.Add(korobka);
        Console.WriteLine("dobavlena");
    }

}

partial class Program
{
    public static void Main()
    {
        Sklad sklad1 = new Sklad(1);
        Korobka korobka = new Korobka("soberi-robosobaku-konstruktor");
        sklad1.AddKorobka(korobka);

        Kladover kladover = new Kladover("Ivanchik");
        kladover.Skladivat(sklad1);

        Kurer kurer = new Kurer("Petrucho");
        kurer.DeliverKorobka(korobka);
        
        DevelTask dev1 = new DevelTask("qazwsx", 10);
        DevelTask dev2 = new DevelTask("yuuyyu", 25);
        DevelTask DevRes = dev1 + dev2;

        DisgnTask dis1 = new DisgnTask("ggvcvc",55);
        DisgnTask dis2 = new DisgnTask("hgddwk",45);
        DisgnTask DisRes = dis1 > dis2;

        TaskProcessor.Process(DevRes);
        TaskProcessor.Process(DisRes);

    }
}


