namespace Day06;

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

  // Parse prompt into [ action | start coordinates | end coordinates ]
  public static Instruction ParseInstruction(string instruction)
  {
    // Determine switch action from first part of instruction
    SwitchAction switchAction = ParseAction(instruction);

    // Split instruction at spaces
    const char space = ' ';
    string[] delta = instruction.Split(space);

    /* 
     * Toggle instruction .Splits with length of 4 and coordinates at [1] and [3]
     * Turn on/off instruction .Splits with length of 5 and coordinates at [2] and [4]
     */
    return delta.Length switch
    {
      4 => new Instruction(switchAction, delta[1], delta[3]),
      5 => new Instruction(switchAction, delta[2], delta[4]),
      _ => throw new Exception("Unexpected data formatting"),
    };
  }

  // Parse action from prompt
  public static SwitchAction ParseAction(string instruction)
  {
    char distinguisher = instruction[6];
    return distinguisher switch
    {
      ' ' => SwitchAction.Toggle,     // toggle[] -> 6th character is distinguisher
      'n' => SwitchAction.TurnOn,     // turn o[n]
      'f' => SwitchAction.TurnOff,    // turn o[f]f
      _ => throw new InvalidDataException(),
    };
  }
}

// Valid switching actions
public enum SwitchAction { Toggle, TurnOn, TurnOff }

// Class to hold meaningful data from instructions
public class Instruction
{
  public SwitchAction Action { get; }
  public int[] TopLeftCoordinate { get; }
  public int[] BottomRightCoordinate { get; }

  public Instruction(SwitchAction action, int[] topLeftCoordinate, int[] bottomRightCoordinate)
  {
    Action = action;
    TopLeftCoordinate = topLeftCoordinate;
    BottomRightCoordinate = bottomRightCoordinate;
  }

  public Instruction(SwitchAction action, string topLeftCoordinate, string bottomRightCoordinate)
  {
    string[] tlc = topLeftCoordinate.Split(',', StringSplitOptions.TrimEntries);
    string[] brc = bottomRightCoordinate.Split(',', StringSplitOptions.TrimEntries);

    Action = action;
    TopLeftCoordinate = Array.ConvertAll(tlc, x => int.Parse(x));
    BottomRightCoordinate = Array.ConvertAll(brc, x => int.Parse(x));
  }
}
