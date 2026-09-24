//3 вариант

private abstract class Appliance()
{
    private string _brand;
    private int _power;

    public Appliance(string brand, int power)
    {
        _brand = brand;
        _power = power;
    }

    public string Brand 
    {
        get => _brand;
        set => _brand = value;
    }
    public int Power
    {
        get => _power;
        set => _power = value;
    }

    public abstract void Operate();
}

public class WashingMachine() : Appliance
{
    public WashingMachine(string brand, int power) : base(brand, power) { }

    public void Wash()
    {
        Console.WriteLine("Стиральная машина стирает");
    }

    public override void Operate()
    {
        Console.WriteLine($"{brand} что то там происходит с Машинкой")
    }
}

public class Refrigerator() : Appliance
{
    public Refrigerator(string brand, int power) : base(brand, power) { }

    public void Cool()
    {
        Console.WriteLine("Холодильник охлаждает");
    }

    public override void Operate()
    {
        Console.WriteLine($"{brand} что то там происходит с холодосом")
    }
}

public class Microwave() : Appliance
{
    public Microwave(string brand, int power) : base(brand, power) { }

    public void Heat()
    {
        Console.WriteLine("Микроволновка разогревает еду");
    }

    public override void Operate()
    {
        Console.WriteLine($"{brand} что то там происходит с микроволновкой")
    }
}

class Program
{
    static void Main()
    {
        var washer = new WashingMachine("LGT-2007", 200);
        var micro = new Microwave("Samsung", 100);
        var holodos = new Refrigerator("LG", 300);

        washer.Wash();
        micro.Heat();
        holodos.Cool();

        List<Appliance> appliance = new List<Appliance>()
        {
            washer,
            micro,
            holodos
        }

        foreach(var shtucka in appliance)
        {
            shtucka.Operate();
        }
    }
}