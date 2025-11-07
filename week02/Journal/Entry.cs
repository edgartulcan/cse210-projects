using System;

public class Entry
{
    // Abstraction: store the pieces of an entry as properties.
    public string Date { get; private set; }
    public string Prompt { get; private set; }
    public string Response { get; private set; }

    // Constructor
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Return a single-line representation for saving.
    // Use a separator unlikely to appear in normal text.
    public string ToFileString()
    {
        const string sep = "~|~";
        return $"{Date}{sep}{Escape(Prompt)}{sep}{Escape(Response)}";
    }

    // Create an Entry from a saved line.
    public static Entry FromFileString(string line)
    {
        const string sep = "~|~";
        string[] parts = line.Split(new string[] { sep }, StringSplitOptions.None);
        if (parts.Length < 3) throw new FormatException("Invalid entry format.");
        return new Entry(parts[0], Unescape(parts[1]), Unescape(parts[2]));
    }

    // Small escape/unescape so separator won't break if used accidentally
    private static string Escape(string s) => s.Replace("\\", "\\\\").Replace("~|~", "\\~|~");
    private static string Unescape(string s) => s.Replace("\\~|~", "~|~").Replace("\\\\", "\\\\");

    // Nicely formatted display for console
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
