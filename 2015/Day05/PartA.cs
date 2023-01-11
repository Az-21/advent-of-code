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
    if (Program.ContainsForbiddenSubstrings(input) is true) { return false; }
    if (Program.ContainsDoubleCharacter(input) is false) { return false; }
    if (Program.HasAtLeastThreeVowels(input) is false) { return false; }

    // Reaching here implies input string is "nice"
    return true;
  }
}
