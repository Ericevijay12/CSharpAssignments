C# Prep 4—Lists

Code

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold the names of your friends
        List<string> friends = new List<string>();

        // Add some friends to the list
        friends.Add("Alice");
        friends.Add("Bob");
        friends.Add("Charlie");

        // Print the names of all your friends
        Console.WriteLine("Friends:");
        foreach (string friend in friends)
        {
            Console.WriteLine(friend);
        }

        // Remove a friend from the list
        friends.Remove("Bob");

        // Print the updated list of friends
        Console.WriteLine("\nUpdated Friends:");
        foreach (string friend in friends)
        {
            Console.WriteLine(friend);
        }
    }
}