namespace Day01;

public static class Program
{
  static void Main()
  {
    string part = "B";
    if (part == "A") { PartA.Run(); }
    if (part == "B") { PartB.Run(); }
  }

  // Read file containing the prompt
  public static string ReadPrompt()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename);
    return prompt.Trim();
  }

  // Handle floor increment/decrement logic
  public static int FindNextFloor(int currentFloor, char movement)
  {
    if (movement.Equals('(')) { return currentFloor + 1; }
    if (movement.Equals(')')) { return currentFloor - 1; }

    // Reaching here implies unexpected input
    throw new InvalidDataException($"Unexpected movement code: {movement}");
  }
}
