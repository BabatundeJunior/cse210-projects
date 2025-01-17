using System;

public class Job 
{
        // Member variables
    public string _jobTitle;
    public string _company;
    public string _startYear;
    public string _endYear;

        // Method to display job details_
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}

