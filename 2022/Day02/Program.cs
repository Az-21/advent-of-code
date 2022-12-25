namespace Day02;

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

    public static int[] ParseRoundAsInt(string round)
    {
        // Player responses { PlayerA [0] | Space [1] | PlayerB [2] }
        int playerA = (int)round.ElementAt(0) - 65; // ASCII 'A' = 65
        int playerB = (int)round.ElementAt(2) - 88; // ASCII 'X' = 88

        return new int[2] { playerA, playerB };
    }
}
