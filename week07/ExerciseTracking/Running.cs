using System;

public class Running : Activity
{
    private double _distance; // in miles

    public Running(string date, int length, double distance) : base(date, length)
    {
        _distance = distance;
    }

    // returns distance directly
    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        // speed = distance / time * 60
        return (_distance / GetLength()) * 60;
    }

    public override double GetPace()
    {
        // pace = time / distance
        return GetLength() / _distance;
    }
}
