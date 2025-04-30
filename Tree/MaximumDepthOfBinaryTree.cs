namespace Tree
{
    public class MaximumDepthOfBinaryTree
    {
        public int MaxDepth(TreeNode root)
        {
            //Given the root of a binary tree, return its depth.
            // The depth of a binary tree is defined as the number of nodes along the longest path 
            // from the root node down to the farthest leaf node.

            // Input: root = [1,2,3,null,null,4]
            // Output: 3


            // Input: root = [1,null,2]
            // Output: 2

            // Input: root = []
            // Output: 0

            if (root == null) return 0;

            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
