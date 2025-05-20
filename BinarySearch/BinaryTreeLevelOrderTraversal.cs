using Tree;

namespace algorithm.BinarySearch
{
    public class BinaryTreeLevelOrderTraversal
    {
        static List<List<int>> res = new List<List<int>>();

        public static List<List<int>> LevelOrder(TreeNode root)
        {
            dfs(root, 0);
            return res;
        }

        private static void dfs(TreeNode node, int depth)
        {
            if (node == null)
                return;

            if (res.Count == depth)
            {
                res.Add(new List<int>());
            }
            res[depth].Add(node.val);
            dfs(node.left, depth + 1);
            dfs(node.right, depth + 1);
        }


        public static List<List<int>> LevelOrderV2(TreeNode root)
        {
            List<List<int>> res = new List<List<int>>();
            if (root == null) return res;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                List<int> listVal = new List<int>();
                for (int i = q.Count; i > 0; i--)
                {
                    TreeNode node = q.Dequeue();
                    if (node != null)
                    {
                        listVal.Add(node.val);
                        q.Enqueue(node.left);
                        q.Enqueue(node.right);
                    }
                }

                if (listVal.Count > 0)
                {
                    res.Add(listVal);
                }
            }

            return res;
        }
    }
}