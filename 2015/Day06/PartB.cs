namespace Day06;

internal static class PartB
{
  public static void Run()
  {
    // Read prompt
    string[] prompt = Program.ReadPrompt();

    // Initialize a matrix with all lights set to 0
    const int xLights = 1000;
    const int yLights = 1000;
    int[,] lightMatrix = new int[xLights, yLights]; // 0 by default

    // Iterate over all instruction and apply them to the light matrix
    foreach (string line in prompt)
    {
      // Parse instruction
      Instruction instruction = Program.ParseInstruction(line);

      // Apply instruction to light matrix
      for (int y = 0; y < yLights; y++)
      {
        // Check for y-bound
        bool yBox = y < instruction.TopLeftCoordinate[1] || y > instruction.BottomRightCoordinate[1];
        if (yBox) { continue; }

        for (int x = 0; x < xLights; x++)
        {
          // Check for x-bound
          bool xBox = x < instruction.TopLeftCoordinate[0] || x > instruction.BottomRightCoordinate[0];
          if (xBox) { continue; }

          // Reaching here implies the coordinate [y, i] is inside coordinate box -> apply action
          lightMatrix[y, x] = ApplyAction(lightMatrix[y, x], instruction.Action);
        }
      }
    }

    // Add light intensity after all actions are applied
    int totalIntensity = 0;
    for (int y = 0; y < yLights; y++)
    {
      for (int x = 0; x < xLights; x++)
      {
        totalIntensity += lightMatrix[y, x];
      }
    }

    // Print sum of all light intensities
    Console.WriteLine(totalIntensity);
  }

  // Apply action
  private static int ApplyAction(int lightIntensity, SwitchAction action)
  {
    // Special case where light intensity is already zero and turn off action is applied
    if (lightIntensity == 0 && action is SwitchAction.TurnOff) { return 0; }

    // Normal operation
    return action switch
    {
      SwitchAction.Toggle => lightIntensity + 2,
      SwitchAction.TurnOn => lightIntensity + 1,
      SwitchAction.TurnOff => lightIntensity - 1,
      _ => throw new InvalidDataException(),
    };
  }
}
