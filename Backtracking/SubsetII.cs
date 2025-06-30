namespace algorithm.Backtracking;

public class SubsetII
{
    // 1. Brute Force 
    HashSet<string> res = new HashSet<string>();
    public List<List<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        Backtrack(nums, 0, new List<int>());
        List<List<int>> result = new List<List<int>>();
        result.Add(new List<int>());
        res.Remove("");

        foreach (var str in res)
        {
            List<int> subset = new List<int>();
            string[] arr = str.Split(',');
            foreach (var num in arr)
            {
                subset.Add(int.Parse(num));
            }
            result.Add(subset);
        }

        return result;
    }

    private void Backtrack(int[] nums, int i, List<int> subset)
    {
        if (i == nums.Length)
        {
            res.Add(string.Join(",", subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(nums, i + 1, subset);
        subset.RemoveAt(subset.Count - 1);
        Backtrack(nums, i + 1, subset);
    }

    // 2. Backtracking with pruning
    private List<List<int>> res1 = new List<List<int>>();
    public List<List<int>> SubsetsWithDup2(int[] nums)
    {
        Array.Sort(nums);
        Backtrack1(0, new List<int>(), nums);
        return res1;
    }

    private void Backtrack1(int i, List<int> subset, int[] nums)
    {
        res1.Add(new List<int>(subset));
        for (int j = i; j < nums.Length; j++)
        {
            if (j > i && nums[j] == nums[j - 1])
            {
                continue;
            }

            subset.Add(nums[j]);
            Backtrack1(j + 1, subset, nums);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}