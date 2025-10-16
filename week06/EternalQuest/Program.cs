using System;
using System.Collections.Generic;

// Program.cs
// This is my main program file for the Eternal Quest project.
// I wrote the menu and main loop. I also added a small leveling system so the
// user levels up every 1000 points.

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Score: {manager.Score}  |  Level: {manager.Level} (next at {manager.NextLevelThreshold} pts)");
            Console.WriteLine();
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event (mark goal done)");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice.Trim())
            {
                case "1":
                    CreateGoalMenu(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    Pause();
                    break;
                case "3":
                    RecordEventMenu(manager);
                    Pause();
                    break;
                case "4":
                    Console.Write("Enter filename to save (example: save.txt): ");
                    var saveFile = Console.ReadLine() ?? "save.txt";
                    try
                    {
                        manager.SaveToFile(saveFile);
                        Console.WriteLine($"Saved to {saveFile}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error saving: " + ex.Message);
                    }
                    Pause();
                    break;
                case "5":
                    Console.Write("Enter filename to load (example: save.txt): ");
                    var loadFile = Console.ReadLine() ?? "save.txt";
                    try
                    {
                        manager.LoadFromFile(loadFile);
                        Console.WriteLine($"Loaded from {loadFile}.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error loading: " + ex.Message);
                    }
                    Pause();
                    break;
                case "6":
                    Console.WriteLine($"Score: {manager.Score}");
                    Console.WriteLine($"Level: {manager.Level} (next at {manager.NextLevelThreshold} pts)");
                    Pause();
                    break;
                case "7":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        // A short goodbye line — simple.
        Console.WriteLine("Thanks for using Eternal Quest! Keep leveling up. :)");
    }

    static void CreateGoalMenu(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("Create Goal:");
        Console.WriteLine("1. Simple Goal (one-time)");
        Console.WriteLine("2. Eternal Goal (repeatable)");
        Console.WriteLine("3. Checklist Goal (complete N times)");
        Console.Write("Choose type: ");
        var type = Console.ReadLine() ?? "1";

        Console.Write("Enter title: ");
        var title = Console.ReadLine() ?? "";

        Console.Write("Enter description: ");
        var desc = Console.ReadLine() ?? "";

        Console.Write("Enter points awarded per event: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points. Using 0.");
            points = 0;
        }

        switch (type.Trim())
        {
            case "1":
                manager.AddGoal(new SimpleGoal(title, desc, points));
                Console.WriteLine("Simple goal created.");
                break;
            case "2":
                manager.AddGoal(new EternalGoal(title, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;
            case "3":
                Console.Write("Enter required completions (e.g., 5): ");
                if (!int.TryParse(Console.ReadLine(), out int required))
                {
                    Console.WriteLine("Invalid number. Using 1.");
                    required = 1;
                }
                Console.Write("Enter bonus points when checklist completes: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus. Using 0.");
                    bonus = 0;
                }
                manager.AddGoal(new ChecklistGoal(title, desc, points, required, bonus));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Unknown type - no goal created.");
                break;
        }
    }

    static void RecordEventMenu(GoalManager manager)
    {
        Console.Clear();
        Console.WriteLine("Record Event");
        manager.DisplayGoals();
        Console.Write("Enter the number of the goal you accomplished: ");
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        var earned = manager.RecordEvent(choice - 1);
        if (earned >= 0)
        {
            Console.WriteLine($"You earned {earned} points!");
        }
        else
        {
            Console.WriteLine("No points awarded (invalid goal index).");
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
