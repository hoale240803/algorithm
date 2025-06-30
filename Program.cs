
using algorithm.Backtracking;


CombinationSumClass cb = new CombinationSumClass();
List<List<int>> result = cb.CombinationSum(new int[] { 2, 3, 6, 9 }, 9);
foreach (var combination in result)
{
    Console.WriteLine(string.Join(", ", combination));
}