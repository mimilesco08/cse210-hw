using System;

public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    // Abstract method for area — must be overridden by child classes
    public abstract double GetArea();
}
