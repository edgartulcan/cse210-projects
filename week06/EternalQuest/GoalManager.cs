using System;
using System.IO;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private const string SAVEFILE = "goals.txt";

    public void Start()
    {
        bool exit = false;
        LoadGoals();

        while (!exit)
        {
            Console.WriteLine();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1. List goals (short)");
            Console.WriteLine("2. List goals (details)");
            Console.WriteLine("3. Create a new goal");
            Console.WriteLine("4. Record an event for a goal");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": ListGoalNames(); break;
                case "2": ListGoalDetails(); break;
                case "3": CreateGoal(); break;
                case "4": RecordEvent(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7": SaveGoals(); exit = true; break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string mark = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {mark} {g.ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string mark = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {mark} {g.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Type: ");
        var t = Console.ReadLine();

        Console.Write("Short name: ");
        var name = Console.ReadLine();
        Console.Write("Description: ");
        var desc = Console.ReadLine();
        Console.Write("Points for each completion: ");
        if (!int.TryParse(Console.ReadLine(), out int pts)) pts = 0;

        switch (t)
        {
            case "1": _goals.Add(new SimpleGoal(name, desc, pts)); break;
            case "2": _goals.Add(new EternalGoal(name, desc, pts)); break;
            case "3":
                Console.Write("Target times needed: ");
                if (!int.TryParse(Console.ReadLine(), out int target)) target = 1;
                Console.Write("Bonus points on completion: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus)) bonus = 0;
                _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
                break;
            default:
                Console.WriteLine("Unknown type. Aborting.");
                return;
        }

        Console.WriteLine("Goal created.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Select goal number to record: ");
        if (!int.TryParse(Console.ReadLine(), out int idx))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        idx -= 1;
        if (idx < 0 || idx >= _goals.Count)
        {
            Console.WriteLine("Index out of range.");
            return;
        }

        var goal = _goals[idx];
        int gained = goal.RecordEvent();
        if (gained > 0)
        {
            _score += gained;
            Console.WriteLine($"Total score is now {_score}.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            using (var writer = new StreamWriter(SAVEFILE))
            {
                writer.WriteLine(_score);
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved to {SAVEFILE}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving goals: " + ex.Message);
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists(SAVEFILE))
        {
            Console.WriteLine("No save file found. Starting fresh.");
            return;
        }

        try
        {
            _goals.Clear();
            var lines = File.ReadAllLines(SAVEFILE);
            if (lines.Length == 0) return;
            if (!int.TryParse(lines[0], out _score)) _score = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split('|');
                if (parts.Length == 0) continue;

                switch (parts[0])
                {
                    case "Simple":
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.TryParse(parts[4], out bool completed) && completed)
                        {
                            sg.RecordEvent();
                        }
                        _goals.Add(sg);
                        break;

                    case "Eternal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;

                    case "Checklist":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        if (int.TryParse(parts[4], out int amount))
                        {
                            for (int k = 0; k < amount; k++) cg.RecordEvent();
                        }
                        _goals.Add(cg);
                        break;
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Score set to {_score}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading goals: " + ex.Message);
        }
    }
}
