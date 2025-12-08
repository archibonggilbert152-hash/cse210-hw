using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string title, string description, int points) 
            : base(title, description, points)
        {
            _isComplete = false; // sensible default
        }

        public override bool IsComplete() => _isComplete;

        // When recorded, if not already complete, mark complete and grant points once
        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This goal is already complete.");
                return 0;
            }
            _isComplete = true;
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {GetTitle()} ({GetDescription()}) (One-time {GetPoints()} pts)";
        }

        public override string Serialize()
        {
            // Format: Simple|title|desc|points|isComplete
            return $"Simple|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_isComplete}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
