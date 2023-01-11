namespace Day02;

internal static class PartA
{
  public static void Run()
  {
    // Read prompt
    string[] prompt = Program.ReadPrompt();

    // Total paper area
    int area = 0;

    // Calculate wrapping paper area for each present
    foreach (string dimension in prompt)
    {
      int[] dimensions = Program.ProcessDimensions(dimension);
      int[] uniqueArea = UniqueArea(dimensions);

      // Surface area of box = 2 * (lw + wh + hl)
      area += 2 * uniqueArea.Sum();

      // Extra wrapping = area of smallest side
      area += uniqueArea.Min();
    }

    // Print total wrapping paper area required
    Console.WriteLine(area);
  }

  // Calculate area of three unique sides [lw, wh, hl]
  private static int[] UniqueArea(int[] dimensions)
  {
    return new int[3] {
      dimensions[0] * dimensions[1], // length x width
      dimensions[1] * dimensions[2], // width x height
      dimensions[2] * dimensions[0], // height x length
    };
  }
}
