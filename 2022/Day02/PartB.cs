namespace Day02;

internal class PartB
{
  // Tournament matrix (RPS vs Response)
  static readonly int[,] tournamentResponse = new int[3, 3]
  {
        { 2, 0, 1 },
        { 0, 1, 2 },
        { 1, 2, 0 },
  };

  public static void Run()
  {
    // Calculate result of each round in tournament and add score
    int score = 0;
    string[] rounds = Program.ReadPrompt();
    foreach (string round in rounds)
    {
      // First response is from opponent, second response is result
      int[] response = Program.ParseRoundAsInt(round);

      // Score from round result | 0->0 Lose, 1->3 Draw, 2->6 Win
      score += 3 * response[1];

      // Calculate our response based on result
      int ourResponse = tournamentResponse[response[0], response[1]];

      // Score from playing a specific action (R=1, P=2, S=3), so just adding 1
      score += ourResponse + 1;
    }

    Console.WriteLine(score);
  }
}
