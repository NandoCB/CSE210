using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Random random = new Random();
    static List<string> messages = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do today, what would it be?"
    };

    static void Main()
    {
        List<string> entries = new List<string>();

        while (true)
        {
            Console.WriteLine("Diary Menu:");
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. View entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Delete last entry");
            Console.WriteLine("6. Delete entire journal");
            Console.WriteLine("7. Quit");

            Console.Write("Select an option (1-7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomMessage = GetRandomMessage();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Console.WriteLine($"{currentDate}\n{randomMessage}");
                    Console.Write("Write your diary entry: ");
                    string entry = Console.ReadLine();
                    entries.Add($"{currentDate}\n{randomMessage}\n{entry}\n");
                    break;

                case "2":
                    Console.WriteLine("Diary Entries:\n");
                    foreach (var item in entries)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    File.WriteAllLines(saveFileName, entries);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    if (File.Exists(loadFileName))
                    {
                        entries = new List<string>(File.ReadAllLines(loadFileName));
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                    break;

                case "5":
                    if (entries.Count > 0)
                    {
                        entries.RemoveAt(entries.Count - 1);
                        Console.WriteLine("Last entry deleted.");
                    }
                    else
                    {
                        Console.WriteLine("No entries to delete.");
                    }
                    break;

                case "6":
                    entries.Clear();
                    Console.WriteLine("Journal cleared.");
                    break;

                case "7":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static string GetRandomMessage()
    {
        int randomIndex = random.Next(messages.Count);
        return messages[randomIndex];
    }
}