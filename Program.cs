
using algorithm.ArrayAndHashing;
using algorithm.Intervals;

NonOverlappingIntervals nonOverlappingIntevals = new NonOverlappingIntervals();
var res = nonOverlappingIntevals.EraseOverlapIntervals3(new int[][]
{
    new int[] { 1, 2 },
    new int[] { 2, 4 },
    new int[] { 1, 4 },
});

Console.WriteLine(res); // Output: 1s