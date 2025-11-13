using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // --- EXCEED REQUIREMENTS ---
        // Ahora el programa carga escrituras desde un archivo (scriptures.txt)
        // y elige una aleatoria para memorizar.

        string filePath = "scriptures.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"No se encontró el archivo '{filePath}'.");
            Console.WriteLine("Crea un archivo llamado scriptures.txt en la misma carpeta del programa.");
            return;
        }

        // Leer todas las líneas del archivo
        List<string> lines = File.ReadAllLines(filePath).ToList();
        if (lines.Count == 0)
        {
            Console.WriteLine("El archivo 'scriptures.txt' está vacío. Agrega algunas escrituras.");
            return;
        }

        // Elegir una escritura aleatoria
        Random rand = new Random();
        string randomLine = lines[rand.Next(lines.Count)];

        // Separar la referencia y el texto usando "|"
        string[] parts = randomLine.Split('|');
        if (parts.Length != 2)
        {
            Console.WriteLine("Formato incorrecto en el archivo. Usa el formato: Libro 3:5|Texto del versículo");
            return;
        }

        string referenceText = parts[0];
        string verseText = parts[1];

        // Procesar la referencia (puede tener rango)
        Reference reference = ParseReference(referenceText);

        // Crear la escritura
        Scripture scripture = new Scripture(reference, verseText);

        // --- Bucle principal ---
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPresiona Enter para ocultar más palabras o escribe 'quit' para salir.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\n¡Todas las palabras están ocultas! El programa ha terminado.");
                break;
            }
        }
    }

    // Método auxiliar para convertir texto en Reference
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
            Console.WriteLine($"Error al interpretar la referencia: {referenceText}");
            return new Reference("Unknown", 0, 0);
        }
    }
}
