
namespace algorithm.Graph;

public class CloneGraphClass
{
    public Node CloneGraph(Node node)
    {
        Dictionary<Node, Node> oldToNew = new();

        return Dfs(node, oldToNew);
    }

    private Node Dfs(Node node, Dictionary<Node, Node> oldToNew)
    {
        if (node == null)
            return null;

        if (oldToNew.ContainsKey(node))
        {
            return oldToNew[node];
        }

        Node copy = new Node(node.val);
        oldToNew[node] = copy;

        foreach (Node nei in node.neighbors)
        {
            copy.neighbors.Add(Dfs(nei, oldToNew));
        }

        return copy;
    }
}