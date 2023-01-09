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
      floor = Program.FindNextFloor(floor, character);
    }

    // Print final floor
    Console.WriteLine(floor);
  }
}
