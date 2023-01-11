using System.Security.Cryptography;
using System.Text;

namespace Day04;

public static class Program
{
  static void Main()
  {
    string part = "B";
    if (part == "A") { PartA.Run(); }
    if (part == "B") { PartB.Run(); }
  }

  // Function to generate MD5 hash in HEX from a string input
  public static string GenerateMD5Hex(string input)
  {
    byte[] data = MD5.HashData(Encoding.UTF8.GetBytes(input));
    StringBuilder sBuilder = new();
    for (int i = 0; i < data.Length; i++)
    {
      // `format: "x2"` converts MD5 hash from base10 (DEC) to base16 (HEX) in lowercase
      sBuilder.Append(data[i].ToString("x2"));
    }
    return sBuilder.ToString();
  }

  public static int CrackSecretSuffix(string prompt, int leadingZeros)
  {
    // Tracker for suffix number
    int suffix = 1; // Start at 1 because leading zeros are not allowed

    // Desired number of leading zeros in the MD5 hash
    string zeros = new('0', leadingZeros);

    // Generate MD5 hash of prompt+suffix -> check for leading zeros -> increment suffix
    for (int i = 0; i < int.MaxValue; i++) // Setting reasonably large upper limit on loop
    {
      string key = prompt + suffix;
      string md5Hash = GenerateMD5Hex(key);

      // If current hash satisfies leading zeros condition, return the secret suffix
      if (zeros == md5Hash[0..leadingZeros]) { return suffix; }

      // Otherwise prepare for next loop and try next hash
      suffix++;
    }

    // Reaching here implies there is no such suffix in [1, int32.Max]
    throw new OverflowException();
  }
}
