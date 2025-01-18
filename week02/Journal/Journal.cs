using System;
using System.Collections.Generic;
using System.IO;

// EXCEEDED REQUIREMENTS ARE HIGHLITED IN THE PROGRAM.CS FILE 


public class Journal
{
    private List<Entry> _entries;
    private bool _isDirty; // for tracking unsaved changes

    // Set of random prompts
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        _isDirty = false;

        // Initializing set of prompts
        _prompts = new List<string>
        {
            "What are you grateful for today?",
            "Describe a memorable moment from your day.",
            "What is something you're excited about?",
            "What challenges did you face today?",
            "What made you smile today?",
            "What did you learn today?",
            "Write about a place you would love to visit.",
            "What are your goals for the next week?",
            "Reflect on a recent decision you made.",
            "What is something you wish you could change in your life?"
        };
    }

    public bool IsDirty
    {
        get { return _isDirty; }
    }

    // AddEntry method picks a random prompt from the list
    public void AddEntry()
    {
        Random random = new Random();
        // Picks a random prompt from the list
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("\nPrompt: " + prompt);

        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        Entry newEntry = new Entry(prompt, response, currentDate);
        _entries.Add(newEntry);
        _isDirty = true; // Marks as dirty when an entry is added
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                // Using a simple delimiter to store the entry (prompt, response, date)
                writer.WriteLine($"{entry._prompt}~|~{entry._response}~|~{entry._date:yyyy-MM-dd HH:mm:ss}");
            }
        }
        _isDirty = false; // Marks as clean after saving
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Error: The file does not exist.");
            Console.WriteLine("Would you like to create a new journal file? (y/n)");

            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                Console.WriteLine("Creating a new journal file...");
                // Creates an empty file if the user chooses 'y'
                File.Create(filename).Close();  // Create an empty file and close it
                _entries.Clear();  // Optionally clear existing entries (if any)
                _isDirty = false;  // Sets to clean state
                Console.WriteLine("New journal file created successfully.");
            }
            else
            {
                Console.WriteLine("Returning to the main menu.");
                return;  // Exit the method early, so we don't show the "Journal loaded successfully" message
            }
        }
        else
        {
            // If File exists, attempt to load its contents
            _entries.Clear(); // Clear the existing entries before loading new ones
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The journal file is empty.");
            }
            else
            {
                // Process each line and add entries to the _entries list
                foreach (string line in lines)
                {
                    string[] parts = line.Split("~|~");
                    if (parts.Length == 3)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        if (DateTime.TryParse(parts[2], out DateTime date))
                        {
                            Entry entry = new Entry(prompt, response, date);
                            _entries.Add(entry);
                        }
                    }
                }

                // After loading, check if any entries were added
                if (_entries.Count > 0)
                {
                    Console.WriteLine("Journal loaded successfully.");
                    DisplayEntries();  // Displays all loaded entries
                }
                else
                {
                    Console.WriteLine("The journal file has no valid entries.");
                }
            }
        }
    }

    public bool HasUnsavedChanges()
    {
        return _isDirty;
    }
}
