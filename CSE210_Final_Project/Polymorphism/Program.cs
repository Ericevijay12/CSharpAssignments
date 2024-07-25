using System;
using System.Collections.Generic;

abstract class Activity
{
    public double Distance { get; set; }
    public double Duration { get; set; } // in hours

    public Activity(double distance, double duration)
    {
        Distance = distance;
        Duration = duration;
    }

    public abstract double GetSpeed(); // Speed in mph
    public abstract double GetPace(); // Pace in min/mile

    public virtual string GetSummary()
    {
        return $"Distance: {Distance} miles\nDuration: {Duration} hours\nSpeed: {GetSpeed()} mph\nPace: {GetPace()} min/mile";
    }
}

class Running : Activity
{
    public Running(double distance, double duration) : base(distance, duration) { }

    public override double GetSpeed()
    {
        return Distance / Duration;
    }

    public override double GetPace()
    {
        return (Duration * 60) / Distance;
    }
}

class Cycling : Activity
{
    public Cycling(double distance, double duration) : base(distance, duration) { }

    public override double GetSpeed()
    {
        return Distance / Duration;
    }

    public override double GetPace()
    {
        return (Duration * 60) / Distance;
    }
}

class Swimming : Activity
{
    public Swimming(double distance, double duration) : base(distance, duration) { }

    public override double GetSpeed()
    {
        return Distance / Duration;
    }

    public override double GetPace()
    {
        return (Duration * 60) / Distance;
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(5, 0.5),
            new Cycling(20, 1),
            new Swimming(1, 0.4)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
