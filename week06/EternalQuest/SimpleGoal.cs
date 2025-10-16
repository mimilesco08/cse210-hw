// SimpleGoal.cs
// SimpleGoal is a one-time goal. When you record it once you get points
// and it becomes completed.

public class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override string GetDisplayString()
    {
        var mark = IsCompleted ? "[X]" : "[ ]";
        return $"{mark} Simple: {Title} ({Description}) - {Points} pts";
    }

    public override int RecordEvent()
    {
        if (IsCompleted)
        {
            // already done, no points
            return 0;
        }
        // mark complete and give points
        // protected setter in base:
        typeof(Goal).GetProperty("IsCompleted")!.SetValue(this, true);
        return Points;
    }

    public override string GetStringRepresentation()
    {
        // Format: Simple|title|description|points|isCompleted
        return $"Simple|{Title}|{Description}|{Points}|{IsCompleted}";
    }
}
