using System;

/// 7 вариант

abstract class Transport
{
    private string _model;
    private int _year;
    public string Model
    {
        get
        {
            return _model;
        }
        set
        {
            _model = value;
        }
    }

    public int Year
    {
        get
        {
            return _year;
        }
        set
        {
            if (Year < 2000)
            {
                Console.WriteLine("Старый транспорт");
            }
        }
    }

    public Transport(string model,  int year)
    {
        Model = model;
        Year = year;
    }

    public abstract void Move();

    public void DisplayInfo()
    {
        Console.WriteLine($"Модель {Model}");
        Console.WriteLine($"Год: {Year}");
    }

}

class Bus: Transport
{
    public Bus(string model, int year) : base(model, year)
    {

    }
 

    public override void Move()
    {
        Console.WriteLine("Автобус едет");

    }
    public void Stop()
    {
        Console.WriteLine("Автобус остановился");
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Модель {Model}");
        Console.WriteLine($"Год: {Year}");
    }
}

class Train: Transport
{
    public Train(string model, int year) : base(model, year)
    {

    }
    public override void Move()
    {
        Console.WriteLine("Поезд едет");
    }
    public void Whistle()
    {
        Console.WriteLine("Чучух");
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Модель {Model}");
        Console.WriteLine($"Год: {Year}");
    }

}

class Airplane: Transport
{
    public Airplane(string model, int year) : base(model, year)
    {

    }

    public override void Move()
    {
        Console.WriteLine("Полет нормальный");
    }
    public void Fly()
    {
        Console.WriteLine("Самолет летит");
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Модель {Model}");
        Console.WriteLine($"Год: {Year}");
    }
}

class Program
{
    static void Main()
    {
        Bus bus = new Bus("53", 2015);
        Train train = new Train("Астана", 1998);
        Airplane airplane = new Airplane("Авиасейлс", 2020);

        List<Transport> transports = new List<Transport>();
        transports.Add(bus);
        transports.Add(train);
        transports.Add(airplane);
        foreach (Transport transport in transports)
        {
            transport.DisplayInfo();
        }
        Console.ReadKey();
    }
}