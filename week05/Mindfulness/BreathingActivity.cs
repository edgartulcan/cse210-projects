using System;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity",
            "This activity will help you relax by guiding your breathing.")
        { }

        public void Run()
        {
            DisplayStartingMessage();
            DateTime end = DateTime.Now.AddSeconds(GetDuration());

            while (DateTime.Now < end)
            {
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.WriteLine();
                if (DateTime.Now >= end) break;

                Console.Write("Breathe out...");
                ShowCountDown(6);
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}
