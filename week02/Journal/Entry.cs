using System;

public class Entry
{
    public string _date;
    public string _promtText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promtText}");
        Console.WriteLine($"Response: {_entryText}\n");
    }
}
