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
            if (node == null)
            {
                Console.WriteLine("null");
                continue;
            }
            Console.WriteLine(node.val);
            if (node.left != null)
                queue.Enqueue(node.left);
            else
                Console.WriteLine("null");
            if (node.right != null)
                queue.Enqueue(node.right);
            else
                Console.WriteLine("null");
        }
    }

    public void PrintDFS()
    {
        Console.WriteLine(val);
        if (left != null) left.PrintDFS();
        if (right != null) right.PrintDFS();
    }

    public void PrintLevelOrder(List<List<int>> list)
    {
        foreach (var listInt in list)
        {
            foreach (var item in listInt)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    public void PrintRightSideView(List<int> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}
