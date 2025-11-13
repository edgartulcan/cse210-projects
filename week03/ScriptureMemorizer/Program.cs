using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // With the help of a friend, I decided to be able to choose a verse at random from a file that only contains text.

        string filePath = "scriptures.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"The file was not found '{filePath}'.");
            Console.WriteLine("Create a file called scriptures.txt in the same folder as the program.");
            return;
        }

        // Read all lines of my file
        List<string> lines = File.ReadAllLines(filePath).ToList();
        if (lines.Count == 0)
        {
            Console.WriteLine("The file 'scriptures.txt' is empty. Add some scripts.");
            return;
        }

        // Choose a random scripture
        Random rand = new Random();
        string randomLine = lines[rand.Next(lines.Count)];

        // Separate the reference and text "|"
        string[] parts = randomLine.Split('|');
        if (parts.Length != 2)
        {
            Console.WriteLine("Incorrect file format. Use the format: Book 3:5|Verse text");
            return;
        }

        string referenceText = parts[0];
        string verseText = parts[1];

        // Procesar la referencia (puede tener rango)
        Reference reference = ParseReference(referenceText);

        // Crear la escritura
        Scripture scripture = new Scripture(reference, verseText);

        // Boolean
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\n¡All the words are hidden! The program has ended.");
                break;
            }
        }
    }

    // Auxiliary method for converting text to Reference 
    static Reference ParseReference(string referenceText)
    {
        try
        {
            string[] bookAndVerses = referenceText.Split(' ');
            string book = bookAndVerses[0];
            string[] chapterAndVerse = bookAndVerses[1].Split(':');
            int chapter = int.Parse(chapterAndVerse[0]);

            if (chapterAndVerse[1].Contains('-'))
            {
                string[] range = chapterAndVerse[1].Split('-');
                int startVerse = int.Parse(range[0]);
                int endVerse = int.Parse(range[1]);
                return new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                int verse = int.Parse(chapterAndVerse[1]);
                return new Reference(book, chapter, verse);
            }
        }
        catch
        {
            Console.WriteLine($"Error in interpreting the reference: {referenceText}");
            return new Reference("Unknown", 0, 0);
        }
    }
}
