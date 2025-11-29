using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you were selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this meaningful?",
            "Have you done anything like this before?",
            "How did it start?",
            "How did you feel afterwards?",
            "What made this different?",
            "What did you learn?",
            "How can this help you in the future?"
        };

        private Random rnd = new Random();

        public ReflectingActivity() : base("Reflecting Activity",
            "This activity helps you reflect on times of strength and resilience.")
        { }

        public void Run()
        {
            DisplayStartingMessage();
            int duration = GetDuration();
            DateTime end = DateTime.Now.AddSeconds(duration);

            Console.WriteLine();
            Console.WriteLine("Prompt: " + _prompts[rnd.Next(_prompts.Count)]);
            Console.WriteLine("Press Enter when ready...");
            Console.ReadLine();

            while (DateTime.Now < end)
            {
                string q = _questions[rnd.Next(_questions.Count)];
                Console.WriteLine("-> " + q);
                ShowSpinner(6);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}
