namespace Day05;

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
    string prompt = File.ReadAllText(filename).ToLower(); // Ensure everything is in lowercase
    const string separator = "\r\n"; // Prompt values are separated by CR LF
    return prompt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }
}
