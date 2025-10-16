// EternalGoal.cs
// Eternal goals never complete - you can record them repeatedly
// to get points every time (like read scriptures daily).

public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
        // EtErnal goals are never marked completed
    }

    public override string GetDisplayString()
    {
        return $"[ ] Eternal: {Title} ({Description}) - {Points} pts per time (repeatable)";
    }

    public override int RecordEvent()
    {
        // give points but never mark complete
        return Points;
    }

    public override string GetStringRepresentation()
    {
        // Format: Eternal|title|description|points
        return $"Eternal|{Title}|{Description}|{Points}";
    }
}
