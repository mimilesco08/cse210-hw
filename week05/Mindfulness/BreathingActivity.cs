using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Breath lengths (seconds). You can tune these or make them interactive later.
    private readonly int _inhaleSeconds = 4;
    private readonly int _exhaleSeconds = 6;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
    ) { }

    public override void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        bool inhale = true;

        while (DateTime.Now < endTime)
        {
            if (inhale)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                // show a small countdown for inhale
                Countdown(_inhaleSeconds);
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out... ");
                // exhale countdown
                Countdown(_exhaleSeconds);
            }

            inhale = !inhale;

            // If a short spinner between transitions will keep the UI lively (but not exceed end time)
            if (DateTime.Now < endTime)
            {
                Console.Write(" ");
                PauseWithSpinner(1);
            }
        }

        End();
    }
}
