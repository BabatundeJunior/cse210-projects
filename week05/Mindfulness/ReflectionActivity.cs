using System;
using System.Collections.Generic;
using System.Threading;

class ReflectionActivity : Activity
{
    private static Random _rand = new Random();
    private static List<string> usedPrompts = new List<string>();

    private string[] _prompts =
    {
        "Think about a time when you felt truly happy.",
        "Reflect on a challenge you overcame.",
        "Remember a moment you felt gratitude."
    };

    public ReflectionActivity() : base("Reflection", "Reflect on positive past experiences.") { }

    protected override void Run()
    {
        string prompt;
        do
        {
            prompt = _prompts[_rand.Next(_prompts.Length)];
        } while (usedPrompts.Contains(prompt) && usedPrompts.Count < _prompts.Length);

        usedPrompts.Add(prompt);
        if (usedPrompts.Count >= _prompts.Length) usedPrompts.Clear();

        Console.WriteLine($"\n🔹 {prompt}");
        Console.WriteLine("Take a few moments to reflect...");
        ShowAnimation(_duration);

        Console.WriteLine("\nReflection complete. Take a deep breath...");
        ShowAnimation(3);
    }
}