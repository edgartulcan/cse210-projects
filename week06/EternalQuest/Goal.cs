using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{ShortName}: {Description} (Worth {Points} pts)";
    }

    public abstract string GetStringRepresentation();
}
