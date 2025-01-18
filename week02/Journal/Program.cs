using System;

// I EXCEDED REQUIREMENTS BY ADDING A FEATURE THAT MAKES SURE THE USER DOESE'T EXIT WITHOUT CHOSING TO SAVE ANY ENTRY THAT WAS NOT SAVED.
// ALSO A DEFAULT JOURNAL.TXT TO SAVE THE USERS TIME IF THEY DON'T WANT TO SET A CUSTOM JOURNAL FILE
// A CODE BLOCK TO HANDLE INVALID ENTRIES 

class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;
        string filename = "journal.txt";  // Default filename for saving/loading

        while (running)
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            Console.WriteLine("1. Write in my journal");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Please select one of the following choices: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();  // Calls the method that includes random prompts
                    Console.WriteLine("\nEntry added successfully.");
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter filename to save to (default is journal.txt): ");
                    string saveFile = Console.ReadLine();
                    if (string.IsNullOrEmpty(saveFile))
                    {
                        saveFile = filename;
                    }
                    journal.SaveToFile(saveFile);
                    Console.WriteLine($"\nJournal saved successfully to {saveFile}.");
                    break;

                case "4":
                    Console.Write("Enter filename to load from (default is journal.txt): ");
                    string loadFile = Console.ReadLine();
                    if (string.IsNullOrEmpty(loadFile))
                    {
                        loadFile = filename;
                    }
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    if (journal.IsDirty)
                    {
                        Console.WriteLine("\nYou have unsaved changes. Would you like to save before quitting? (y/n)");
                        string saveChoice = Console.ReadLine();
                        if (saveChoice.ToLower() == "y")
                        {
                            Console.Write("Enter filename to save to (default is journal.txt): ");
                            string saveFileBeforeQuit = Console.ReadLine();
                            if (string.IsNullOrEmpty(saveFileBeforeQuit))
                            {
                                saveFileBeforeQuit = filename;
                            }
                            journal.SaveToFile(saveFileBeforeQuit);
                            Console.WriteLine($"Journal saved successfully to {saveFileBeforeQuit} before quitting.");
                        }
                    }
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
}
