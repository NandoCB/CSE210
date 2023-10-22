using System;
using System.Collections.Generic;
using System.IO;

class SaveGoals
{
    public static void SaveGoalsToFile(List<Goal> goals)
    {
        Console.Write("What is the filename for the Goal file: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in goals)
            {
                string line = $"{DateTime.Now},{goal.Name},{goal.Type},{goal.Description},{goal.Points}";

                if (goal is ChecklistGoal checklistGoal)
                {
                    line += $",{checklistGoal.BonusThreshold},{checklistGoal.BonusAmount}";
                }

                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Goals saved to the file successfully.");
    }
}
