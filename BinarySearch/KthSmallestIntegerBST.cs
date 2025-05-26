using Tree;

namespace algorithm.BinarySearch
{
    public class KthSmallestIntegerBST
    {
        public int KthSmallest(TreeNode root, int k)
        {
            TreeNode curr = root;

            while (curr != null)
            {
                if (curr.left == null)
                {
                    k--;
                    if (k == 0) return curr.val;
                    curr = curr.right;
                }
                else
                {
                    TreeNode pred = curr.left;
                    while (pred.right != null && pred.right != curr)
                        pred = pred.right;

                    if (pred.right == null)
                    {
                        pred.right = curr;
                        curr = curr.left;
                    }
                    else
                    {
                        pred.right = null;
                        k--;
                        if (k == 0) return curr.val;
                        curr = curr.right;
                    }
                }
            }
            return -1;
        }
    }
}