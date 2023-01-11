// Number of top elves sharing their portion
const int n = 3;

// Read file containing the prompt
const string filename = "Prompt.txt";
string prompt = File.ReadAllText(filename);
const string separator = "\r\n"; // Prompt values are separated by CR LF

// Split contribution by each elf
string[] contributions = prompt.Split(new string[] { separator + separator }, StringSplitOptions.TrimEntries);

// Find sum of all contributions by each elf
List<int> individualContributions = new();
foreach (string contribution in contributions)
{
  string[] ledger = contribution.Split(separator, StringSplitOptions.TrimEntries);
  int[] parsedLedger = Array.ConvertAll(ledger, x => int.Parse(x));
  individualContributions.Add(parsedLedger.Sum());
}

// Sort individual contributions in descending order
individualContributions = individualContributions.OrderByDescending(x => x).ToList();

// Take sum of top 'n' contributions
int topContributions = individualContributions.Take(n).Sum(x => x);
Console.WriteLine(topContributions);
