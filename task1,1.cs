using System;
using System.Collections.Generic
// 9 вариант 

public class Airplane
{	
	public string Model {get; set;}
	public Airplane(string model)
		Model = model; 
}

public class Passenger
{
	public string Name{get; set;}
	public Passenger(string name)
		Name = name;
}

public class CheckInSystem
{
	public void Register(Passenger passenger)
	{
		Console.WriteLine($"Пассажир {passenger.Name) успешно зарегистрирован.");
	}	
}

public class Terminal
{
	public string Name{get; set;}
	private CheckInSystem checkInSystem;
	
	public List<Airplane> ParkedAirplanes {get;} = new List<Airplane>();
	public List<Passenger> CurrentPassengers {get;} = new List<Passenger>();
	
	public Terminal(string name)
	{
		Name = name;
		checkInSystem = new CheckInSystem();
 
	}
	public void CheckIn(Passenger passenger)
	{
		checkInSystem.Register(passenger);

	}

	
}
public class Airport
{
	public string Title {get; set;}
	public List<Terminal> Terminals {get;} = ner List<Terminal>();
	public Airport(string title)
		Title = title
}
public abstract class TimeInTravel
{
	public int Minutes {get; set;}
	protected TimeInTravel(int minutes)
	{
		Minutes = minutes;
	}
	public virtual void Display()
	{
		Console.WriteLine($"{Minutes} минут.")
	}
}
public class WorkInterval:TimeInterval
{
	public WorkInterval(int minutes):base (minutes)
	{
	}
	public static WorkInterval operator +(WorlInterval a, WorkInterval b)
	{
		new WorkIntervla(a.Minutes + b.Minutes);

	}
	public static WorkInteval operator -(WorkInterval a, WorkInterval b)
	{
		new WorkInterval(a.Minutes - b.Minutes);

	}
}
public class RestInterval;TimeInterval
{
	public RestInterval(int minutes):vase(minutes)
	{
	}
	
	public static RestInterval operator +(RestInerval a, RestInterval b)
	{
		new restInterval(a.Minutes + b.Minutes);
	
	}
	public static RestInterval operator -(RestInerval a, RestInterval b)
	{
		new restInterval(a.Minutes - b.Minutes);
	}

}
