using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "List as many positive things as you can.") { }

    protected override void Run()
    {
        Console.WriteLine("\n Start listing (type and press Enter)...");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
                items.Add(input);
        }

        Console.WriteLine($"\n You listed {items.Count} items!");
        Console.WriteLine("Here’s what you listed:");
        foreach (var item in items)
        {
            Console.WriteLine($"- {item}");
        }
    }
}