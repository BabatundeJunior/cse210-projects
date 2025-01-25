using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
  
// To Exceed Requirements I Added An Option for the user to either memorize from a random scripture or enter
// a custom scrupture to memorize. I added a scripture.txt file in the bin\Debug\net8.0 to load random scriptural verse from the file, I tried 
// puting it in the same folder as the program but looks like it dosen't see it there, had to move it to the net8.0 folder

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi there it's a beautiful day to memorize a scripture and draw near to the saviour!");
        Console.WriteLine("Would you like to (1) memorize a random scripture or (2) enter your own scripture? Enter a number 1 or 2");
        string choice = Console.ReadLine();

        Scripture scripture;
        if (choice == "1")
        {
            scripture = LoadRandomScripture("scripture.txt");
        }
        else
        {
            Console.Write("Enter scripture reference (e.g., John 3:16): ");
            string referenceInput = Console.ReadLine();
            Reference reference = ParseReference(referenceInput);
            
            Console.Write("Enter the scripture verse: ");
            string text = Console.ReadLine();
            scripture = new Scripture(reference, text);
        }

        while (!scripture.AllWordsHidden())
        {
            Console.Clear(); // To clear the console and give a clear space for the user
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(2);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nGreat Job! Think about the scripture verse and apply it in today's activities.");
    }

    static Scripture LoadRandomScripture(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Random random = new Random();
        string randomLine = lines[random.Next(lines.Length)];
        string[] parts = randomLine.Split('|');
        Reference reference = ParseReference(parts[0]);
        return new Scripture(reference, parts[1]);
    }

    static Reference ParseReference(string reference)
    {
        string[] parts = reference.Split(' ');
        string book = parts[0];
        string[] chapterAndVerses = parts[1].Split(':');
        int chapter = int.Parse(chapterAndVerses[0]);

        string[] verses = chapterAndVerses[1].Split('-');
        int startVerse = int.Parse(verses[0]);
        int? endVerse = verses.Length > 1 ? int.Parse(verses[1]) : (int?)null;

        return endVerse == null ? new Reference(book, chapter, startVerse) : new Reference(book, chapter, startVerse, endVerse.Value);
        // used ternary operator to write the if-else statement.
    }
}

class Reference
{
    public string Book { get; private set; }
    public int StartChapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        StartChapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {StartChapter}:{StartVerse}" : $"{Book} {StartChapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words);
        return $"{_reference}\n{scriptureText}";
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}