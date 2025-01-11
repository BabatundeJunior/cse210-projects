using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine(); 
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine()); 
    }
    static int SquareNumber(int number)
    {
        return number * number; 
    }
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your favourite number is {squaredNumber}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();  
        string name = PromptUserName();  
        int favoriteNumber = PromptUserNumber();  
        int squaredNumber = SquareNumber(favoriteNumber); 
        DisplayResult(name, squaredNumber);  
    }
}