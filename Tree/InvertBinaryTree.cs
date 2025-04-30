using Tree;

namespace Algorithm.Tree;


public class InvertBinaryTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        // You are given the root of a binary tree root. Invert the binary tree and return its root.
        //  Input: root = [1,2,3,4,5,6,7]
        //  Output: [1,3,2,7,6,5,4]

        //  Input: root = [3,2,1]
        //  Output: [3,1,2]

        // if the root is null, return null
        // if the root is not null, swap the left and right nodes

        if (root == null) return null;

        var temp = root.left;
        root.left = root.right;
        root.right = temp;

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}

