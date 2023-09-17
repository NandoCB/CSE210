using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter your grade percentage:" );
        string grade = Console.ReadLine();

        int percentage = int.Parse(grade);

            int score_last_digit = Math.Abs(percentage % 10);
            string sing = "";

            if (score_last_digit >= 7)
            {
                sing = "+";
            }
            else if (score_last_digit <= 3)
            {
                sing = "-";
            }
            else
            {
                sing = "";
            }

            if (percentage >= 0 && percentage <= 59 )
            {
                Console.WriteLine($"Your grade percent is {percentage}% and your letter grade is: F{sing}");
            }
            else if (percentage >= 60 && percentage <= 69)
            {
                Console.WriteLine($"Your grade percent is {percentage}% and your letter grade is: D{sing}");
            }
            else if (percentage >= 70 && percentage <= 79)
            {
                Console.WriteLine($"Your grade percent is {percentage}% and your letter grade is: C{sing}");
            }
            else if (percentage >= 80 && percentage <= 89)
            {
                Console.WriteLine($"Your grade percent is {percentage}% and your letter grade is: B{sing}");
            }
            else if (percentage >= 90 && percentage <= 100)
            {
                Console.WriteLine($"Your grade percent is {percentage}% and your letter grade is: A{sing}");
            }

            if (percentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the class!");
            }
            else
            {
                Console.WriteLine("Stay focused and you'll get it next time!");
            }
    }
}