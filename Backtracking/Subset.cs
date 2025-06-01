namespace algorithm.Backtracking;

public class Subset
{
    // Backtracking
    public List<List<int>> Subsets(int[] nums)
    {
        var res = new List<List<int>>();
        var subset = new List<int>();

        Dfs(nums, 0, subset, res);
        return res;

    }

    private void Dfs(int[] nums, int i, List<int> subset, List<List<int>> res)
    {
        if (i >= nums.Length)
        {
            res.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        Dfs(nums, i + 1, subset, res);
        subset.RemoveAt(subset.Count - 1);
        Dfs(nums, i + 1, subset, res);
    }

    // Iteration
    public List<List<int>> Subsets2(int[] nums)
    {
        List<List<int>> res = new List<List<int>>();
        res.Add(new List<int>()); // Start with the empty subset

        foreach (var num in nums)
        {
            int size = res.Count;
            for (int i = 0; i < size; i++)
            {
                List<int> subset = new List<int>(res[i]);
                subset.Add(num);
                res.Add(subset);
            }
        }

        return res;
    }

    // Bit Manipulation
    public List<List<int>> Subsets3(int[] nums)
    {
        int n = nums.Length;
        List<List<int>> res = new List<List<int>>();

        for (int i = 0; i < (1 << n); i++)
        {
            List<int> subset = new List<int>();

            for (int j = 0; j < n; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subset.Add(nums[j]);
                }
            }
            res.Add(subset);
        }

        return res;
    }

    public void ToString(List<List<int>> subsets)
    {
        foreach (var subset in subsets)
        {
            Console.WriteLine("[" + string.Join(", ", subset) + "]");
        }
    }
}