using Tree;

namespace algorithm.Tree;

public class SerializeAndDeserialize
{
    // Depth first search
    public string Serialize(TreeNode root)
    {
        List<string> res = new List<string>();
        dfsSerialize(root, res);
        return String.Join(",", res);
    }

    private void dfsSerialize(TreeNode node, List<string> res)
    {
        if (node == null)
        {
            res.Add("N");
            return;
        }

        res.Add(node.val.ToString());
        dfsSerialize(node.left, res);
        dfsSerialize(node.right, res);
    }

    public TreeNode Deserialize(string data)
    {
        string[] vals = data.Split(',');
        int i = 0;
        return dfsDeserialize(vals, ref i);
    }

    private TreeNode dfsDeserialize(string[] vals, ref int i)
    {
        if (vals[i] == "N")
        {
            i++;
            return null;
        }

        TreeNode node = new TreeNode(Int32.Parse(vals[i]));
        i++;
        node.left = dfsDeserialize(vals, ref i);
        node.right = dfsDeserialize(vals, ref i);

        return node;
    }

    // Breadth first search

    public string Serialize2(TreeNode root)
    {
        if (root == null) return "null";

        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                res.Add("null");
            }
            else
            {
                res.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        return string.Join(",", res);
    }

    public TreeNode Deserialize2(string data)
    {
        var vals = data.Split(',');
        if (vals[0] == "null") return null;

        var root = new TreeNode(int.Parse(vals[0]));

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (vals[index] != "null")
            {
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if (vals[index] != "null")
            {
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }
        return root;
    }

}