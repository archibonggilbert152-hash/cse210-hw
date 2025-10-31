using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber);
    }

    // Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for and returns user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Returns the square of the provided number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the final result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
