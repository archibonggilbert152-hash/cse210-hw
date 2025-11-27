using System;
using System.Collections.Generic;
using System.Linq;

namespace MindfulnessApp
{
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _random = new();
        private HashSet<int> _usedPromptIndexes = new();

        public ReflectionActivity(int durationSeconds)
            : base("Reflection Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                   durationSeconds)
        { }

        public override void Run()
        {
            ShowStart();

            int promptIndex = PickRandomWithoutRepeat(_prompts.Count, _usedPromptIndexes);
            Console.WriteLine();
            Console.WriteLine(_prompts[promptIndex]);
            Console.WriteLine("\nPress Enter when you're ready...");
            Console.ReadLine();

            DateTime endTime = DateTime.UtcNow.AddSeconds(DurationSeconds);
            var questionPool = Enumerable.Range(0, _questions.Count).ToList();

            while (DateTime.UtcNow < endTime)
            {
                if (!questionPool.Any())
                    questionPool = Enumerable.Range(0, _questions.Count).ToList();

                int index = _random.Next(questionPool.Count);
                int qIndex = questionPool[index];
                questionPool.RemoveAt(index);

                Console.WriteLine($"\n--> {_questions[qIndex]}");
                ShowSpinner(8);
            }

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
