using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    // Private attributes
    private Reference _reference;
    private string _text;
    private List<Word> _words;
    private static readonly Random _rand = new Random();

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text ?? "";
        _words = new List<Word>();
        InitializeWords();
    }

    // Initialize Word objects
    private void InitializeWords()
    {
        var tokens = _text.Split(' ');
        foreach (var token in tokens)
        {
            _words.Add(new Word(token));
        }
    }

    // Display the scripture with the reference
    public void Display()
    {
        Console.WriteLine(_reference.GetReference());
        Console.WriteLine();
        Console.WriteLine(GetDisplayText());
    }

    // Build the displayed text from words
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.Display()));
    }

    public void HideWords(int count)
    {
        var availableIndices = _words
            .Select((w, i) => new { Word = w, Index = i })
            .Where(x => !x.Word.IsHidden() && x.Word.GetText().Any(char.IsLetter))
            .Select(x => x.Index)
            .ToList();

        if (availableIndices.Count == 0) return;

        int toHide = Math.Min(count, availableIndices.Count);

        for (int i = 0; i < toHide; i++)
        {
            int pickAt = _rand.Next(availableIndices.Count);
            int wordIndex = availableIndices[pickAt];

            _words[wordIndex].Hide();

            availableIndices.RemoveAt(pickAt);
        }
    }
    public bool IsCompletelyHidden()
    {
        return !_words.Any(w => !w.IsHidden() && w.GetText().Any(char.IsLetter));
    }
}
