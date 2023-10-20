using System;

class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.Start();
    }
}

abstract class Operation
{
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
            Console.WriteLine("Error: No se puede dividir por cero.");
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
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Potencia");
            Console.WriteLine("6. Raíz");
            Console.WriteLine("0. Salir");

            Console.Write("Elija una opción: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                break;
            }

            if (choice >= 1 && choice <= 6)
            {
                Console.Write("Ingrese el primer número: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Ingrese el segundo número: ");
                double y = double.Parse(Console.ReadLine());

                double result = operations[choice - 1].Execute(x, y);
                Console.WriteLine($"Resultado: {result}");
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
