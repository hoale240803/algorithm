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

            // Base case: if the tree is empty, it is balanced
            if (root == null) return true;

            // Get the height of the left and right subtrees
            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            // If the left and right subtrees are balanced and the difference between their heights is at most 1, then the tree is balanced
            return IsBalanced(root.left) && IsBalanced(root.right) && Math.Abs(leftHeight - rightHeight) <= 1;
        }

        private int GetHeight(TreeNode root)
        {
            if (root == null) return 0;

            // Get the height of the left and right subtrees
            int leftHeight = GetHeight(root.left);
            int rightHeight = GetHeight(root.right);

            // Return the height of the tree
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}