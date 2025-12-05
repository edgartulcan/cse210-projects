using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("Checklist goal already completed.");
            return 0;
        }

        _amountCompleted++;
        int gained = Points;

        Console.WriteLine($"Progress for '{ShortName}': {_amountCompleted}/{_target}. You gained {Points} points.");

        if (_amountCompleted >= _target)
        {
            Console.WriteLine($"Goal '{ShortName}' reached target! Bonus {_bonus} points awarded.");
            gained += _bonus;
        }

        return gained;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"{ShortName}: {Description} (Each {Points} pts) Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist|{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
