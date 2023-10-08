using System;

public abstract class MindfulnessActivity
{
    private string _name;
    private string _description;

    protected MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void RunActivity(int durationMinutes)
    {
        Console.WriteLine($"Welcome to {_name}");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {durationMinutes} minutes.");
        Console.WriteLine("Get ready to start...");
        Console.WriteLine("Press Enter to begin.");
        Console.ReadLine();

        int durationSeconds = durationMinutes * 60;
        PerformActivity(durationSeconds);

        Console.WriteLine($"Good job! You've completed {_name}.");
        Console.WriteLine($"Time: {durationMinutes} minutes.");
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }

    protected abstract void PerformActivity(int durationSeconds);
}

public class ListingActivity : MindfulnessActivity
{
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the positive aspects of your life by creating a list of as many items as you can within a specific category.")
    {
    }

    protected override void PerformActivity(int durationSeconds)
    {
        Console.WriteLine("Starting listing activity...");
        Console.WriteLine("Think about the people you appreciate.");
        Console.WriteLine("Start listing items. Type each item and press Enter. To stop, press Enter without typing.");

        int itemCount = 0;
        string input;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                itemCount++;
            }
        } while (!string.IsNullOrWhiteSpace(input));

        Console.WriteLine($"You listed {itemCount} items.");
        Console.WriteLine("Listing activity completed.");
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on moments in your life when you have demonstrated strength and resilience.")
    {
    }

    protected override void PerformActivity(int durationSeconds)
    {
        Console.WriteLine("Starting reflection activity...");
        Console.WriteLine("Think about a moment when you stood up for someone.");
        Thread.Sleep(9000); // Pause for 9 seconds
        Console.WriteLine("Think about a moment when you did something really challenging.");
        Thread.Sleep(9000); // Pause for 9 seconds
        Console.WriteLine("Think about a moment when you helped someone in need.");
        Thread.Sleep(9000); // Pause for 9 seconds
        Console.WriteLine("Think about a moment when you did something truly selfless.");
        Thread.Sleep(9000); // Pause for 9 seconds

        Console.WriteLine("Reflection activity completed.");
    }
}

public class RespiratoryActivity : MindfulnessActivity
{
    public RespiratoryActivity() : base("Respiratory Activity", "This activity will help you relax by focusing on your breathing.")
    {
    }

    protected override void PerformActivity(int durationSeconds)
    {
        Console.WriteLine("Starting respiratory activity...");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        int secondsRemaining = durationSeconds;
        while (secondsRemaining > 0)
        {
            Console.WriteLine("Inhale...");
            Thread.Sleep(5000); // Pause for 5 second
            Console.WriteLine("Exhale...");
            Thread.Sleep(6000); // Pause for 6 second
            secondsRemaining -= 2;
        }

        Console.WriteLine("Respiratory activity completed.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Listing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Respiratory Activity");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        }

        int durationMinutes;
        do
        {
            Console.WriteLine("Enter the duration in minutes:");
        } while (!int.TryParse(Console.ReadLine(), out durationMinutes) || durationMinutes <= 0);

        switch (choice)
        {
            case 1:
                var listingActivity = new ListingActivity();
                listingActivity.RunActivity(durationMinutes);
                break;
            case 2:
                var reflectionActivity = new ReflectionActivity();
                reflectionActivity.RunActivity(durationMinutes);
                break;
            case 3:
                var respiratoryActivity = new RespiratoryActivity();
                respiratoryActivity.RunActivity(durationMinutes);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
}
