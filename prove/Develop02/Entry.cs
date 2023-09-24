public class Entry
{
    public string Date { get; set; }
    public string Message { get; set; }
    public string Text { get; set; }

    public Entry(string date, string message, string text)
    {
        Date = date;
        Message = message;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Date}\n{Message}\n{Text}\n";
    }
}
