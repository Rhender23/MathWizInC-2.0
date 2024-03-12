using System;

public class ScannerProcessDouble : IHelpable
{
    public static string ConfirmDouble(string inputString)
    {
        string doubleToStringReturnValue = "";
        try
        {
            double parseDoubleResult = double.Parse(inputString);
            doubleToStringReturnValue = parseDoubleResult.ToString();
        }
        catch (ArgumentNullException)
        {
            doubleToStringReturnValue = null;
        }
        catch (FormatException)
        {
            doubleToStringReturnValue = null;
        }
        catch (Exception)
        {
            doubleToStringReturnValue = null;
        }
        return doubleToStringReturnValue;
    }

    public static string GetString()
    {
        string confirmDoubleResult = "";
        ScannerProcessDouble scannerHelp = new ScannerProcessDouble();

        while (true)
        {
            string preNumberString = Console.ReadLine();

            if (preNumberString.Trim().Equals("PI", StringComparison.OrdinalIgnoreCase))
            {
                confirmDoubleResult = Math.PI.ToString();
                break;
            }
            else if (preNumberString.Trim().Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                confirmDoubleResult = Math.E.ToString();
                break;
            }
            else if (preNumberString.Trim().Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                scannerHelp.PrintHelp();
            }
            else
            {
                confirmDoubleResult = ConfirmDouble(preNumberString);
                if (confirmDoubleResult != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("You have entered an invalid entry, please try again.");
                }
            }
        }

        return confirmDoubleResult;
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
