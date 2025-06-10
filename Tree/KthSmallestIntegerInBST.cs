using Tree;

namespace algorithm.Tree;

public class KthSmallestIntegerInBST
{
    // brute force
    public int KthSmallest(TreeNode root, int k)
    {
        List<int> arr = new List<int>();
        Dfs(root, arr);
        arr.Sort();
        return arr[k - 1];
    }

    private void Dfs(TreeNode node, List<int> arr)
    {
        if (node == null) return;

        arr.Add(node.val);
        Dfs(node.left, arr);
        Dfs(node.right, arr);
    }

    // recursive dfs
    public int KthSmallest1(TreeNode root, int k)
    {
        int[] tmp = new int[2];
        tmp[0] = k;
        Dfs2(root, tmp);
        return tmp[1];
    }

    private void Dfs2(TreeNode node, int[] temp)
    {
        if (node == null) return;

        Dfs2(node.left, temp);
        temp[0]--;
        if (temp[0] == 0)
        {
            temp[1] = node.val;
            return;
        }
        Dfs2(node.right, temp);
    }


}