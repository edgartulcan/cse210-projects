using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people you appreciate?",
            "What are your strengths?",
            "Who have you helped this week?",
            "When have you felt peace this month?",
            "Who are your heroes?"
        };

        private Random rnd = new Random();

        public ListingActivity() : base("Listing Activity",
            "This activity helps you list positive things in your life.")
        { }

        public void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine();
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine("Prompt: " + prompt);
            Console.WriteLine("Prepárate...");
            ShowCountDown(5);

            int count = 0;
            DateTime end = DateTime.Now.AddSeconds(GetDuration());

            Console.WriteLine("Escribe items (Enter para cada uno):");

            while (DateTime.Now < end)
            {
                if (Console.KeyAvailable)
                {
                    string item = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(item)) count++;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Items ingresados: {count}");

            DisplayEndingMessage();
        }
    }
}
