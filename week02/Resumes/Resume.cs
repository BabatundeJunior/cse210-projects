// Resume.cs
using System;
using System.Collections.Generic;

public class Resume
{
    // Member variable for the person's name
    public string _name;

    // Member variable for the list of jobs
    public List<Job> _jobs = new List<Job>();

    // Method to display the resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}
