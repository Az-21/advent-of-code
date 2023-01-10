namespace Day03;

internal static class PartB
{
  public static void Run()
  {
    // Read prompt
    string prompt = Program.ReadPrompt();

    // Create a dictionary to hold (x, y) coordinates of house and number of presents
    Dictionary<string, int> tracker = new();

    // Initialize coordinates of house assuming Santa and Robot start at origin
    int[] santaCoordinates = new int[2] { 0, 0 };
    int[] robotCoordinates = new int[2] { 0, 0 };

    // Add origin position to dictionary | set gifts to 2 because both Robot and Santa start there
    tracker.Add(Program.GenerateCartesianCoordinates(santaCoordinates), 2);

    // String to temporarily hold Cartesian coordinates
    string cartesianCoordinates;

    // Iterate over the movement of Santa and Robot in steps of two to account for both movements
    for (int i = 0; i < prompt.Length; i += 2)
    {
      // Santa's movement -> [i]
      santaCoordinates = Program.NextCoordinate(santaCoordinates, prompt[i]);
      cartesianCoordinates = Program.GenerateCartesianCoordinates(santaCoordinates); // Santa
      if (tracker.ContainsKey(cartesianCoordinates)) { tracker[cartesianCoordinates]++; }
      else { tracker.Add(cartesianCoordinates, 1); }

      // Robot's movement -> [i+1]
      robotCoordinates = Program.NextCoordinate(robotCoordinates, prompt[i + 1]);
      cartesianCoordinates = Program.GenerateCartesianCoordinates(robotCoordinates); // Robot
      if (tracker.ContainsKey(cartesianCoordinates)) { tracker[cartesianCoordinates]++; }
      else { tracker.Add(cartesianCoordinates, 1); }
    }

    // Print length of the tracker list to get number of unique houses visited
    Console.WriteLine(tracker.Count);
  }
}