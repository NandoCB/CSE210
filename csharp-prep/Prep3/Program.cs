using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Guess My Number game!");

        Random randomGenerator = new Random();
        string exitKeyword = "exit";

        // Generate the magic_number once outside the loop
        int magic_number = randomGenerator.Next(1, 101);
         int attempts = 0;

        while (true)
        {   
            Console.WriteLine("What is your guess? (Enter 'exit' to quit)");
            string answer = Console.ReadLine();

            if (answer.ToLower() == exitKeyword)
            {
                Console.WriteLine("Thanks for playing. Goodbye!");
                break; // Exit while loop if "exit" is entered
            }

            int userGuess;

            if (int.TryParse(answer, out userGuess))
            {
                if (userGuess >= 1 && userGuess <= 100)
                {
                    attempts++;
                    if (userGuess < magic_number) 
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (userGuess > magic_number)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {   
                        Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                        Console.Write("Do you want to play again? (yes/no): ");
                        string playAgain = Console.ReadLine().ToLower();
                        
                        if (playAgain == "no")
                        {
                            Console.WriteLine("Thanks for playing. Goodbye!");
                            break; //Exit the while loop
                        }
                        else if (playAgain != "yes")
                        {
                            Console.WriteLine("Invalid input. GAME OVER.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 100.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
