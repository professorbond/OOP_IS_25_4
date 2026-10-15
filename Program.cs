
using System;
using System.Collections.Generic;

class Employee
{
    string _name;
    double _salary;

    public void set_name(string name)
    {
        _name = name;
    }

    public void set_salary(double salary)
    {
        _salary = salary;
    }

    public string get_name()
    {
        return _name;
    }

    public double get_salary()
    {
        return _salary;
    }

    public virtual void work()
    {
        Console.WriteLine("Сотрудник работает.");
    }
}

class Teacher : Employee
{
    public void teach()
    {
        Console.WriteLine("Учитель преподаёт.");
    }

    public override void work()
    {
        Console.WriteLine("Учитель работает.");
    }
}

class Programmer : Employee
{
    public void code()
    {
        Console.WriteLine("Программист пишет код.");
    }

    public override void work()
    {
        Console.WriteLine("Программист работает.");
    }
}

class Doctor : Employee
{
    public void treat()
    {
        Console.WriteLine("Врач лечит пациента.");
    }

    public override void work()
    {
        Console.WriteLine("Врач работает.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Test");

        Teacher teacher = new Teacher();
        Programmer programmer = new Programmer();
        Doctor doctor = new Doctor();

        List<Employee> employees = new List<Employee>
        {
            teacher, programmer, doctor
        };

        foreach (Employee employee in employees)
        {
            employee.work();
        }
    }
}

