namespace Day02;

public static class Program
{
  static void Main()
  {
    string part = "B";
    if (part == "A") { PartA.Run(); }
    if (part == "B") { PartB.Run(); }
  }

  // Read file containing the prompt -> split by newlines
  public static string[] ReadPrompt()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename);
    const string separator = "\r\n"; // Prompt values are separated by CR LF
    return prompt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }

  // Separate dimension string on 'x' and return dimensions as int array
  public static int[] ProcessDimensions(string dimension)
  {
    string[] dimensions = dimension.Split('x');
    return Array.ConvertAll(dimensions, num => int.Parse(num));
  }
}
