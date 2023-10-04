using System;

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();

        while (true)
        {
            Console.WriteLine("Diary Menu:");
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. View entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string randomMessage = PromptGenerator.GetRandomMessage();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    Console.WriteLine($"{currentDate}\n{randomMessage}");
                    Console.Write("Write your diary entry: ");
                    string entryText = Console.ReadLine();
                    Entry entry = new Entry(currentDate, randomMessage, entryText);
                    myJournal.AddEntry(entry);
                    break;

                case "2":
                    Console.WriteLine("Diary Entries:\n");
                    foreach (var item in myJournal.GetEntries())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    myJournal.SaveToFile(saveFileName);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    if (File.Exists(loadFileName))
                    {
                        Console.WriteLine("Journal Contents:");
                        string[] fileContents = File.ReadAllLines(loadFileName);
                        foreach (string line in fileContents)
                        

                        {
                            Console.WriteLine(line);
                        }
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

