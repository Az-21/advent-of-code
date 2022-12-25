namespace Day03;

internal class Program
{
    public static void Main()
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

    // Assign priority to repeating character
    public static int GetCharacterPriority(char character)
    {
        // Handle unexpected input
        if (Char.IsLetter(character) is not true) { return -1; }

        // Check lowercase and return lowercase priority [a-z] = [1-26]
        if (Char.IsLower(character)) { return (int)character - 97 + 1; } // ASCII 'a' is 97

        // Otherwise return uppercase character priority [A-Z] = [27-52]
        return (int)character - 65 + 27; // ASCII 'A' is 65
    }

    // Create dictionary to count number of times a character is repeated
    public static Dictionary<char, int> GenerateCharacterFrequencyDictionary(string input)
    {
        Dictionary<char, int> characterFrequency = new();

        foreach (char c in input)
        {
            // If char key exists in dictionary, increment its valve (occurrence) by 1
            if (characterFrequency.ContainsKey(c)) { characterFrequency[c]++; }
            // Otherwise create a new key-value pair
            else { characterFrequency[c] = 1; }
        }

        return characterFrequency;
    }

    // Find and return first character repeated 'n' times from a character frequency dictionary
    public static char FindFirstNRepeatedCharacter(Dictionary<char, int> characterFrequency, int repeats)
    {
        // Find the first key-value pair in the dictionary where the value is 2
        KeyValuePair<char, int> repeat = characterFrequency
            .FirstOrDefault(c => c.Value == repeats);

        // Default of char is \u0000, so the LINQ query automatically gives desired if-else output
        return repeat.Key;
    }

    // Generate a unique, non-repeating character string from a character frequency dictionary
    public static string GenerateUniqueCharacterString(Dictionary<char, int> characterFrequency)
    {
        // Join all keys and return as string
        char[] uniqueCharacters = characterFrequency.Keys.ToArray();
        return string.Join(String.Empty, uniqueCharacters);
    }
}
