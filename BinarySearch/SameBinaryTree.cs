using Tree;

namespace Algorithm.BinarySearch
{
    public class SameBinaryTree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            // Given two binary trees, write a function to check if they are the same or not.
            // Two binary trees are considered the same if they are structurally identical and the nodes have the same value.
            // Apply DFS to check if the trees are the same

            return DFS(p, q);
        }

        private bool DFS(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val != q.val) return false;
            return DFS(p.left, q.left) && DFS(p.right, q.right);
        }
    }
}