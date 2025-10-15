using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rand = new Random();

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    ) { }

    public override void Run()
    {
        Start();

        // Show a random prompt
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        // Give initial think time
        Console.Write("Take a moment to think");
        PauseWithDots(4);
        Console.WriteLine();

        // To reduce repeats (extra credit), we will shuffle questions and iterate
        var questionsShuffled = new List<string>(_questions);
        ShuffleList(questionsShuffled);

        int qIndex = 0;
        while (DateTime.Now < endTime)
        {
            // If we've used all questions, reshuffle and continue
            if (qIndex >= questionsShuffled.Count)
            {
                ShuffleList(questionsShuffled);
                qIndex = 0;
            }

            string q = questionsShuffled[qIndex++];
            Console.WriteLine();
            Console.WriteLine(q);

            // Pause with spinner for a short reflection period (3-6 sec depending on remaining time)
            int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
            int pause = Math.Min(6, Math.Max(2, remaining / 6)); // heuristic: smaller as time shrinks
            PauseWithSpinner(pause);
        }

        End();
    }

    // Fisher-Yates shuffle
    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = _rand.Next(i + 1);
            T tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
