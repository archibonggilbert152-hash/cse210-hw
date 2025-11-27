using System;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity(int durationSeconds)
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                   durationSeconds)
        { }

        public override void Run()
        {
            ShowStart();

            DateTime endTime = DateTime.UtcNow.AddSeconds(DurationSeconds);
            bool inhale = true;

            while (DateTime.UtcNow < endTime)
            {
                Console.WriteLine(inhale ? "Breathe in..." : "Breathe out...");
                ShowCountdown(4);
                Console.WriteLine();
                inhale = !inhale;
            }

            ShowEnd();
        }
    }
}
