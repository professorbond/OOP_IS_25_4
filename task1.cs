class Vehicle 
{
	private int _speed { get; set; }
	private string _color { get; set; }

	public Vehicle(int speed, string color)
	{
		Speed = speed
		Color = color
	}

	public void SetSpeed() 
	public void SetColor()
	public void GetColor()
	public void GetSpeed()




	


}

class Car : Vehicle
{
	public void Drive()
	{
		Console.WriteLine("Машина едет")
	}
	public void Move()
	{
		Console.WriteLine("Машина двигается")
	}
}

class Bike : Vehicle
{
	public void Pedal()
	{
		Console.WriteLine("Велосипед крутит педали")
	}
	public void Move()
	{
		Console.WriteLine("Велосипед едет")
	}
}
class Boat : Vehicle
{
	public void Sail()
	{
		Console.WriteLine("Лодка плывет")
	}
	public void Move()
	{
		Concole.WriteLine("Лодка плывет")
}

Car car = new Car()
Bike bike = new Bike()
Boat boat = new Boat()


