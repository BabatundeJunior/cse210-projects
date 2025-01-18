using System;

// EXCEEDED REQUIREMENTS ARE HIGHLITED IN THE PROGRAM.CS FILE 

public class Entry 
{
    public string _prompt;
    public string _response;
    public DateTime _date;

    // Constructor to initialize an entry
    public Entry(string prompt, string response, DateTime date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    // Method to format the entry as a string for display
    public override string ToString()
    {
        return $"Date: {_date.ToString("yyyy-MM-dd HH:mm:ss")}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }
}