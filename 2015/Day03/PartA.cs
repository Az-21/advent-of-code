namespace Day03;

internal static class PartA
{
  public static void Run()
  {
    // Read prompt
    string prompt = Program.ReadPrompt();

    // Create a dictionary to hold (x, y) coordinates of house and number of presents
    Dictionary<string, int> tracker = new();

    // Initialize coordinates of house assuming Santa starts at origin
    int[] coordinates = new int[2] { 0, 0 };

    // Add origin position to dictionary
    tracker.Add(Program.GenerateCartesianCoordinates(coordinates), 1);

    // Iterate over the movement of Santa
    foreach (char movement in prompt)
    {
      // Get next coordinate  
      coordinates = Program.NextCoordinate(coordinates, movement);

      // Check if the coordinate exists in tracker dictionary -> increment number of gifts
      string cartesianCoordinates = Program.GenerateCartesianCoordinates(coordinates);
      if (tracker.ContainsKey(cartesianCoordinates)) { tracker[cartesianCoordinates]++; }

      // Otherwise append a new entry with gifts received set to 1
      else { tracker.Add(cartesianCoordinates, 1); }
    }

    // Print length of the tracker list to get number of unique houses visited
    Console.WriteLine(tracker.Count);
  }
}