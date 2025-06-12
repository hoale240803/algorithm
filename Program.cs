
using algorithm.ArrayAndHashing;
using algorithm.Intervals;

MergeIntervals mergeIntervals = new MergeIntervals();



var res = mergeIntervals.Merge2(new int[][]
{
    new int[] { 1, 3 },
    new int[] { 2, 6 },
    new int[] { 8, 10 },
    new int[] { 15, 18 }
});

foreach (var interval in res)
{
    Console.WriteLine($"[{interval[0]}, {interval[1]}]");
}