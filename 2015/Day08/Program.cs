using System.Text.RegularExpressions;

namespace Day08;

static partial class Program
{
  static void Main() => PartB.Run();

  // Read file containing the prompt -> split by newlines
  public static string[] ReadPrompt()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename).ToLower();
    const string separator = "\r\n"; // Prompt values are separated by CR LF
    return prompt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }

  // Literal number of characters "abc" -> 5
  public static uint CountLiteralCharacters(in string input) => (uint)input.Length;

  // HEX sequence (\x##)
  [GeneratedRegex("\\\\x[0-9A-Fa-f]{2}", RegexOptions.Compiled)]
  public static partial Regex HexRegex();
}
