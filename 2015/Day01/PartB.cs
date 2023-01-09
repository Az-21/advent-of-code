namespace Day01;

internal class PartB
{
  public static void Run()
  {
    // Read prompt
    string prompt = Program.ReadPrompt();

    // Count number of '(' and ')'
    int floor = 0;

    // Tracker for action which causes the movement to basement
    int actionNumber = 0;

    foreach (char character in prompt)
    {
      floor = Program.FindNextFloor(floor, character);

      actionNumber++; // Action number tracker
      if (floor == -1) { break; } // Break at current action number
    }

    // Print action number which moves Santa into basement
    Console.WriteLine(actionNumber);
  }
}
