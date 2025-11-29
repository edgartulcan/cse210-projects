using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        new BreathingActivity().Run();
                        break;

                    case "2":
                        new ReflectingActivity().Run();
                        break;

                    case "3":
                        new ListingActivity().Run();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }
    }
}
