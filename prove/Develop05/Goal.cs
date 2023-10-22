using System;

public class Goal
{
    public string Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
}

public class ChecklistGoal : Goal
{
    public int BonusThreshold { get; set; }
    public int BonusAmount { get; set; }
}

/*
public class ChecklistGoals
{
    public static void CreateChecklistGoal(List<Goal> goals)
    {
        // Resto del código para crear una ChecklistGoal
    }
}*/
