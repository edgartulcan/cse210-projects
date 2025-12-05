using System;


class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        manager.Start();
    }
}



/*
Notes / extras implemented:
- Goal.RecordEvent returns an int number of points gained; this simplifies score handling.
- Save file format is simple text (goals.txt) where first line is score and each subsequent line is a '|' delimited goal representation.
- For loading, this implementation simulates previously completed checklist/simple goals by invoking RecordEvent the saved number of times when reconstructing. This means console messages may appear during load; for a production solution you'd set private fields via constructors or serialization.
- You can extend with badges, levels, or a nicer UI easily.
*/