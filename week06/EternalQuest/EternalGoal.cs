using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Recorded an eternal goal '{ShortName}'. You gained {Points} points.");
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"Eternal|{ShortName}|{Description}|{Points}";
    }
}
