using Tree;

namespace BinarySearch
{
    public class BalancedBinaryTree
    {
        public bool IsBalanced(TreeNode root)
        {
            // Given a binary tree, return true if it is height-balanced and false otherwise.

            // A height-balanced binary tree is defined as a binary tree in which the left and 
            // right subtrees of every node differ in height by no more than 1.            

            // Apply DFS to check if the tree is balanced   
            return DFS(root) != -1;
        }

        private int DFS(TreeNode root)
        {
            if (root == null) return 0;

            int left = DFS(root.left);
            int right = DFS(root.right);

            if (left == -1 || right == -1 || Math.Abs(left - right) > 1) return -1;

            return Math.Max(left, right) + 1;
        }

    }
}