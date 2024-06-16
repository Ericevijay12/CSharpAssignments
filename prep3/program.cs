C# Prep 3—Loops

Code

using System;

class Program
{
    static void Main(string[] args)
    {
        // Use a for loop to print numbers 1 to 10
        Console.WriteLine("Using for loop:");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i);
        }

        // Use a while loop to print numbers 1 to 10
        Console.WriteLine("\nUsing while loop:");
        int j = 1;
        while (j <= 10)
        {
            Console.WriteLine(j);
            j++;
        }
    }
}
