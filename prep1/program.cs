C# Prep 1—Variables

Code:

using System;

class Program
{
    static void Main(string[] args)
    {
        // Declare a variable to hold the user's name
        string userName;

        // Prompt the user for their name
        Console.Write("Please enter your name: ");
        userName = Console.ReadLine();

        // Declare a variable to hold the user's age
        int userAge;

        // Prompt the user for their age
        Console.Write("Please enter your age: ");
        userAge = int.Parse(Console.ReadLine());

        // Output a greeting message
        Console.WriteLine($"Hello {userName}, you are {userAge} years old.");
    }
}
