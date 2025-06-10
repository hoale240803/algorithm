using Tree;

namespace algorithm.Tree;

public class ConstructBinaryTree
{
    int preIndex = 0;
    int inIndex = 0;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return Dfs(preorder, inorder, int.MaxValue);
    }

    private TreeNode Dfs(int[] preorder, int[] inorder, int limit)
    {
        if (preIndex >= preorder.Length) return null;
        if (inorder[inIndex] == limit)
        {
            inIndex++;
            return null;
        }

        TreeNode root = new TreeNode(preorder[preIndex++]);
        root.left = Dfs(preorder, inorder, root.val);
        root.right = Dfs(preorder, inorder, limit);

        return root;
    }
}