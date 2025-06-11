
using algorithm.ArrayAndHashing;


ContainsDuplicate cd = new ContainsDuplicate();

// var nums = new int[] { 1, 2, 2, 4, 5, 6, 7, 8, 9, 10 };
var nums = new int[] { 100, 200, 300, 100, 500, 600, 200 };
cd.hasDuplicate(nums);

System.Console.WriteLine("result: " + cd.hasDuplicate(nums));