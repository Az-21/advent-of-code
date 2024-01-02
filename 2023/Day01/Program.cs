using Utility;
namespace Day01;

internal static class Program
{
  static void Main()
  {
    string[] prompt = Helper.ReadPromptLines();

    // Part A
    int sigma = 0;
    foreach (string line in prompt) { sigma += CalculateCalibrationValue(line); }
    Console.WriteLine($"Part A: {sigma}");

    // Part B
    sigma = 0;
    foreach (string line in prompt)
    {
      string normalizedLine = ProcessNamedNumbers(line);
      sigma += CalculateCalibrationValue(normalizedLine);
    }
    Console.WriteLine($"Part B: {sigma}");
  }

  static int CalculateCalibrationValue(in string input)
  {
    // Left value
    int pointer = 0;
    int leftValue;
    while (true)
    {
      char c = input[pointer];
      if (char.IsDigit(c)) { leftValue = c - '0'; break; }
      pointer++;
    }

    // Right value
    pointer = input.Length - 1;
    int rightValue;
    while (true)
    {
      char c = input[pointer];
      if (char.IsDigit(c)) { rightValue = c - '0'; break; }
      pointer--;
    }

    return (10 * leftValue) + rightValue;
  }

  static string ProcessNamedNumbers(in string input)
  {
    // one -> o1e preserves the leftmost and rightmost characters
    // This helps in cases like eighthree | eight3e | e8t3e
    return input
      .Replace("one", "o1e")
      .Replace("two", "t2o")
      .Replace("three", "t3e")
      .Replace("four", "f4r")
      .Replace("five", "f5e")
      .Replace("six", "s6x")
      .Replace("seven", "s7n")
      .Replace("eight", "e8t")
      .Replace("nine", "n9n");
  }
}
