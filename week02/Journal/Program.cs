using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Random rand = new Random();
                int index = rand.Next(prompts.Count);
                string prompt = prompts[index];

                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._prompt = prompt;
                entry._response = response;

                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nYour Journal:\n");
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                Console.Write("\nEnter filename to save to: ");
                string fileName = Console.ReadLine();
                journal.SaveJournal(fileName);
                Console.WriteLine("Journal saved successfully.");
            }
            else if (choice == "4")
            {
                Console.Write("\nEnter filename to load: ");
                string fileName = Console.ReadLine();
                journal.LoadJournal(fileName);
                Console.WriteLine("Journal loaded successfully.");
            }
        }
    }
}
