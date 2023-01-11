namespace Day05;

internal static class PartA
{
  public static void Run()
  {
    // Read prompt
    string[] prompt = Program.ReadPrompt();

    // Tracker for "nice" strings
    int niceStrings = 0;

    // Iterate over given strings -> check if nice -> increment counter
    foreach (string line in prompt)
    {
      bool isNiceString = IsNiceString(line);
      if (isNiceString) { niceStrings++; }
    }

    // Print number of "nice" strings
    Console.WriteLine(niceStrings);
  }

  // Perform checks for nice strings
  private static bool IsNiceString(string input)
  {
    if (ContainsForbiddenSubstrings(input) is true) { return false; }
    if (ContainsDoubleCharacter(input) is false) { return false; }
    if (HasAtLeastThreeVowels(input) is false) { return false; }

    // Reaching here implies input string is "nice"
    return true;
  }

  // Check a string against "bad" substrings
  private static bool ContainsForbiddenSubstrings(string input)
  {
    // List of "bad" substrings
    string[] forbiddenSubstrings = { "ab", "cd", "pq", "xy" };

    // Using .IndexOf() instead of .Contains() for better performance | We just need boolean
    return forbiddenSubstrings.Any(substring => input.IndexOf(substring) >= 0);
  }

  // Ensure a string contains at least three vowels
  private static bool HasAtLeastThreeVowels(string input)
  {
    HashSet<char> vowels = new() { 'a', 'e', 'i', 'o', 'u' };
    int vowelCount = input.Count(c => vowels.Contains(c));
    return vowelCount >= 3;
  }

  // Check a string against double characters
  private static bool ContainsDoubleCharacter(string input)
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
