namespace Utility;

public static class Helper
{
  private static void Main() { }
  public static string[] ReadPromptLines()
  {
    const string filename = "Prompt.txt";
    string prompt = File.ReadAllText(filename).ToLower();
    const string separator = "\r\n"; // Prompt values are separated by CR LF
    return prompt.Split(separator, StringSplitOptions.RemoveEmptyEntries);
  }
}
