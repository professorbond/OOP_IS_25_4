using System;
public class Fruit

{
    private string _name; 
    private string _taste;  

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Taste
    {
        get { return _taste; }
        set { _taste = value; }
    }
    public Fruit(string name, string taste) // констуркутор класса
    {
        _name = name;
        _taste = taste;
    }
}

public class Apple : Fruit
{
    public Apple(string taste) : base("Apple", taste) {} // конструктор 
    public void crunch()
    {
        Console.WriteLine("Яблоко хрустит");
    }
}

public class Orange : Fruit
{
    public Orange(string taste) : base("Orange", taste) {}// конструктор класса Orange
    public void peel()
    {    
    Console.WriteLine("Апельсин очищается");
    }
}

public class Banana : Fruit
{
    public Banana(string taste) : base("Banana", taste) {}// конструктор класса Banana
    public void peel()
    {    
        Console.WriteLine("Банан очищается");
    }
}

class Program
{
    static void Main()
    {
        Apple apple = new Apple("Сладкое");
        apple.Crunch();

        Orange orange = new Orange("Кислый");
        orange.Peel();

        Banana banana = new Banana("Сладкий");
        banana.Peel();
    }
}