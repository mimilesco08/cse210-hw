using System;

// GoalManager.cs
// This class stores the list of goals and the player's score.
// It handles saving/loading, displaying goals, and recording events.
// I kept member vars private and used methods to access behavior.

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public int Score { get => _score; private set => _score = value; }

    // Creativity feature: leveling - every 1000 points increases level
    public int Level
    {
        get => (Score / 1000) + 1;
    }

    public int NextLevelThreshold
    {
        get => (Level * 1000);
    }

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    // Record an event for the goal at index. Returns points earned or -1 for invalid index.
    public int RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
            return -1;

        var earned = _goals[index].RecordEvent();
        Score += earned;
        return earned;
    }

    // Save all goals and score to a file. Format:
    // First line: Score:1234
    // Then each goal on its own line using GetStringRepresentation().
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Score:{Score}");
            foreach (var g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    // Load goals and score from a file created by SaveToFile.
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException("Save file not found.");

        var lines = File.ReadAllLines(filename);
        _goals.Clear();
        foreach (var line in lines)
        {
            if (line.StartsWith("Score:"))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int s))
                {
                    Score = s;
                }
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                var g = GoalFactory.CreateFromString(line);
                _goals.Add(g);
            }
        }
    }
}
