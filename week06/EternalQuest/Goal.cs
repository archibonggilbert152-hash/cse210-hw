using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _title;
        private string _description;
        private int _points;

        public Goal(string title, string description, int points)
        {
            _title = title;
            _description = description;
            _points = points;
        }

        // Encapsulated getters
        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public int GetPoints() => _points;

        // Some goals are complete, some are not (eternal goals never complete)
        public virtual bool IsComplete() => false;

        // Called when user records an event for the goal.
        // Returns number of points gained as a result of recording the event.
        public abstract int RecordEvent();

        // Default detail string — derived classes may override if they need more info
        public virtual string GetDetailsString()
        {
            // Example: [ ] Walk dog (Earns 100 points)
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {GetTitle()} ({GetDescription()}) (Earns {GetPoints()} points)";
        }

        // Serialization to text line (type-specific info appended by derived classes)
        public abstract string Serialize();
    }
}
