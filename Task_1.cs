// 3 задание
public class Appliance
{
    private string _brand;
    private int _power;

    public Appliance (string _brand, int _power)
    {
        Brand = brand;
        Power = power;
    }

    public string Brand
    {
        get {};
        set {_brand = name;}
    }

    public int Power
    {
        get {};
        set {_power = value;}
    }
    
    public class WashingMachine : Appliance
    {
        public WashingMachine(string _brand, int _power);
    }

    public class Refrigirator : Appliance
    {
        public Refrigirator(string _brand, int _power);
    }

    public class Microwave : Appliance
    {
        public Microwave(string _brand, int _power);
    }
}