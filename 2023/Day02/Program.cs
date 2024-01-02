using System.Text.RegularExpressions;
using Utility;
namespace Day02;

readonly record struct Cube(int RedCount, int GreenCount, int BlueCount);
readonly record struct Game(int Id, List<Cube> Cubes);

internal static partial class Program
{
  static void Main()
  {
    string[] prompt = Helper.ReadPromptLines();

    // Part A
    Cube threshold = new(12, 13, 14);
    int sigma = 0;
    foreach (string line in prompt)
    {
      int id = CaptureGameId(line);
      List<Cube> cubes = CaptureCubes(line);
      Game game = new(id, cubes);
      sigma += GetGameIdIfValid(game, threshold);
    }
    Console.WriteLine($"Part A: {sigma}");

    // Part B
    int power = 0;
    foreach (string line in prompt)
    {
      List<Cube> cubes = CaptureCubes(line);
      power += CalculatePower(cubes);
    }
    Console.WriteLine($"Part B: {power}");
  }

  static int CaptureGameId(in string input)
  {
    int leftbound = 5;
    int rightbound = input.IndexOf(':');
    return int.Parse(input[leftbound..rightbound]);
  }

  // Compiled regex patterns
  [GeneratedRegex(@"\d+ red")]
  private static partial Regex RedRegex();
  [GeneratedRegex(@"\d+ green")]
  private static partial Regex GreenRegex();
  [GeneratedRegex(@"\d+ blue")]
  private static partial Regex BlueRegex();

  static List<Cube> CaptureCubes(in string input)
  {
    string[] subsets = input.Split(';');
    List<Cube> cubes = [];

    foreach (string subset in subsets)
    {
      // Match red
      int red = 0;
      Regex redRx = RedRegex();
      Match mR = redRx.Match(subset);
      if (mR.Success) { red = int.Parse(mR.Value.Replace(" red", "")); }

      // Match green
      int green = 0;
      Regex greenRx = GreenRegex();
      Match mG = greenRx.Match(subset);
      if (mG.Success) { green = int.Parse(mG.Value.Replace(" green", "")); }

      // Match blue
      int blue = 0;
      Regex blueRx = BlueRegex();
      Match mB = blueRx.Match(subset);
      if (mB.Success) { blue = int.Parse(mB.Value.Replace(" blue", "")); }

      // Append
      Cube cube = new(red, green, blue);
      cubes.Add(cube);
    }

    return cubes;
  }

  // Returns game ID if game is valid, otherwise 0
  static int GetGameIdIfValid(in Game game, in Cube threshold)
  {
    foreach (Cube cube in game.Cubes)
    {
      if (cube.RedCount > threshold.RedCount) { return 0; }
      if (cube.GreenCount > threshold.GreenCount) { return 0; }
      if (cube.BlueCount > threshold.BlueCount) { return 0; }
    }

    return game.Id;
  }

  // Returns 'cube power' based on fewest number of cubes of each color
  static int CalculatePower(in List<Cube> cubes)
  {
    int[] minCube = [0, 0, 0];

    foreach (Cube cube in cubes)
    {
      minCube[0] = Math.Max(cube.RedCount, minCube[0]);
      minCube[1] = Math.Max(cube.GreenCount, minCube[1]);
      minCube[2] = Math.Max(cube.BlueCount, minCube[2]);
    }

    return minCube[0] * minCube[1] * minCube[2];
  }
}
