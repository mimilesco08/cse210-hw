using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _rand = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }

    public override void Run()
    {
        Start();

        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine();

        // Give the user a short countdown to prepare
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item.");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);

        // Read lines until the time expires
        while (DateTime.Now < endTime)
        {
            // Check if there's less than 0.5 seconds left — if so, break to avoid blocking read
            if ((endTime - DateTime.Now).TotalMilliseconds < 500)
                break;

            // Set a small timeout mechanism: if the user takes too long to enter one item and we pass endTime, we stop.
            // Unfortunately Console.ReadLine blocks; to avoid complexity, we check remaining time before ReadLine.
            Console.Write("> ");
            // If remaining time is less than 1 sec, skip read
            int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
            if (remaining <= 0) break;

            // Read user input but ensure not to exceed the endTime. Guidance: user should press Enter.
            string input = ReadLineWithTimeout(endTime);
            if (input == null) break; // timeout reached
            input = input.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                items.Add(input);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} item(s).");
        if (items.Count > 0)
        {
            Console.WriteLine("Items:");
            foreach (var it in items)
            {
                Console.WriteLine($"- {it}");
            }
        }

        End();
    }

    // ReadLine that stops waiting after the given endTime; returns null if timeout reached
    private string ReadLineWithTimeout(DateTime endTime)
    {
        string result = "";
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return result;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (result.Length > 0)
                    {
                        // erase last char on console
                        Console.Write("\b \b");
                        result = result.Substring(0, result.Length - 1);
                    }
                }
                else
                {
                    Console.Write(key.KeyChar);
                    result += key.KeyChar;
                }
            }
            else
            {
                // small sleep to avoid busy loop
                Thread.Sleep(50);
            }
        }
        // Time expired
        Console.WriteLine();
        return null;
    }
}
