
using algorithm.ArrayAndHashing;


TwoSumClass twoSum = new TwoSumClass();
int[] nums = { 3, 4, 5, 6 };
int target = 7;
int[] result = twoSum.TwoSum(nums, target);
Console.WriteLine($"Indices of the two numbers that add up to {target}: [{result[0]}, {result[1]}]");

int[] nums2 = { 4, 5, 6 };
int target2 = 10;
int[] result2 = twoSum.TwoSum(nums2, target2);
Console.WriteLine($"Indices of the two numbers that add up to {target2}: [{result2[0]}, {result2[1]}]");