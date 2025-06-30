
using algorithm.Backtracking;

Permutations permutations = new Permutations();
var result1 = permutations.Permute(new int[] { 1, 2, 3 });
var result2 = permutations.Permute2(new int[] { 1, 2, 3 });
Console.WriteLine("Permutations using Recursion:");
foreach (var perm in result1)
{
    Console.WriteLine(string.Join(", ", perm));
}