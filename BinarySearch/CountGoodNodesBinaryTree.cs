using Tree;

namespace algorithm.BinarySearch
{
    public class CountGoodNodesBinaryTree
    {
        public int GoodNodes(TreeNode root)
        {
            return Dfs(root, root.val);
        }

        public int Dfs(TreeNode node, int maxVal)
        {
            if (node == null)
                return 0;

            int res = (node.val >= maxVal) ? 1 : 0;
            maxVal = Math.Max(node.val, maxVal);

            res += Dfs(node.left, maxVal);
            res += Dfs(node.right, maxVal);

            return res;
        }
    }
}