namespace Tree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    // todo: print the tree breadth first   
    public void PrintBFS()
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            Console.WriteLine(node.val);
            if (node.left != null) queue.Enqueue(node.left);
            if (node.right != null) queue.Enqueue(node.right);
        }
    }


    public void PrintDFS()
    {
        Console.WriteLine(val);
        if (left != null) left.PrintDFS();
        if (right != null) right.PrintDFS();
    }
}
