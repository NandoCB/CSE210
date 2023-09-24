using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public List<string> GetEntries()
    {
        List<string> entryStrings = new List<string>();
        foreach (var entry in entries)
        {
            entryStrings.Add(entry.ToString());
        }
        return entryStrings;
    }

    public void SaveToFile(string fileName)
    {
        List<string> entryStrings = GetEntries();
        File.WriteAllLines(fileName, entryStrings);
    }

    public void LoadFromFile(string fileName)
    {
        List<string> entryStrings = new List<string>(File.ReadAllLines(fileName));
        entries.Clear();
        foreach (var entryString in entryStrings)
        {
            string[] parts = entryString.Split('\n');
            if (parts.Length == 3)
            {
                string date = parts[0];
                string message = parts[1];
                string text = parts[2];
                Entry entry = new Entry(date, message, text);
                entries.Add(entry);
            }
        }
    }
}
