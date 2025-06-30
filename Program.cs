
using algorithm.Backtracking;

SubsetII subsetII = new SubsetII();
List<List<int>> result = subsetII.SubsetsWithDup(new int[] { 1, 2, 2 });
foreach (var subset in result)
{
    Console.WriteLine("[" + string.Join(", ", subset) + "]");
}