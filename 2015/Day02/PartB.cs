namespace Day02;

internal static class PartB
{
  public static void Run()
  {
    // Read prompt
    string[] prompt = Program.ReadPrompt();

    // Total ribbon length
    int length = 0;

    // Calculate wrapping paper area for each present
    foreach (string dimension in prompt)
    {
      int[] dimensions = Program.ProcessDimensions(dimension);


      // Add ribbon length of two shortest sides, twice
      Array.Sort(dimensions); // Sort first to ensure [0] and [1] are shortest
      length += 2 * (dimensions[0] + dimensions[1]);

      // Add ribbon length equal to the volume of box
      length += dimensions[0] * dimensions[1] * dimensions[2]; // l*w*h
    }

    // Print length of ribbon required
    Console.WriteLine(length);
  }
}
