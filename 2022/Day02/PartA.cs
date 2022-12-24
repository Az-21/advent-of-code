namespace Day02;

internal class PartA
{
    // Tournament matrix (RPS vs RPS)
    static readonly int[,] tournament = new int[3, 3]
    {
        { 3, 0, 6 },
        { 6, 3, 0 },
        { 0, 6, 3 },
    };

    public static void Run()
    {
        // Calculate result of each round in tournament and add score
        int score = 0;
        string[] rounds = Program.ReadPrompt();
        foreach (string round in rounds)
        {
            // First response is from opponent, second response is from us (R=0, P=1, S=2)
            int[] response = Program.ParseRoundAsInt(round);

            // Score from round result
            score += tournament[response[1], response[0]];

            // Score from playing a specific action (R=1, P=2, S=3), so just adding 1
            score += response[1] + 1;
        }

        Console.WriteLine(score);
    }
}
