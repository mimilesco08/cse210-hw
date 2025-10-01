using System;
using System.Collections.Generic;

class Program
{


    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>();

        var ref1 = new Reference("Proverbs", 3, 5, 6);
        var text1 = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways acknowledge him, and he will make your paths straight.";
        scriptures.Add(new Scripture(ref1, text1));

        var ref2 = new Reference("John", 3, 16);
        var text2 = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        scriptures.Add(new Scripture(ref2, text2));

        var rnd = new Random();
        var scripture = scriptures[rnd.Next(scriptures.Count)];

        const int hidePerEnter = 3;

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Press any key to exit.");
                Console.ReadKey();
                break;
            }

            Console.WriteLine();
            Console.Write("Press ENTER to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            scripture.HideWords(hidePerEnter);
        }
    }
}
