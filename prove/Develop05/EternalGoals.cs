using System;
using System.Collections.Generic;

class EternalGoals
{
    public static void CreateEternalGoal(List<Goal> goals)
    {
        Console.Write("What is the name of your eternal goal: ");
        string goalName = Console.ReadLine();

        Console.Write("Write a short description of your eternal goal: ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this eternal goal: ");
        int goalPoints = int.Parse(Console.ReadLine());

        Goal newGoal = new Goal
        {
            Type = "Eternal Goals",
            Name = goalName,
            Description = goalDescription,
            Points = goalPoints
        };

        goals.Add(newGoal);

        Console.WriteLine("Eternal Goal created successfully!");
    }
}