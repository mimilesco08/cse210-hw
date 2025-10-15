using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option (1-4): ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    exit = true;
                    continue;
                default:
                    Console.WriteLine("Invalid selection. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            // Run chosen activity
            activity.Run();

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        Console.WriteLine("Goodbye! Stay mindful.");
    }
}

