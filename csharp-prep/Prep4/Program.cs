using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int input = int.Parse(Console.ReadLine());

            if (input == 0)
                break;

            numbers.Add(input);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        int sum = calculate_sum(numbers);
        double average = CalculateAverage(numbers);
        int max = FindMax(numbers);

        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + max);

        // Stretch Challenge
        List<int> positiveNumbers = FindPositiveNumbers(numbers);

        if (positiveNumbers.Count > 0)
        {
            int smallestPositive = FindSmallestPositive(positiveNumbers);
            Console.WriteLine("The smallest positive number is: " + smallestPositive);

            Console.WriteLine("The sorted list is:");
            positiveNumbers.Sort();
            foreach (int number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No positive numbers entered.");
        }
    }

    static int calculate_sum(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    static double CalculateAverage(List<int> numbers)
    {
        int sum = calculate_sum(numbers);
        return (double)sum / numbers.Count;
    }

    static int FindMax(List<int> numbers)
    {
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > max)
                max = number;
        }
        return max;
    }

    static List<int> FindPositiveNumbers(List<int> numbers)
    {
        List<int> positiveNumbers = new List<int>();
        foreach (int number in numbers)
        {
            if (number > 0)
                positiveNumbers.Add(number);
        }
        return positiveNumbers;
    }

    static int FindSmallestPositive(List<int> positiveNumbers)
    {
        int smallestPositive = int.MaxValue;
        foreach (int number in positiveNumbers)
        {
            if (number < smallestPositive)
                smallestPositive = number;
        }
        return smallestPositive;
    }
}