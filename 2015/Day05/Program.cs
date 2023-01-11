namespace Day05;

public static class Program
{
  static void Main()
  {
    string part = "A";
    if (part == "A") { PartA.Run(); }
    if (part == "B") { PartB.Run(); }
  }

  // Read file containing the prompt -> split by newlines
  public static string[] ReadPrompt()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename).ToLower(); // Ensure everything is in lowercase
    const string separator = "\r\n"; // Prompt values are separated by CR LF
    return prompt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }

  // Check a string against "bad" substrings
  public static bool ContainsForbiddenSubstrings(string input)
  {
    // List of "bad" substrings
    string[] forbiddenSubstrings = { "ab", "cd", "pq", "xy" };

    // Using .IndexOf() instead of .Contains() for better performance | We just need boolean
    return forbiddenSubstrings.Any(substring => input.IndexOf(substring) >= 0);
  }

  // Ensure a string contains at least three vowels
  public static bool HasAtLeastThreeVowels(string input)
  {
    HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u' };
    int vowelCount = input.Count(c => vowels.Contains(c));
    return vowelCount >= 3;
  }

  // Check a string against double characters
  public static bool ContainsDoubleCharacter(string input)
  {
    // List of double substrings
    string[] doubleSubstrings =
      Enumerable.Range('a', 26) // Start at ASCII 'a' -> End at 'a'+26 == 'z'
                .Select(x => ((char)x).ToString() + ((char)x).ToString())
                .ToArray();

    // Using .IndexOf() instead of .Contains() for better performance | We just need boolean
    return doubleSubstrings.Any(substring => input.IndexOf(substring) >= 0);
  }
}
