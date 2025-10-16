using System;

public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int length, double speed) : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // distance = speed * time / 60
        return _speed * GetLength() / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // pace = 60 / speed
        return 60 / _speed;
    }
}
