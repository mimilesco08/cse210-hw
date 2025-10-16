// ChecklistGoal.cs
// Checklist goals need multiple completions. Each time you do it you get points,
// and when you reach the required count you get a bonus and the goal is marked complete.

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _required;
    private int _bonus;

    public int TimesCompleted { get => _timesCompleted; private set => _timesCompleted = value; }
    public int Required { get => _required; private set => _required = value; }
    public int Bonus { get => _bonus; private set => _bonus = value; }

    public ChecklistGoal(string title, string description, int points, int required, int bonus)
        : base(title, description, points)
    {
        _required = required;
        _bonus = bonus;
        _timesCompleted = 0;
    }

    public override string GetDisplayString()
    {
        var mark = IsCompleted ? "[X]" : "[ ]";
        return $"{mark} Checklist: {Title} ({Description}) - {Points} pts each ({TimesCompleted}/{Required}) Bonus: {Bonus}";
    }

    public override int RecordEvent()
    {
        if (IsCompleted)
        {
            return 0;
        }

        TimesCompleted++;

        int totalEarned = Points;

        if (TimesCompleted >= Required)
        {
            // mark completed and add bonus
            typeof(Goal).GetProperty("IsCompleted")!.SetValue(this, true);
            totalEarned += Bonus;
        }

        return totalEarned;
    }

    public override string GetStringRepresentation()
    {
        // Format: Checklist|title|description|points|required|bonus|timesCompleted|isCompleted
        return $"Checklist|{Title}|{Description}|{Points}|{Required}|{Bonus}|{TimesCompleted}|{IsCompleted}";
    }

    // A helper method to rebuild object from string pieces might be used by factory.
    public void SetTimesCompleted(int times)
    {
        _timesCompleted = times;
        if (_timesCompleted >= _required)
        {
            typeof(Goal).GetProperty("IsCompleted")!.SetValue(this, true);
        }
    }
}
