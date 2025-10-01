using System;

public class Fraction
{
    //Encapsulation
    private int _top;
    private int _bottom;

    // These are the Constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters and Setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int value)
    {
        _top = value;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int value)
    {
        _bottom = value;
    }

    // Method - return fraction as string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method - return decimal value
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
