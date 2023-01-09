namespace Day01;

internal static class PartA
{
  public static void Run()
  {
    // Read prompt
    string prompt = Program.ReadPrompt();

    // Count number of '(' and ')'
    int floor = 0;

    foreach (char character in prompt)
    {

      if (character.Equals('(')) { floor++; continue; }
      if (character.Equals(')')) { floor--; continue; }

      // Reaching here implies unexpected input
      throw new InvalidDataException();
    }

    // Print final floor
    Console.WriteLine(floor);
  }
}
