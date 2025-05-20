using Tree;

namespace algorithm.BinarySearch
{
    public class BinaryTreeRightSideView
    {
        public List<int> RightSideView(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root == null) return res;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                TreeNode rightNode = null;
                int qLen = q.Count;
                for (int i = 0; i < qLen; i++)
                {
                    var node = q.Dequeue();
                    if (node != null)
                    {
                        rightNode = node;
                        q.Enqueue(node.left);
                        q.Enqueue(node.right);
                    }
                }

                if (rightNode != null)
                {
                    res.Add(rightNode.val);
                }
            }

            return res;
        }
    }
}