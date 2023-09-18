using System;

class Program
{
    static void Main(string[] args)
    {
         // Call DisplayWelcome function
        DisplayWelcome();

        // Call PromptUserName function and save the user's name
        string userName = PromptUserName();

        // Call PromptUserNumber function and save the user's favorite number
        int userNumber = PromptUserNumber();

        // Call SquareNumber function to square the user's favorite number
        int squaredNumber = SquareNumber(userNumber);

        // Call DisplayResult function to display the user's name and squared number
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Please enter your favorite number: ");
        }
        return number;
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"Hello, {userName}! Your favorite number squared is: {squaredNumber}");
    }
    
}