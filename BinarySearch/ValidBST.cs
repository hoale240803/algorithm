using Tree;

namespace algorithm.BinarySearch
{
    public class ValidBST
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;

            return Dfs(root, int.MinValue, int.MaxValue);
        }

        public bool Dfs(TreeNode node, int left, int right)
        {
            if (node == null)
                return true;

            if (!(left < node.val && right > node.val))
            {
                return false;
            }

            return Dfs(node.left, left, node.val) && Dfs(node.right, node.val, right);
        }
    }
}