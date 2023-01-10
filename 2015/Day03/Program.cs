namespace Day03;

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

  // Generate position coordinates in Cartesian form
  public static string GenerateCartesianCoordinates(int[] coordinates)
  {
    int x = coordinates[0];
    int y = coordinates[1];

    return $"({x},{y})";
  }

  // Find next set of coordinates based on current position and movement
  public static int[] NextCoordinate(int[] currentCoordinates, char movement)
  {
    int x = currentCoordinates[0];
    int y = currentCoordinates[1];

    if (movement.Equals('^')) { return new int[2] { x, y + 1 }; }
    if (movement.Equals('v')) { return new int[2] { x, y - 1 }; }
    if (movement.Equals('<')) { return new int[2] { x - 1, y }; }
    if (movement.Equals('>')) { return new int[2] { x + 1, y }; }

    // Reaching here implies unexpected input/movement
    throw new InvalidDataException();
  }
}
