//Вариант 10
using System;

interface IMovable
{
    public void Move();
    public void Stop();
}

class Car : IMovable
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Автомобиль движется");
    }

    public void Stop()
    {
        Console.WriteLine("Автомобиль остановился");
    }

    public bool operator >(Car carA, Car carB)
    {
        if (carA.Speed > carB.Speed) return true;
    }

}
class Bycicle  : IMovable
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Велосипед движется");
    }

    public void Stop()
    {
        Console.WriteLine("Велосипед остановился");
    }
}

class VechicleProcessor
{
    VechicleProc(IMovable movable)
    {
        movable.Move();
        movable.Stop();
    }
}