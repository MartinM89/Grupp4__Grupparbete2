using System.Net;

public class Color
{
    public static void TextGreen(string input)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(input);
        Console.ResetColor();
    }
    public static void TextRed(string input)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(input);
        Console.ResetColor();
    }
    public static void TextYellow(string input)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(input);
        Console.ResetColor();
    }
    public static void TextCyan(string input)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(input);
        Console.ResetColor();
    }

    public static void TextPurple(string input)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(input);
        Console.ResetColor();
    }

    public static void TextBlue(string input)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(input);
        Console.ResetColor();
    }
}