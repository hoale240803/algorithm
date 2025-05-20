using Tree;

namespace algorithm.BinarySearch
{
    public class BinaryTreeRightSideView
    {
        List<int> res = new List<int>();

        public List<int> RightSideViewV2(TreeNode root)
        {
            dfs(root, 0);
            return res;
        }

        private void dfs(TreeNode node, int depth)
        {
            if (node == null)
            {
                return;
            }

            if (res.Count == depth)
            {
                res.Add(node.val);
            }

            dfs(node.right, depth + 1);
            dfs(node.left, depth + 1);
        }

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