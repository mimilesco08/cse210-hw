using System;

// Goal.cs - base class for all goals.
// I put the shared fields and methods here so each goal type can use them.
// Member variables are private and accessed through properties when needed.

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;
    private bool _isCompleted;

    public string Title { get => _title; protected set => _title = value; }
    public string Description { get => _description; protected set => _description = value; }
    public int Points { get => _points; protected set => _points = value; }
    public bool IsCompleted { get => _isCompleted; protected set => _isCompleted = value; }

    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    // Display a single-line representation of the goal
    public abstract string GetDisplayString();

    // Record that the user performed the goal. Returns points earned for this record.
    public abstract int RecordEvent();

    // Serialize the goal into a string that can be saved to file.
    // Format should start with type so factory can create it.
    public abstract string GetStringRepresentation();
}
