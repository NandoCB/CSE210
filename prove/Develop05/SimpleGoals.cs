using System;
using System.Collections.Generic;

class SimpleGoals
{
    public static void CreateSimpleGoal(List<Goal> goals)
    {
        Console.Write("What is the name of your goal: ");
        string goalName = Console.ReadLine();

        Console.Write("Write a short description of your goal: ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal: ");
        int goalPoints = int.Parse(Console.ReadLine());

        Goal newGoal = new Goal
        {
            Type = "Simple Goals",
            Name = goalName,
            Description = goalDescription,
            Points = goalPoints
        };

        goals.Add(newGoal);

        Console.WriteLine("Simple Goal created successfully!");
    }
}


