using System;
using System.Collections.Generic;

class ChecklistGoals
{
    public static void CreateChecklistGoal(List<Goal> goals)
    {
        Console.Write("What is the name of your checklist goal: ");
        string goalName = Console.ReadLine();

        Console.Write("Write a short description of your checklist goal: ");
        string goalDescription = Console.ReadLine();

        Console.Write("What is the amount of points associated with this checklist goal: ");
        int goalPoints = int.Parse(Console.ReadLine());

        Console.Write("How many times does this goal need to be accomplished for a bonus: ");
        int bonusThreshold = int.Parse(Console.ReadLine());

        Console.Write("What's the bonus for accomplishing it that many times: ");
        int bonusAmount = int.Parse(Console.ReadLine());

        ChecklistGoal newGoal = new ChecklistGoal
        {
            Type = "Checklist Goals",
            Name = goalName,
            Description = goalDescription,
            Points = goalPoints,
            BonusThreshold = bonusThreshold,
            BonusAmount = bonusAmount
        };

        goals.Add(newGoal);

        Console.WriteLine("Checklist Goal created successfully!");
    }
}





