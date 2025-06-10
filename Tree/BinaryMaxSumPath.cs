using Tree;

namespace algorithm.Tree;

public class BinaryMaxSumPath
{
    // Depth first search
    int res = int.MinValue;
    public int MaxPathSum(TreeNode root)
    {
        dfs(root);
        return res;
    }

    private int GetMax(TreeNode root)
    {
        if (root == null) return 0;
        int left = GetMax(root.left);
        int right = GetMax(root.right);
        int path = root.val + Math.Max(left, right);

        return Math.Max(0, path);
    }

    private void dfs(TreeNode root)
    {
        if (root == null) return;

        int left = GetMax(root.left);
        int right = GetMax(root.right);
        res = Math.Max(res, root.val + left + right);
        dfs(root.left);
        dfs(root.right);
    }


    // DFS optimal

    public int MaxPathSum2(TreeNode root)
    {
        int res = root.val;

        Dfs2(root, ref res);
        return res;

    }

    private int Dfs2(TreeNode root, ref int res)
    {
        if (root == null)
        {
            return 0;
        }

        int leftMax = Math.Max(Dfs2(root.left, ref res), 0);
        int rightMax = Math.Max(Dfs2(root.right, ref res), 0);

        res = Math.Max(res, root.val + leftMax + rightMax);

        return root.val + Math.Max(leftMax, rightMax);
    }
}