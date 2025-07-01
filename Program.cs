
using algorithm.Backtrackingl;

PalindromePartitioning palindromePartitioning = new PalindromePartitioning();
List<List<string>> result = palindromePartitioning.Partition("aab");
foreach (var partition in result)
{
    Console.WriteLine(string.Join(", ", partition));
}
