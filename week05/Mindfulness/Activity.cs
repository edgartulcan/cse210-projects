using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    class Activity
    {
        protected string _name;
        protected string _description;
        protected int _durationSeconds;
        private static readonly string logFile = "mindfulness_log.csv";

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public virtual void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Duración en segundos: ");
            _durationSeconds = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Prepárate...");
            ShowSpinner(3);
        }

        public virtual void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("¡Buen trabajo!");
            Console.WriteLine($"Has completado {_name} por {_durationSeconds} segundos.");
            ShowSpinner(3);
            LogActivity();
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                i++;
            }
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        private void LogActivity()
        {
            try
            {
                bool header = !File.Exists(logFile);
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    if (header) sw.WriteLine("Timestamp,Activity,Duration");
                    sw.WriteLine($"{DateTime.Now},{_name},{_durationSeconds}");
                }
            }
            catch { }
        }

        protected int GetDuration() => _durationSeconds;
    }
}
