using System;
public class Employee

{
    private string name;
    private double salary;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }
    public Employee(string name, double salary) // констуркутор класса
    {
        this.name = name;
        this.salary = salary;
    }

    public virtual void Work()
    {
        Console.WriteLine("Сотрудник работает");
    }
}

public class Teacher : Employee
{
    public Teacher(string name, double salary) : base(name, salary) { } // конструктор
    public void Teach()
    {
        Console.WriteLine("Учитель преподает");
    }

    public override void Work()
    {
        Console.WriteLine("Учитель работает");
    }
}
public class Programmer : Employee
{
    public Programmer(string name, double salary) : base(name, salary) { } // конструктор класса Programmer
    public void Code()
    {
        Console.WriteLine("Программист пишет код");
    }
    public override void Work()
    {
        Console.WriteLine("Программист работает");
    }
}


public class Doctor : Employee
{
    public Doctor(string name, double salary) : base(name, salary) { }// конструктор класса Doctor
    public void Treat()
    {
        Console.WriteLine("Врач лечит пациента");
    }
    public override void Work()
    {
        Console.WriteLine("Врач работает");
    }
}
