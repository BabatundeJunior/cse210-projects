using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($" Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.Write("Enter duration (seconds) or press Enter for default (30s): ");
        string input = Console.ReadLine();
        _duration = string.IsNullOrEmpty(input) ? 30 : int.Parse(input);
        
        Console.WriteLine("\nGet ready...");
        ShowAnimation(3);
        Run();
        End();
    }

    protected void End()
    {
        Console.WriteLine($"\n Great job! You completed the {_name} Activity for {_duration} seconds.");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write($"{spinner[i % 4]} \r");
            Thread.Sleep(250);
        }
        Console.WriteLine();
    }

    public string GetName() => _name;
    public int GetDuration() => _duration;
    protected abstract void Run();
}