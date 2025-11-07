using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Abstraction: the entries list is private; manipulate it through methods.
    private readonly List<Entry> _entries;
    private const string Separator = "~|~";

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        if (entry == null) throw new ArgumentNullException(nameof(entry));
        _entries.Add(entry);
    }

    public IEnumerable<Entry> GetEntries()
    {
        // Return a copy to preserve encapsulation
        return new List<Entry>(_entries);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("---- Journal Entries ----");
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry {i + 1}:");
            Console.WriteLine(_entries[i].ToString());
        }
    }

    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename)) throw new ArgumentException("Filename cannot be empty.");
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                sw.WriteLine(entry.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename)) throw new FileNotFoundException("File not found.", filename);
        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            try
            {
                var entry = Entry.FromFileString(line);
                _entries.Add(entry);
            }
            catch (FormatException)
            {
                // skip bad lines or optionally log
            }
        }
    }

    public void Clear()
    {
        _entries.Clear();
    }

    public int Count => _entries.Count;
}
