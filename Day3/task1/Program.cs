public class Shape(string name)
{
    public string Name { get; } = name;
    public virtual double CalculateArea()=>0;
    public override string ToString(){
        return $"Name: {Name} Area: {CalculateArea()}";
    }
}

public class Circle(double radius) : Shape("Circle")
{
    public double Radius { get; } = radius;

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // public override string ToString()
    // {
    //     return $"Name: {Name} Area: {CalculateArea()}";
    // }
}

public class Rectangle(double width, double height) : Shape("Rectangle")
{
    public double Width { get; } = width;
    public double Height { get; } = height;

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

public class Triangle(double _base, double height) : Shape("Triangle")
{
    public double Base { get; } = _base;
    public double Height { get; } = height;

    public override double CalculateArea()
    {
        return (Base * Height)/2;
    }
}

public class Program
{
    static private void PrintShapeArea(Shape shape)
    {
        Console.WriteLine(shape);
        // Console.WriteLine($"Name: {shape.Name} Area: {shape.CalculateArea()}");
    }
    public static void Main()
    {
        Circle circle = new(5);
        Rectangle rectangle = new(5, 10);
        Triangle triangle = new(5, 10);

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}