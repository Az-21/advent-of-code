namespace Day08;

internal static class PartB
{
  public static void Run()
  {
    string[] stringLiterals = Program.ReadPrompt();

    uint literalLength = 0;
    uint encodedLength = 0;

    foreach (string stringLiteral in stringLiterals)
    {
      // Count literal characters before modification
      literalLength += Program.CountLiteralCharacters(stringLiteral);

      // Encode " and \
      string encoded = EncodeSpecialCharacters(stringLiteral);
      encodedLength += (uint)encoded.Length + 2; // +2 to surround with "
    }

    System.Console.WriteLine(encodedLength - literalLength);
  }

  private static string EncodeSpecialCharacters(in string input) =>
  input
  .Replace("\\", "\\\\")
  .Replace("\"", "\\\"");
}
