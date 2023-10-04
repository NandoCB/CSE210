using System;

class Program
{
    static void Main()
    {
        // Crear una instancia de la Escritura
        Scripture scripture = new Scripture(
            "John 3:16",
            "For God so bloved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
        );

        Console.Clear();
        Console.WriteLine("Press Enter to hide words or type 'exit' to exit.");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine(scripture.GetVisibleText()); // Show visible text
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
                break;
            else if (input == "")
            {
                scripture.HideRandomWord(); // Hide a random word
                Console.Clear();
            }
            else
                Console.WriteLine("Unrecognized command. Press Enter to hide words or type 'exit' to exit.");
        }
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetVisibleText()
    {
        return $"{reference}: {string.Join(" ", words.Select(word => word.IsVisible ? word.Text : "****"))}";
    }

    public void HideRandomWord()
    {
        List<Word> visibleWords = words.Where(word => word.IsVisible).ToList();
        if (visibleWords.Count > 0)
        {
            Random random = new Random();
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].IsVisible = false;
        }
    }
}

class ScriptureReference
{
    public string Book { get; }
    public int Chapter { get; }
    public int? StartVerse { get; }
    public int? EndVerse { get; }

    public ScriptureReference(string reference)
    {
                                            // Split the reference chain into its components, such as book, chapter, and verses
        string[] parts = reference.Split(' ');

        if (parts.Length >= 2)
        {
            Book = parts[0];
            string[] chapterVerseParts = parts[1].Split(':');

            if (chapterVerseParts.Length >= 1)
            {
                Chapter = int.Parse(chapterVerseParts[0]);

                if (chapterVerseParts.Length >= 2)
                {
                                        // If there is a dash, this indicates a range of verses
                    string[] verseRangeParts = chapterVerseParts[1].Split('-');

                    if (verseRangeParts.Length >= 1)
                    {
                        StartVerse = int.Parse(verseRangeParts[0]);

                        if (verseRangeParts.Length >= 2)
                        {
                            EndVerse = int.Parse(verseRangeParts[1]);
                        }
                    }
                }
            }
        }
    }
}

class Word
{
    public string Text { get; }
    public bool IsVisible { get; set; }

    public Word(string text)
    {
        Text = text;
        IsVisible = true;
    }
}
