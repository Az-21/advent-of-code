namespace Day03;

internal class PartB
{
  public static void Run()
  {
    // Calculate the sum of priorities
    int prioritySum = 0;
    string[] prompt = Program.ReadPrompt();

    // Filter prompt to remove repeating characters from each rucksack
    for (int i = 0; i < prompt.Length; i++)
    {
      Dictionary<char, int> sackFrequency = Program.GenerateCharacterFrequencyDictionary(prompt[i]);
      prompt[i] = Program.GenerateUniqueCharacterString(sackFrequency);
    }

    // Iterate over rucksacks in pairs of three to find the first character present in all three rucksacks
    for (int i = 0; i < prompt.Length; i += 3)
    {
      string groupSack = prompt[i] + prompt[i + 1] + prompt[i + 2];
      Dictionary<char, int> sackFrequency = Program.GenerateCharacterFrequencyDictionary(groupSack);
      char groupBadge = Program.FindFirstNRepeatedCharacter(sackFrequency, 3);
      prioritySum += Program.GetCharacterPriority(groupBadge);
    }

    // Print result
    Console.WriteLine(prioritySum);
  }
}
