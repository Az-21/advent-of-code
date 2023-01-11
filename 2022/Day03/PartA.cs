namespace Day03;
internal class PartA
{
  public static void Run()
  {
    // Read input and initialize priority sum
    int prioritySum = 0;
    string[] prompt = Program.ReadPrompt();

    // Iterate over all rucksacks
    foreach (string sack in prompt)
    {
      // Split in halves
      string[] compartment = SplitStringInHalf(sack);

      // Remove repeating characters in each half
      for (int i = 0; i < 2; i++)
      {
        Dictionary<char, int> sackCompartment = Program.GenerateCharacterFrequencyDictionary(compartment[i]);
        compartment[i] = Program.GenerateUniqueCharacterString(sackCompartment);
      }

      // Recombine compartments
      string filteredRucksack = compartment[0] + compartment[1];

      // Find character repeating twice in the filtered rucksack and add it to priority
      Dictionary<char, int> rucksackFrequency = Program.GenerateCharacterFrequencyDictionary(filteredRucksack);
      char priorityCharacter = Program.FindFirstNRepeatedCharacter(rucksackFrequency, 2);
      prioritySum += Program.GetCharacterPriority(priorityCharacter);
    }

    // Print result
    Console.WriteLine(prioritySum);
  }

  // Generate two strings by chopping input string in half
  private static string[] SplitStringInHalf(string input)
  {
    int length = input.Length / 2;
    return new string[2] {
            input[0..length],
            input[length..]
        };
  }
}
