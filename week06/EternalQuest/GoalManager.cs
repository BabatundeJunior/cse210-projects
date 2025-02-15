using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals;
    private int _totalScore;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalScore = 0;
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid input for points.");
            return;
        }

        Console.WriteLine("Select goal type: 1. Simple  2. Eternal  3. Checklist");
        if (!int.TryParse(Console.ReadLine(), out int type))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid input for target count.");
                    return;
                }
                Console.Write("Enter bonus points: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid input for bonus points.");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    public void RecordGoal()
    {
        ShowGoals();
        Console.Write("Enter goal number to record progress: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            _totalScore += _goals[index - 1].Points;
            _goals[index - 1].RecordEvent();
            Console.WriteLine($"Updated score: {_totalScore}");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid goal number.");
        }
    }

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name}");
        }
        Console.WriteLine($"Total Score: {_totalScore}");
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_totalScore);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.SaveFormat());
            }
        }
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            _goals.Clear();
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                if (!int.TryParse(reader.ReadLine(), out _totalScore)) _totalScore = 0;

                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(',');
                    if (data.Length < 3) continue; // Skip malformed lines

                    switch (data[0])
                    {
                        case "Simple":
                            _goals.Add(new SimpleGoal(data[1], int.Parse(data[2])));
                            break;
                        case "Eternal":
                            _goals.Add(new EternalGoal(data[1], int.Parse(data[2])));
                            break;
                        case "Checklist":
                            if (data.Length >= 5)
                                _goals.Add(new ChecklistGoal(data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4])));
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}