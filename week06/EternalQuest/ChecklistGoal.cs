using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string title, string description, int pointsPer, int targetCount, int bonus)
            : base(title, description, pointsPer)
        {
            _timesCompleted = 0;
            _targetCount = targetCount;
            _bonusPoints = bonus;
        }

        public override bool IsComplete() => _timesCompleted >= _targetCount;

        public int GetTimesCompleted() => _timesCompleted;
        public int GetTargetCount() => _targetCount;
        public int GetBonusPoints() => _bonusPoints;

        // Each record gives base points; on final completion also give bonus
        public override int RecordEvent()
        {
            if (IsComplete())
            {
                Console.WriteLine("This checklist goal has already been completed.");
                return 0;
            }

            _timesCompleted++;
            int earned = GetPoints();

            if (IsComplete())
            {
                earned += _bonusPoints;
                Console.WriteLine($"Checklist complete! You earned an extra bonus of {_bonusPoints} points.");
            }

            return earned;
        }

        public override string GetDetailsString()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {GetTitle()} ({GetDescription()}) Completed {GetTimesCompleted()}/{GetTargetCount()} (Each {GetPoints()} pts, Bonus {GetBonusPoints()} pts)";
        }

        public override string Serialize()
        {
            // Format: Checklist|title|desc|pointsPer|timesCompleted|targetCount|bonus
            return $"Checklist|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_timesCompleted}|{_targetCount}|{_bonusPoints}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
