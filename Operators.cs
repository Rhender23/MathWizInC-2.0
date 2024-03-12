using System;

public enum Operators
{
    ADD,
    SUBTRACT,
    MULTIPLY,
    DIVIDE,
    POWER,
    ROOT,
    MODULUS
}

public static class OperatorsExtensions
{
    public static string GetSymbol(this Operators op)
    {
        switch (op)
        {
            case Operators.ADD:
                return "+";
            case Operators.SUBTRACT:
                return "-";
            case Operators.MULTIPLY:
                return "*";
            case Operators.DIVIDE:
                return "/";
            case Operators.POWER:
                return "^";
            case Operators.ROOT:
                return "r";
            case Operators.MODULUS:
                return "%";
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }

    public static Operators OnlySymbol(string symbol)
    {
        foreach (Operators op in Enum.GetValues(typeof(Operators)))
        {
            if (op.GetSymbol().Equals(symbol, StringComparison.OrdinalIgnoreCase))
            {
                return op;
            }
        }
        return default(Operators);
    }

    public static double Calculate(this Operators op, double inputNumberOperand, double inputNumberOperator)
    {
        switch (op)
        {
            case Operators.ADD:
                return inputNumberOperand + inputNumberOperator;
            case Operators.SUBTRACT:
                return inputNumberOperand - inputNumberOperator;
            case Operators.MULTIPLY:
                return inputNumberOperand * inputNumberOperator;
            case Operators.DIVIDE:
                return inputNumberOperand / inputNumberOperator;
            case Operators.POWER:
                return Math.Pow(inputNumberOperand, inputNumberOperator);
            case Operators.ROOT:
                return Math.Pow(inputNumberOperand, 1.0 / inputNumberOperator);
            case Operators.MODULUS:
                return inputNumberOperand % inputNumberOperator;
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }
}
