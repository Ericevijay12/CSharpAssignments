using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create shapes
        var square = new Square("Red", 4);
        var rectangle = new Rectangle("Blue", 4, 6);
        var circle = new Circle("Green", 3);

        // List of shapes
        var shapes = new List<Shape> { square, rectangle, circle };

        // Display shape information
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}, Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}

abstract class Shape
{
    public string Color { get; private set; }

    protected Shape(string color)
    {
        Color = color;
    }

    public abstract double GetArea();
}

class Square : Shape
{
    public double Side { get; private set; }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }
}

class Rectangle : Shape
{
    public double Width { get; private set; }
    public double Height { get; private set; }

    public Rectangle(string color, double width, double height) : base(color)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea()
    {
        return Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; private set; }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}
