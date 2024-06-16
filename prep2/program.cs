C# Prep 2—Conditionals

Code

using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their age
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        // Use if-else statements to determine the user's life stage
        if (age < 13)
        {
            Console.WriteLine("You are a child.");
        }
        else if (age < 20)
        {
            Console.WriteLine("You are a teenager.");
        }
        else if (age < 65)
        {
            Console.WriteLine("You are an adult.");
        }
        else
        {
            Console.WriteLine("You are a senior.");
        }
    }
}
