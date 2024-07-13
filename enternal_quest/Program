using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string _shortName;
    public string _description;
    public int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // For a simple goal, recording an event is not applicable
        Console.WriteLine("Recording event for Simple Goal.");
    }

    public override string GetDetailsString()
    {
        return $"Simple Goal: {_shortName}, Description: {_description}, Points: {_points}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points}";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        // For an eternal goal, recording an event is not applicable
        Console.WriteLine("Recording event for Eternal Goal.");
    }

    public override string GetDetailsString()
    {
        return $"Eternal Goal: {_shortName}, Description: {_description}, Points: {_points}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}

public class ChecklistGoal : Goal
{
    public int _amountCompleted;
    public int _target;
    public int _bonusPoints;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonusPoints)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Recording event for Checklist Goal: {_shortName}. Completed {_amountCompleted} out of {_target}.");
        if (_amountCompleted >= _target)
        {
            _points += _bonusPoints;
            Console.WriteLine($"Congratulations! Checklist Goal {_shortName} completed. You earned {_bonusPoints} bonus points.");
        }
    }

    public override string GetDetailsString()
    {
        return $"Checklist Goal: {_shortName}, Description: {_description}, Points: {_points}, Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonusPoints}";
    }
}

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;

        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    ListGoalNames();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 8.");
                    break;
            }
        }
    }

    private void DisplayMenu()
    {
        Console.WriteLine("\n=== Eternal Quest Menu ===");
        Console.WriteLine("1. Display Player Info");
        Console.WriteLine("2. List Goal Details");
        Console.WriteLine("3. List Goal Names");
        Console.WriteLine("4. Create New Goal");
        Console.WriteLine("5. Record Event (Accomplished Goal)");
        Console.WriteLine("6. Save Goals to File");
        Console.WriteLine("7. Load Goals from File");
        Console.WriteLine("8. Exit");
        Console.Write("Enter your choice: ");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\n=== List of Goals ===");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal._shortName);
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\n=== Detailed List of Goals ===");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("\nEnter Goal Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();

        Console.Write("Enter Points for Completing the Goal: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter your choice: ");
        string typeChoice = Console.ReadLine();

        Goal newGoal = null;

        switch (typeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter Target Number for Checklist Goal: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus Points for Checklist Goal: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation cancelled.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nChoose Goal to Record Event:");
        ListGoalNames();
        Console.Write("Enter Goal Name: ");
        string goalName = Console.ReadLine();

        Goal goal = _goals.Find(g => g._shortName == goalName);

        if (goal != null)
        {
            goal.RecordEvent();
            _score += goal._points;
            Console.WriteLine($"Event recorded for {goal._shortName}. You earned {goal._points} points.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved to goals.txt");
    }

    public void LoadGoals()
    {
        _goals.Clear();

        using (StreamReader reader = new StreamReader("goals.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string[] details = parts[1].Split(',');

                string goalType = parts[0];
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                if (goalType == "SimpleGoal")
                {
                    _goals.Add(new SimpleGoal(name, description, points));
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int amountCompleted = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int bonus = int.Parse(details[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                }
            }
        }

        Console.WriteLine("Goals loaded from goals.txt");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}
