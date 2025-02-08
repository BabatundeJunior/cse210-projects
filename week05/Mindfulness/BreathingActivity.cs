using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Breathe in and out slowly to relax.") { }

    protected override void Run()
    {
        for (int i = 0; i < _duration / 6; i++)
        {
            Console.WriteLine("\n Breathe in...");
            ShowCountdown(3);
            Console.WriteLine(" Breathe out...");
            ShowCountdown(3);
        }
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}