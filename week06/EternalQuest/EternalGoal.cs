using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        // No member variables necessary; each recording just grants points
        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
        }

        public override bool IsComplete() => false; // never complete

        public override int RecordEvent()
        {
            // Each time user records, they get the base points
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            return $"[~] {GetTitle()} ({GetDescription()}) (Repeatable {GetPoints()} pts)";
        }

        public override string Serialize()
        {
            // Format: Eternal|title|desc|points
            return $"Eternal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}";
        }

        private string Escape(string s) => s.Replace("|", "\\|");
    }
}
