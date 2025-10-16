using System;

// GoalFactory.cs
// This factory makes goals from the string formats we saved. It's
// a tiny helper so LoadFromFile can create the right derived objects.

public static class GoalFactory
{
    public static Goal CreateFromString(string line)
    {
        // Each line is saved using the GetStringRepresentation format.
        // We split by '|' and inspect the first token to see the type.

        var parts = line.Split('|');
        if (parts.Length == 0)
            throw new ArgumentException("Invalid line for goal creation.");

        var type = parts[0];

        if (type == "Simple")
        {
            // Simple|title|description|points|isCompleted
            var title = parts[1];
            var desc = parts[2];
            var points = int.Parse(parts[3]);
            var isCompleted = bool.Parse(parts[4]);

            var g = new SimpleGoal(title, desc, points);
            if (isCompleted)
            {
                typeof(Goal).GetProperty("IsCompleted")!.SetValue(g, true);
            }
            return g;
        }
        else if (type == "Eternal")
        {
            // Eternal|title|description|points
            var title = parts[1];
            var desc = parts[2];
            var points = int.Parse(parts[3]);
            return new EternalGoal(title, desc, points);
        }
        else if (type == "Checklist")
        {
            // Checklist|title|description|points|required|bonus|timesCompleted|isCompleted
            var title = parts[1];
            var desc = parts[2];
            var points = int.Parse(parts[3]);
            var required = int.Parse(parts[4]);
            var bonus = int.Parse(parts[5]);
            var timesCompleted = int.Parse(parts[6]);
            var isCompleted = bool.Parse(parts[7]);

            var g = new ChecklistGoal(title, desc, points, required, bonus);
            g.SetTimesCompleted(timesCompleted);
            if (isCompleted)
            {
                typeof(Goal).GetProperty("IsCompleted")!.SetValue(g, true);
            }
            return g;
        }
        else
        {
            throw new ArgumentException($"Unknown goal type: {type}");
        }
    }
}
