namespace Day01;

public class Program
{
  static void Main()
  {
    string part = "A";
    if (part == "A") { PartA.Run(); }
    //if (part == "B") { PartB.Run(); }
  }

  // Read file containing the prompt
  public static string ReadPrompt()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename);
    return prompt.Trim();
  }
}
