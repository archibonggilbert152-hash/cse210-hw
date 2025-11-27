using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _random = new();
        private HashSet<int> _usedPromptIndexes = new();

        public ListingActivity(int durationSeconds)
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by having you list as many things as you can.",
                   durationSeconds)
        { }

        public override void Run()
        {
            ShowStart();

            int promptIndex = PickRandomWithoutRepeat(_prompts.Count, _usedPromptIndexes);
            Console.WriteLine();
            Console.WriteLine(_prompts[promptIndex]);

            Console.Write("\nYou have 5 seconds to prepare: ");
            ShowCountdown(5);
            Console.WriteLine("\nStart listing items:");

            DateTime endTime = DateTime.UtcNow.AddSeconds(DurationSeconds);
            var entries = new List<string>();

            while (DateTime.UtcNow < endTime)
            {
                string line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    entries.Add(line.Trim());
            }

            Console.WriteLine($"\nYou listed {entries.Count} items:");
            foreach (var item in entries)
                Console.WriteLine($" - {item}");

            ShowEnd();
        }

        private int PickRandomWithoutRepeat(int count, HashSet<int> used)
        {
            if (used.Count == count) used.Clear();

            int idx;
            do { idx = _random.Next(count); }
            while (used.Contains(idx));

            used.Add(idx);
            return idx;
        }
    }
}
