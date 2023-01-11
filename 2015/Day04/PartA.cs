namespace Day04;

internal static class PartA
{
  public static void Run()
  {
    // Input from AoC
    const int leadingZeros = 5;
    const string prompt = "iwrupvqb";

    // Run suffix miner
    int suffix = Program.CrackSecretSuffix(prompt, leadingZeros);

    // Print the suffix which generated the required number of leading zeros
    Console.WriteLine(suffix);
  }
}
