using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade? ");
        // string score = Console.ReadLine();
        int grade = int.Parse(Console.ReadLine()); 
        if (grade >= 90) 
        {
            Console.WriteLine($"Your Score is {grade} you earned a grade of A");
        }
        else if (grade >= 80) 
        {
            Console.WriteLine($"Your Score is {grade} you earned a grade of B");
        }
        else if (grade >= 70) 
        {
            Console.WriteLine($"Your Score is {grade} you earned a grade of C");
        }
        else if (grade >= 60) 
        {
            Console.WriteLine($"Your Score is {grade} you earned a grade of D");
        }
        else
        {
            Console.WriteLine($"Your Score is {grade} you earned a grade of F");
        }
        // Checks if the user passed!
        if (grade >= 70)
        {
            Console.WriteLine($"You Passed Congratulations");
        }
        else
        {
            Console.WriteLine($"Sorry you Failed try again next semester");
        }
    }
}