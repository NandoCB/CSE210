using System;

class JournalEntry //Class to represent a journal entry
{
    public DateTime Date { get; set; } //Entry date
    public string Prompt { get; set; } //Random entry message
    public string Content { get; set; } //User entry 

    //Constructor to initialize a journal entry
    public JournalEntry(DateTime date, string prompt, string content)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
    }

    public override string ToString()
    {
        return $"{Date:yyyy-MM-dd HH:mm:ss}\n{Prompt}\n{Content}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>(); //Entry jornal lists
    private Random random = new Random();
    private List<string> prompts = new List<string>  //Random message
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do today, what would it be?"
    };

    public void AddEntry(string content) //add entry to the jornal
    {
        string prompt = GetRandomPrompt();    //obtaining random message and date
        DateTime currentDate = DateTime.Now;
        JournalEntry entry = new JournalEntry(currentDate, prompt, content);
        entries.Add(entry);  // add the entry to the list
    }

    public void ViewEntries()  //see all entries
    {
        Console.WriteLine("Diary Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournalToFile(string fileName) //save the jornal in a file
    {
        File.WriteAllLines(fileName, entries.ConvertAll(entry => entry.ToString()));
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournalFromFile(string fileName)  //load the journal from file
    {
        if (File.Exists(fileName))
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i += 3)   //entry in three dates, question, answer
            {
                DateTime date = DateTime.ParseExact(lines[i], "yyyy-MM-dd HH:mm:ss", null);
                string prompt = lines[i + 1];
                string content = lines[i + 2];
                JournalEntry entry = new JournalEntry(date, prompt, content);
                entries.Add(entry); //add the entry to the jornal
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    //************ method to delete last journal entry
    public void DeleteLastEntry()
    {
        if (entries.Count > 0)
        {
            entries.RemoveAt(entries.Count - 1);
            Console.WriteLine("Last entry deleted.");
        }
        else
        {
            Console.WriteLine("No entries to delete.");
        }
    }

    //********* method to delete all the jornal content
    public void ClearJournal()
    {
        entries.Clear();
        Console.WriteLine("Journal cleared.");
    }
    //*****************
    private string GetRandomPrompt()    //Private method to get a random message
    {
        int randomIndex = random.Next(prompts.Count);
        return prompts[randomIndex];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

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
                    Console.Write("Write your diary entry: ");
                    string entry = Console.ReadLine();
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.ViewEntries();
                    break;

                case "3":
                    Console.Write("Enter a filename to save the journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveJournalToFile(saveFileName);
                    break;

                case "4":
                    Console.Write("Enter a filename to load the journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadJournalFromFile(loadFileName);
                    break;

                case "5":
                    journal.DeleteLastEntry();
                    break;

                case "6":
                    Console.WriteLine("WARNING: Deleting the entire journal will erase all stored memories.");
                    Console.Write("Are you sure you want to proceed? (Yes/No): ");
                    string confirmation = Console.ReadLine().Trim().ToLower();

                    if (confirmation == "yes")
                    {
                        journal.ClearJournal();
                    }
                    else if (confirmation == "no")
                    {
                        Console.WriteLine("Operation canceled.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                    }
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
}
