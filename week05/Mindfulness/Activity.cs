using System;
using System.Threading;

namespace MindfulnessApp
{
    public abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description, int durationSeconds)
        {
            _name = name;
            _description = description;
            _durationSeconds = Math.Max(1, durationSeconds);
        }

        protected string Name => _name;
        protected string Description => _description;
        protected int DurationSeconds => _durationSeconds;

        protected void ShowStart()
        {
            Console.Clear();
            Console.WriteLine($"=== {Name} ===\n");
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("Get ready ");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected void ShowEnd()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {Name} for {DurationSeconds} seconds.");
            Console.Write("Finishing up ");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected void ShowSpinner(int seconds)
        {
            var frames = new[] { '|', '/', '-', '\\' };
            int total = seconds * 10;
            for (int i = 0; i < total; i++)
            {
                Console.Write(frames[i % frames.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        public abstract void Run();
    }
}
