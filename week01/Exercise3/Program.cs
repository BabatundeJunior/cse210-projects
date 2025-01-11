using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // Requirements 1 Without while statement
        Console.Write("What is the magic number? ");
        int magic = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        if (guess < magic)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magic)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }

        // Requirements 2 with while statement
        Console.WriteLine("Requirement 2");
        Console.Write("What is the magic number? ");
        int Number = int.Parse(Console.ReadLine());

        int guessTwo = 0;

        while (guessTwo != Number)
        {
            Console.Write("What is your guess? ");
            guessTwo = int.Parse(Console.ReadLine());

            if (guessTwo < Number)
            {
                Console.WriteLine("Higher");
            }
            else if (guessTwo > Number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        // Requirements 3 with the computer generating random numbers

        Random random = new Random();
        int magicNumber = random.Next(1, 101); // Random number between 1 and 100

        int guessThree = 0;

        Console.WriteLine("Welcome to Guess My Number! Try to guess the magic number.");

        while (guessThree != magicNumber)
        {
            Console.Write("What is your guess? ");
            guessThree = int.Parse(Console.ReadLine());

            if (guessThree < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guessThree > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    } 
}