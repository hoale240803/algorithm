using System.Text;

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }

    // print method to display the graph
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("[");
        foreach (var neighbor in neighbors)
        {
            sb.Append(neighbor.val + ",");
        }
        if (sb.Length > 1)
            sb.Length--; // remove last comma
        sb.Append("]");
        return sb.ToString();
    }
}