using System;
using System.Collections.Generic;

class Device
{
    private string _name;
    private int _battery_life;

    public Device(string name, int battery_life)
    {
        _name = name;
        _battery_life = battery_life;
    }

    public string GetName() { return _name; }
    public int GetBatteryLife() { return _battery_life; }
    public void SetName(string name) { _name = name; }
    public void SetBatteryLife(int battery_life) { _battery_life = battery_life; }

    public virtual void Use()
    {
        Console.WriteLine("Устройство " + _name + " используется");
    }
}

class Smartphone : Device
{
    public Smartphone(string name, int battery_life) : base(name, battery_life) { }
    public void Call() { Console.WriteLine("Телефон звонит"); }
    public override void Use() { Call(); }
}

class Laptop : Device
{
    public Laptop(string name, int battery_life) : base(name, battery_life) { }
    public void CompileCode() { Console.WriteLine("Ноутбук компилирует код"); }
    public override void Use() { CompileCode(); }
}

class Tablet : Device
{
    public Tablet(string name, int battery_life) : base(name, battery_life) { }
    public void Raw() { Console.WriteLine("Планшет используется для рисования"); }
    public override void Use() { Raw(); }
}

class Program
{
    static void Main(string[] args)
    {
        List<Device> devices = new List<Device>();
        devices.Add(new Smartphone("iPhone", 15));
        devices.Add(new Laptop("Lenovo", 8));
        devices.Add(new Tablet("Samsung", 10));

        for (int i = 0; i < devices.Count; i++)
        {
            devices[i].Use();
        }

        Console.ReadKey();
    }
}