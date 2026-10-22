using System;
using System.Collections.Generic;
// 9 нуска
public class Passanger   //ytpfdbcbvst gfcf;bhs
{
    public string Name { get; set; }
    public Passanger(string name)
    {
        Name = name;
    }
}

public class Airplane //ytpfdbcbvsq cfvjktn
{
    public string Model { get; set; }
    public Airplane(string model)
    {
        Model = model;
    }
}
public class Registration   //cbcntvf htubcnhfwbb
{
    public string TerminalName {get;}
    public Registration(string terminalName)
    {
        TerminalName = terminalName;
    }

    public void RegisterPassenger(Passanger passenger)
    {
        Console.WriteLine($"Passenger {passenger.Name} зарегистрирован в системе терминаа {TerminalName}.");
    }

}

public class Terminal   //nthvbyfk
{
    public string Name { get; set; }
    public Registration Registration { get;}
    public List<Airplane> ServicedAirplanes { get;} = new List<Airplane>();

    public Terminal(string name)
    {
        Name = name;
        Registration = new Registration(name);
    }
}

//F'hjgjhn
public class Airport
{
    public string Name {get; set;}
    public List<Terminal> Terminals {get;} = new List<Terminal>();

    public Airport(string name)
    {
        Name = name;
    } 
}



public interface ITimeInterval
    {
        int Minutes { get; set; }
        void Display();
    }

public abstract class TimeInterval : ITimeInterval
{
    public int Minutes { get; set; }

    protected TimeInterval(int minutes)
    {
        Minutes = minutes;
    }

    public virtual void Display()
    {
        Console.WriteLine($"{Minutes} минут");
    }

public static T operator +(TimeInterval a, TimeInterval b)
    {
        if (a.GetType() != b.GetType())
            throw new InvalidOperationException("Нельзя складывать интервалы разных типов.");

        int totalMinutes = a.Minutes + b.Minutes;
        return (T)Activator.CreateInstance(a.GetType(), totalMinutes);
    }

public static T operator -(TimeInterval a, TimeInterval b)
    {
        if (a.GetType() != b.GetType())
            throw new InvalidOperationException("Нельзя вычитать интервалы разных типов.");

        int diffMinutes = Math.Max(0, a.Minutes - b.Minutes);
        return (T)Activator.CreateInstance(a.GetType(), diffMinutes);
    }
}
public class WorkInterval : TimeInterval
    {
        public WorkInterval(int minutes) : base(minutes) { }

        public override void Display()
        {
            Console.Write("[Рабочий интервал] ");
            base.Display();
        }
    }

public class RestInterval : TimeInterval
    {
        public RestInterval(int minutes) : base(minutes) { }

        public override void Display()
        {
            Console.Write("[Интервал отдыха]  ");
            base.Display();
        }
    }
//nxr d[jlf
internal class Program
{
    static void Main()
    {
        // --- Задача 1 ---
        var airport = new Airport("Шереметьево");
        var terminal = new Terminal("Терминал A");
        var plane = new Airplane("Boeing 737");
        var passenger = new Passenger("Алина");

        airport.Terminals.Add(terminal);
        terminal.Airplanes.Add(plane);
        terminal.Registration.RegisterPassenger(passenger);

        Console.WriteLine();

        // --- Задача 2 ---
        // 1. Общий интерфейс
        ITimeInterval[] intervals = { new WorkInterval(90), new RestInterval(15) };
        foreach (var interval in intervals)
        {
            interval.Display();
        }

        // 2. Перегрузка операторов
        var w1 = new WorkInterval(120);
        var w2 = new WorkInterval(60);

        WorkInterval sum = w1 + w2;
        WorkInterval diff = w1 - w2;

        Console.Write("Сумма: ");
        sum.Display();
        Console.Write("Разность: ");
        diff.Display();
    }
}
