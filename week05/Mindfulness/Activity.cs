using System;
using System.Threading;

public abstract class Activity
{
    // Protected so derived classes can use them directly
    protected string _name;
    protected string _description;
    protected int _durationSeconds; // total duration for the activity

    private static readonly int _preparePauseSeconds = 3;
    private static readonly int _endingPauseSeconds = 3;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Common start routine: show name, description, ask for duration, prepare pause
    public virtual void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _durationSeconds = PromptDuration();
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        PauseWithDots(_preparePauseSeconds);
    }

    // Common end routine: congratulatory message that mentions the activity and duration
    public virtual void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        PauseWithDots(1);
        Console.WriteLine($"You have completed the {_name} for {_durationSeconds} seconds.");
        PauseWithDots(_endingPauseSeconds);
    }

    // Each specific activity implements its behavior
    public abstract void Run();

    // Utility: prompt for duration in seconds
    private int PromptDuration()
    {
        int seconds = 0;
        while (true)
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out seconds) && seconds > 0)
            {
                return seconds;
            }
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }

    // Pause showing a simple dots animation (e.g. "..." one per second)
    protected void PauseWithDots(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Spinner animation for a number of seconds
    protected void PauseWithSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int idx = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[idx]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            idx = (idx + 1) % spinner.Length;
        }
    }

    // Countdown from n to 1, showing each integer for one second (in place)
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Expose duration to derived classes
    protected int DurationSeconds => _durationSeconds;
}
