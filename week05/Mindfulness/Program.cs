using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness App";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness App\n");
                Console.WriteLine("1) Breathing Activity");
                Console.WriteLine("2) Reflection Activity");
                Console.WriteLine("3) Listing Activity");
                Console.WriteLine("4) Exit\n");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";
                if (choice == "4")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                int duration = PromptForDuration();

                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(duration),
                    "2" => new ReflectionActivity(duration),
                    "3" => new ListingActivity(duration),
                    _ => null
                };

                if (activity == null)
                {
                    Console.WriteLine("Invalid choice. Press Enter...");
                    Console.ReadLine();
                    continue;
                }

                activity.Run();

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        private static int PromptForDuration()
        {
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                string input = Console.ReadLine() ?? "";

                if (int.TryParse(input, out int seconds) && seconds > 0)
                    return seconds;

                Console.WriteLine("Please enter a valid positive number.");
            }
        }
    }
}
