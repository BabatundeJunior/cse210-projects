using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = 0;
        do 
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sumOfNumbers = numbers.Sum();
        Console.WriteLine($"The sum of the numbers entered is: {sumOfNumbers}");  

        double averageOfNumbers = numbers.Average();
        Console.WriteLine($"The average of the numbers entered is: {averageOfNumbers}"); 

        int largestNumber = numbers.Max();
        Console.WriteLine($"The largest number is: {largestNumber}"); 

        Console.WriteLine($"Here is a list of all the numbers entered: ");  
        foreach (int num in numbers)
        {
          Console.WriteLine($"{num}");  
        }
        
    }
}