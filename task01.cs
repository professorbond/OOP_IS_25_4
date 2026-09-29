using System.Dynamic;
// 7

class Transport
{
    string _model;
    int _year;

    public Transport(string model, int year)
    {
        _model = model;
        _year = year;
    }

    public string Model
    {
        get{ return _model;}
        set { _model = value; }        
    }

    public int Year
    {
        get{ return _year;}
        set { _year = value;}        
    }

    public virtual void move()
    {
        Console.WriteLine("Транспорт движется.");
    }
 
}

class Bus : Transport
{
    public Bus(string model, int year) : base ( model,  year) {}

    public override void move()
    {
        Console.WriteLine("Автобус едет.");
    }

    public void stop()
    {
        Console.WriteLine("Автобус останавливается.");
    }
}


class Train : Transport
{
    public Train(string model, int year) : base ( model,  year) {}

    public override void move()
    {
        Console.WriteLine("Поезд движется по рельсам.");
    }

    public void whistle()
    {
        Console.WriteLine("Поезд подает сигнал.");
    }
}

class Airplane : Transport
{
    public Airplane(string model, int year) : base ( model,  year) {}

    public override void move()
    {
        Console.WriteLine("Самолет летит в небе.");
    }

    public void fly()
    {
        Console.WriteLine("Самолет летит.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Test");
        Bus bus = new Bus("Yutong", 2025);
        Train train = new Train("Talgo", 2016);
        Airplane airplane = new Airplane("Pobeda", 2005);

        List<Transport> transports = new List<Transport>{bus, train, airplane};

        foreach (Transport transport in transports)
        {
            transport.move();
        }
    }
}