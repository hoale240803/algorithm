namespace algorithm.Backtracking;

public class Combination
{
    List<List<int>> res = new List<List<int>>();
    // Backtracking
    public void Backtrack(int i, List<int> cur, int total, int[] nums, int target)
    {
        if (total == target)
        {
            res.Add(cur.ToList());
            return;
        }

        if (total > target || i >= nums.Length)
        {
            return;
        }

        cur.Add(nums[i]);
        Backtrack(i, cur, total + nums[i], nums, target);
        cur.Remove(cur.Last());

        Backtrack(i + 1, cur, total, nums, target);
    }

    public List<List<int>> CombineSum(int[] nums, int target)
    {
        Backtrack(0, new List<int>(), 0, nums, target);

        return res;
    }

    public void ToString(List<List<int>> res)
    {
        foreach (var list in res)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}