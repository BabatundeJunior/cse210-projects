// EXCEEDING REQUIREMENTS:
// Activity Logging Feature: 
//    - Logs each completed activity with a timestamp.
//    - Saves logs to 'ActivityLog.txt' for persistence across sessions.

// Activity History Viewing:
//    - Users can view past activities within the program.
//    - Enhances user engagement by allowing self-reflection on previous sessions.

// Improved User Interaction:
//    - Handles invalid inputs gracefully.
//    - Users can navigate without restarting after an invalid selection.

// Code Efficiency & Maintainability:
//    - Uses a helper method (RunActivity()) to reduce code repetition.
//    - Logs are loaded and saved automatically for a seamless user experience.

// My txt file is created in the bin\debug\net8.0

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static List<string> activityLog = new List<string>(); // Store completed activities
    const string logFile = "ActivityLog.txt"; // File to save logs

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        LoadActivityLog(); // Load previous logs

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity());
                    break;
                case "2":
                    RunActivity(new ReflectionActivity());
                    break;
                case "3":
                    RunActivity(new ListingActivity());
                    break;
                case "4":
                    ViewActivityLog();
                    break;
                case "5":
                    SaveActivityLog();
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void RunActivity(Activity activity)
    {
        activity.Start();
        string logEntry = $"{DateTime.Now}: Completed {activity.GetName()} for {activity.GetDuration()} seconds.";
        activityLog.Add(logEntry);
    }

    static void ViewActivityLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log:\n");
        if (activityLog.Count == 0)
        {
            Console.WriteLine("No activities logged yet.");
        }
        else
        {
            foreach (var entry in activityLog)
            {
                Console.WriteLine(entry);
            }
        }
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }

    static void SaveActivityLog()
    {
        File.WriteAllLines(logFile, activityLog);
        Console.WriteLine("\nActivity log saved.");
    }

    static void LoadActivityLog()
    {
        if (File.Exists(logFile))
        {
            activityLog = new List<string>(File.ReadAllLines(logFile));
        }
    }
}