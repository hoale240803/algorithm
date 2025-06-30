
namespace algorithm.Backtracking;

public class Permutations
{
    // 1. Recursion
    public List<List<int>> Permute(int[] nums)
    {
        if (nums.Length == 0)
        {
            return new List<List<int>> { new List<int>() };
        }


        var perms = Permute(nums.Skip(1).ToArray());
        var res = new List<List<int>>();

        foreach (var p in perms)
        {
            for (int i = 0; i <= p.Count; i++)
            {
                var p_copy = new List<int>(p);
                p_copy.Insert(i, nums[0]);
                res.Add(p_copy);
            }
        }

        return res;
    }

    // 2. Backtracking
    List<List<int>> res;
    public List<List<int>> Permute2(int[] nums)
    {
        res = new List<List<int>>();
        Backtrack(new List<int>(), nums, new bool[nums.Length]);
        return res;
    }

    private void Backtrack(List<int> perm, int[] nums, bool[] pick)
    {
        if (perm.Count == nums.Length)
        {
            res.Add(new List<int>(perm));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (!pick[i])
            {
                perm.Add(nums[i]);
                pick[i] = true;
                Backtrack(perm, nums, pick);
                perm.RemoveAt(perm.Count - 1);
                pick[i] = false;
            }
        }
    }
}