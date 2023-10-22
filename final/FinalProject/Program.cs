using System;

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.Start();
    }
}

abstract class Operation // Abstract class to define a generic operation.
{
    //Concrete classes that inherit from Operation and provide specific implementations for each operation.
    public abstract double Execute(double x, double y);
}

class Addition : Operation
{
    public override double Execute(double x, double y)
    {
        return x + y;
    }
}

class Subtraction : Operation
{
    public override double Execute(double x, double y)
    {
        return x - y;
    }
}

class Multiplication : Operation
{
    public override double Execute(double x, double y)
    {
        return x * y;
    }
}

class Division : Operation
{
    public override double Execute(double x, double y)
    {
        if (y == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return 0;
        }
        return x / y;
    }
}

class PowerOperation : Operation
{
    public override double Execute(double x, double y)
    {
        return Math.Pow(x, y);
    }
}

class RootOperation : Operation
{
    public override double Execute(double x, double y)
    {
        return Math.Pow(x, 1.0 / y);
    }
}

class Calculator
{
    private Operation[] operations;

    //Initializes an array of operations with the concrete classes of operations.
    public Calculator()
    {
        operations = new Operation[]
        {
            new Addition(),
            new Subtraction(),
            new Multiplication(),
            new Division(),
            new PowerOperation(),
            new RootOperation()
        };
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("CSE210 - Calculator:");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Power");
            Console.WriteLine("6. Root");
            Console.WriteLine("0. Exit");

            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)    //Exit the loop if option 0 is chosen.
            {
                break;
            }

            if (choice >= 1 && choice <= 6)
            {
                Console.Write("Enter the first number [addend, minuend, multiplicand, divident, base, radicand]: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Enter the second number [addend, subtrahend, multiplicator, divident, exponent, index]: ");
                double y = double.Parse(Console.ReadLine());

                            // Executes the selected operation and displays the result.
                double result = operations[choice - 1].Execute(x, y);
                Console.WriteLine($"Resultado: {result}");
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}
