using System;

public class ConsoleCalculator : IHelpable
{
    public void Calculator()
    {
        Console.WriteLine("Welcome to the MathWiz!");
        Console.WriteLine("Enter 'help' for help at any time: ");

        // Boolean to continue
        bool continueCalculating = true;
        while (continueCalculating)
        {
            Console.Write("Enter the first number: ");
            string operandNumberString = ScannerProcessDouble.GetString();
            if (operandNumberString.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                PrintHelp();
                continue;
            }

            string operatorString = "";
            Operators op = default; // Use 'default' for non-nullable enum
            while (op == default)
            {
                Console.Write("Enter an operation (+, -, *, /, ^, r, %): ");
                operatorString = Console.ReadLine().Trim();
                if (operatorString.Equals("help", StringComparison.OrdinalIgnoreCase))
                {
                    PrintHelp();
                    continue;
                }
                op = OperatorsExtensions.OnlySymbol(operatorString);
                if (op == default)
                {
                    Console.WriteLine("Invalid operator, please try again.");
                }
            }

            Console.Write("Enter a second number: ");
            string secondNumberString = ScannerProcessDouble.GetString();

            if (operandNumberString == null || string.IsNullOrEmpty(operatorString) || secondNumberString == null)
            {
                continue;
            }
            else if (secondNumberString.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                PrintHelp();
            }

            double operandNumber = double.Parse(operandNumberString);
            double operatorNumber = double.Parse(secondNumberString);

            // Handling operators from enum with switch and case
            double result;
            switch (op)
            {
                case Operators.ADD:
                    result = operandNumber + operatorNumber;
                    break;
                case Operators.SUBTRACT:
                    result = operandNumber - operatorNumber;
                    break;
                case Operators.MULTIPLY:
                    result = operandNumber * operatorNumber;
                    break;
                case Operators.DIVIDE:
                    result = operandNumber / operatorNumber;
                    break;
                case Operators.POWER:
                    result = Math.Pow(operandNumber, operatorNumber);
                    break;
                case Operators.ROOT:
                    result = Math.Pow(operandNumber, 1.0 / operatorNumber);
                    break;
                case Operators.MODULUS:
                    result = operandNumber % operatorNumber;
                    break;
                default:
                    Console.WriteLine("Invalid operator, please try again.");
                    return;
            }

            Console.WriteLine($"The result is: {result}");
            Console.WriteLine();

            Console.Write("Would you like to continue? (y/n): ");
            string continueString = Console.ReadLine().Trim();
            if (!continueString.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                continueCalculating = false;
            }
        }
    }

    public void PrintHelp()
    {
        Console.WriteLine("MathWiz Help");
        Console.WriteLine("Supported operations: +, -, *, /, ^, r, %");
        Console.WriteLine("To use Pi, enter 'pi'");
        Console.WriteLine("To use e as a number, enter 'e'");
        Console.WriteLine("To display this help message again, enter 'help'");
        Console.WriteLine();
    }
}

