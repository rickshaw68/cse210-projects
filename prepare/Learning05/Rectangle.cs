using System.Globalization;

public class Rectangle : Shape
{
    private double _side1;
    private double _side2;

    public Rectangle(double side1, double side2, string color) : base(color)
    {
        _side1 = side1;
        _side2 = side2;
    }

    public override double GetArea()
    {
        return _side1 * _side2;
    }
}