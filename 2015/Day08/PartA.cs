using System.Text.RegularExpressions;

namespace Day08;

internal static class PartA
{
  public static void Run()
  {
    string[] stringLiterals = Program.ReadPrompt();

    uint memoryLength = 0;
    uint literalLength = 0;

    foreach (string stringLiteral in stringLiterals)
    {
      // Count literal characters before modification
      literalLength += Program.CountLiteralCharacters(stringLiteral);

      // Simplify string by replacing escape sequences by *
      string simplified = ClearNormalEscapeSequence(stringLiteral);
      simplified = ClearHexSequence(simplified);

      // Count simplified characters
      memoryLength += Program.CountLiteralCharacters(simplified) - 2; // -2 to remove left and right double quotes
    }

    System.Console.WriteLine(literalLength - memoryLength);
  }

  private static string ClearHexSequence(in string input)
  {
    Regex rx = Program.HexRegex();
    return rx.Replace(input, "*");
  }

  private static string ClearNormalEscapeSequence(in string input) =>
    input
    .Replace("\\\\", "*")
    .Replace("\\\"", "*");
}
