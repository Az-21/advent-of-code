namespace Day05;

internal static class PartB
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
    if (ContainsCharacterSandwich(input) is false) { return false; }
    if (ContainsRepeatingCharacterPair(input) is false) { return false; }

    // Reaching here implies input string satisfies all conditions and it is "nice"
    return true;
  }

  // Check for repeating pair of characters (non-overlapping)
  private static bool ContainsRepeatingCharacterPair(string input)
  {
    for (int i = 0; i < input.Length - 3; i++) // `length - 3` to ensure last pair is 2 units behind last pair
    {
      string pair = input[i..(i + 2)]; // Pair of characters
      string rightSubstring = input[(i + 2)..]; // Everything to right of current pair

      // Check if pair also exists in the right substring | Ensures non-overlapping match
      bool pairRepeats = rightSubstring.IndexOf(pair) >= 0; // Equivalent to .Contains()
      if (pairRepeats) { return true; }
    }

    // Reaching here implies input string never repeats character pair
    return false;
  }

  // Check for character sandwich (x-y-x)
  private static bool ContainsCharacterSandwich(string input)
  {
    for (int i = 0; i < input.Length - 2; i++) // `length - 2` to ensure triad sub-arrays don't overflow
    {
      string triad = input[i..(i + 3)]; // Triad of characters
      if (triad[0] == triad[2]) { return true; } // Check for sandwich condition
    }

    // Reaching here implies input string does not contain any character sandwich
    return false;
  }
}
