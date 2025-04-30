namespace Tree;

public class DiameterOfBinaryTreeClass
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        // Given the root of a binary tree, return the length of the diameter of the tree.
        // The diameter of a binary tree is the length of the longest path between any two nodes in a tree. 
        // This path may or may not pass through the root.

        // Input: root = [1,2,3,4,5]
        // Output: 3    

        // Input: root = [1,2,3]
        // Output: 2

        // todo: check left and right node
        // apply depth first search
        // create a helper function to calculate the depth of the tree
        // if both left and right node are not null, return 2 + left node + right node

        int res = 0;
        Depth(root, ref res);
        return res;
    }

    private int Depth(TreeNode root, ref int res)
    {
        if (root == null) return 0;
        int left = Depth(root.left, ref res);
        int right = Depth(root.right, ref res);

        res = Math.Max(res, left + right);

        return Math.Max(left, right) + 1;
    }

}