using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already complete.");
            return 0;
        }

        _isComplete = true;
        Console.WriteLine($"Goal '{ShortName}' completed! You gained {Points} points.");
        return Points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"Simple|{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}
