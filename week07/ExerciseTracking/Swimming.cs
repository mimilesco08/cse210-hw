using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int length, int laps) : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Each lap is 50 meters, convert to miles
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        // speed = distance / time * 60
        return (GetDistance() / GetLength()) * 60;
    }

    public override double GetPace()
    {
        // pace = time / distance
        return GetLength() / GetDistance();
    }
}
