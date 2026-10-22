

using System.Runtime.InteropServices;

///  10 ВАРИАНТ 

///1 Задание
class University
{
    public List<Department> Departments { get; } = new();
}

class Department
{
    public string Name { get; set; }
    public StudyPlan Plan { get; }

    public List<Teacher> Teachers { get; } = new();
    public List<Student> Students { get; } = new();

    public Department(string name)
    {
        Name = name;
        Plan = new StudyPlan();
    }
}

class StudyPlan { }

class Teacher
{
    public List<Department> Departments { get; } = new();
}

class Student
{
    public List<Department> Departments { get; } = new();
}


/// Второе задание 

abstract class Transport
{
    public int Speed { get; set; }

    public abstract void Move();
    public abstract void Stop();

    public static bool operator > (Transport a, Transport b)
    {
        return a.Speed > b.Speed;
    }

    public static bool operator < (Transport a, Transport b)
    {
        return a.Speed < b.Speed;
    }
}

class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine("Автомобиль движется");
    }

    public override void Stop()
    {
        Console.WriteLine("Автомобиль остановился");
    }
}

class Bicycle : Transport
{
    public override void Move()
    {
        Console.WriteLine("Велосипед движется");
    }

    public override void Stop()
    {
        Console.WriteLine("Велосипед остановился");
    }
}