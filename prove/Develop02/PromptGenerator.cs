using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private static Random _random = new Random();
    private static List<string> _messages = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do today, what would it be?"
    };

    public static string GetRandomMessage()
    {
        int randomIndex = _random.Next(_messages.Count);
        return _messages[randomIndex];
    }
}
