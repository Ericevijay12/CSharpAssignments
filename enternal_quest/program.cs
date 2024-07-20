using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Goal> goals = new List<Goal>();
            int score = 0;

            // Sample goals
            goals.Add(new SimpleGoal("Run a marathon", "Complete a marathon and earn points.", 1000));
            goals.Add(new EternalGoal("Read scriptures", "Read scriptures daily for points.", 100));
            goals.Add(new ChecklistGoal("Attend temple", "Attend the temple 10 times for a bonus.", 50, 10, 500));

            // Main loop
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest Program");
                Console.WriteLine("=====================");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine();
                Console.WriteLine("1. List Goals");
                Console.WriteLine("2. Create New Goal");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListGoals(goals);
                        break;
                    case "2":
                        CreateGoal(goals);
                        break;
                    case "3":
                        score += RecordEvent(goals);
                        break;
                    case "4":
                        SaveGoals(goals, score);
                        break;
                    case "5":
                        score = LoadGoals(goals);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void ListGoals(List<Goal> goals)
        {
            Console.WriteLine("Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i]}");
            }
        }

        static void CreateGoal(List<Goal> goals)
        {
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            string choice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter goal points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    break;
            }
        }

        static int RecordEvent(List<Goal> goals)
        {
            ListGoals(goals);
            Console.Write("Select goal to record: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < goals.Count)
            {
                return goals[index].RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid goal. Event not recorded.");
                return 0;
            }
        }

        static void SaveGoals(List<Goal> goals, int score)
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                outputFile.WriteLine(score);
                foreach (Goal goal in goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        static int LoadGoals(List<Goal> goals)
        {
            if (!File.Exists("goals.txt"))
            {
                Console.WriteLine("No saved goals found.");
                return 0;
            }

            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            int score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                {
                    goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                }
                else if (type == "EternalGoal")
                {
                    goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                }
                else if (type == "ChecklistGoal")
                {
                    goals.Add(new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4])));
                }
            }

            return score;
        }
    }

    abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        public override string ToString()
        {
            return $"{_name}: {_description} ({_points} points)";
        }

        public abstract int RecordEvent();
        public abstract string GetStringRepresentation();
    }

    class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent()
        {
            return _points;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal:{_name},{_description},{_points}";
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent()
        {
            return _points;
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal:{_name},{_description},{_points}";
        }
    }

    class ChecklistGoal : Goal
    {
        private int _target;
        private int _bonus;
        private int _completedCount;

        public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _completedCount = 0;
        }

        public override int RecordEvent()
        {
            _completedCount++;
            if (_completedCount >= _target)
            {
                return _points + _bonus;
            }
            return _points;
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal:{_name},{_description},{_points},{_target},{_bonus}";
        }
    }
}