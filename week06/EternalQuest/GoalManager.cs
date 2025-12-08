using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private const string SAVE_FILE = "goals.txt";

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public int GetScore() => _score;
        public void AddPoints(int pts)
        {
            _score += pts;
            CheckForBadgesAndLevel();
        }

        public void AddGoal(Goal g) => _goals.Add(g);
        public List<Goal> GetGoals() => _goals;

        public void ListGoals()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        // Record event by index (1-based shown to user)
        public void RecordEvent(int index)
        {
            if (index < 1 || index > _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            Goal g = _goals[index - 1];
            int earned = g.RecordEvent();
            if (earned > 0)
            {
                AddPoints(earned);
                Console.WriteLine($"You earned {earned} points! Total score: {_score}");
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(SAVE_FILE, false))
            {
                // First line: score
                sw.WriteLine(_score);
                // Then each goal's serialized line
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.Serialize());
                }
            }
            Console.WriteLine($"Saved to {SAVE_FILE}");
        }

        public void Load()
        {
            if (!File.Exists(SAVE_FILE))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            _goals.Clear();
            using (StreamReader sr = new StreamReader(SAVE_FILE))
            {
                string line = sr.ReadLine();
                if (!int.TryParse(line, out _score))
                {
                    _score = 0;
                }

                while (!sr.EndOfStream)
                {
                    string gline = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(gline)) continue;
                    var g = DeserializeGoal(gline);
                    if (g != null) _goals.Add(g);
                }
            }
            Console.WriteLine($"Loaded {_goals.Count} goals. Current score: {_score}");
        }

        // Simple parser for the save format
        private Goal DeserializeGoal(string line)
        {
            // Need to handle escaped pipes "\|" -> temporarily replace with placeholder
            string placeholder = "{PIPE}";
            string working = line.Replace("\\|", placeholder);
            string[] parts = working.Split('|');
            for (int i = 0; i < parts.Length; i++) parts[i] = parts[i].Replace(placeholder, "|");

            try
            {
                string type = parts[0];
                if (type == "Simple")
                {
                    string title = parts[1];
                    string desc = parts[2];
                    int pts = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    var sg = new SimpleGoal(title, desc, pts);
                    if (isComplete)
                    {
                        // mark as complete by recording once (but avoid double counting score)
                        // We'll set its internal flag by reflection-like approach: call RecordEvent and then subtract points.
                        // Simpler: create private helper copy: but to keep code short, we'll simulate by marking via repeated RecordEvent:
                        // But SimpleGoal.RecordEvent marks complete and returns points; we don't want to change global score here.
                        // So set private field using a small hack: RecordEvent then immediately reset _isComplete flag using reflection.
                        int dummy = sg.RecordEvent(); // sets to complete
                        // reset _isComplete to true is already done; but no change to GoalManager score here as Load doesn't add points.
                    }
                    return sg;
                }
                else if (type == "Eternal")
                {
                    string title = parts[1];
                    string desc = parts[2];
                    int pts = int.Parse(parts[3]);
                    return new EternalGoal(title, desc, pts);
                }
                else if (type == "Checklist")
                {
                    string title = parts[1];
                    string desc = parts[2];
                    int ptsPer = int.Parse(parts[3]);
                    int timesCompleted = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int bonus = int.Parse(parts[6]);

                    var cg = new ChecklistGoal(title, desc, ptsPer, target, bonus);
                    // Bring timesCompleted up to stored value by calling RecordEvent() required number of times
                    for (int i = 0; i < timesCompleted; i++)
                        cg.RecordEvent(); // doesn't affect manager score on load
                    return cg;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse goal line: {line} ({ex.Message})");
            }

            return null;
        }

        // --------- Creativity: Leveling & Simple Badges ----------
        private void CheckForBadgesAndLevel()
        {
            int level = _score / 1000 + 1; // each 1000 points gives next level
            // Example: award console-based badge messages at thresholds
            if (_score >= 1000 && _score < 1100)
                Console.WriteLine("Badge earned: Apprentice (1000 pts)");
            else if (_score >= 5000 && _score < 5100)
                Console.WriteLine("Badge earned: Master (5000 pts)");
            // (More badge logic could be added with persistent badge store)
        }
    }
}
