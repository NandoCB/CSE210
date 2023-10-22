using System;
using System.Collections.Generic;

class Menu
{
    public static void Main(string[] args)
    {
        ShowMenu();
    }

    public static void ShowMenu()
    {
        bool isRunning = true;
        List<Goal> goals = new List<Goal>();

        while (isRunning)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal(goals);
                    break;
                case 2:
                    ListGoals(goals);
                    break;
                case 3:
                    // Implement saving goals functionality
                    Console.WriteLine("Saving goals...");
                    SaveGoals.SaveGoalsToFile(goals);
                    break;
                case 4:
                    // Implement loading goals functionality
                    Console.WriteLine("Loading goals...");
                    LoadGoals(goals);
                    break;
                case 5:
                    // Implement recording events functionality
                    Console.WriteLine("Recording event...");
                    break;
                case 6:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateNewGoal(List<Goal> goals)
    {
        Console.WriteLine("Types of goals are:");
        Console.WriteLine("1. Simple Goals");
        Console.WriteLine("2. Eternal Goals");
        Console.WriteLine("3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? [1 / 2 / 3]: ");
        int typeChoice = int.Parse(Console.ReadLine());

        string goalType = "";

        switch (typeChoice)
        {
            case 1:
                goalType = "Simple Goals";
                SimpleGoals.CreateSimpleGoal(goals);
                break;
            case 2:
                goalType = "Eternal Goals";
                EternalGoals.CreateEternalGoal(goals);
                break;
            case 3:
                goalType = "Checklist Goals";
                ChecklistGoals.CreateChecklistGoal(goals);
                break;
            default:
                Console.WriteLine("Invalid choice. Creating a Simple Goal by default.");
                SimpleGoals.CreateSimpleGoal(goals);
                break;
        }
    }

    static void ListGoals(List<Goal> goals)
{
    if (goals.Count == 0)
    {
        Console.WriteLine("There are no goals saved in the system. Enter a goal first.");
    }
    else
    {
        Console.WriteLine("List of Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine($"Type: {goal.Type}");
            Console.WriteLine($"Name: {goal.Name}");
            Console.WriteLine($"Description: {goal.Description}");
            Console.WriteLine($"Points: {goal.Points}");
            Console.WriteLine();
        }
    }
}

 static void LoadGoals(List<Goal> goals)
{
    Console.Write("What is the filename for the goal file: ");
    string filename = Console.ReadLine();

    if (File.Exists(filename))
    {
        // Lee y muestra los datos del archivo en pantalla
        try
        {
            string[] lines = File.ReadAllLines(filename);

            Console.WriteLine("Loaded Goals:");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    string date = parts[0];
                    string name = parts[1];
                    string type = parts[2];
                    string description = parts[3];
                    int points = int.Parse(parts[4]);

                    Console.WriteLine($"Date: {date}");
                    Console.WriteLine($"Type: {type}");
                    Console.WriteLine($"Name: {name}");
                    Console.WriteLine($"Description: {description}");
                    Console.WriteLine($"Points: {points}");
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }
    }
    else
    {
        Console.WriteLine("The specified file does not exist.");
    }

    // Espera a que el usuario presione Enter antes de volver al menú
    Console.WriteLine("Press Enter to return to the menu...");
    Console.ReadLine();
}
}