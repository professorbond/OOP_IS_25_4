using System;

abstract class Shape
{
    public abstract double GetArea();

    public static double operator +(Shape first, Shape second)
    {
        return first.GetArea() + second.GetArea();
    }
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double GetArea()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}

class Program
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle();
        rectangle.Width = 4;
        rectangle.Height = 5;

        Circle circle = new Circle();
        circle.Radius = 3;

        Shape[] shapes = { rectangle, circle };

        Console.WriteLine("Площади фигур:");
        foreach (Shape shape in shapes)
            Console.WriteLine($"{shape.GetArea():F2}");

        double totalArea = rectangle + circle;
        Console.WriteLine($"Сумма площадей прямоугольника и круга: {totalArea:F2}");
    }
}
